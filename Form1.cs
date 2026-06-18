using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MY_Coderpad
{
    public partial class Form1 : Form
    {
        private string aktifDil = "Düz Metin";
        private string mevcutDosyaYolu = null;
        private bool renklendiriliyor = false;

        // Bul ve Değiştir hafızası için değişkenler
        private string sonArananKelime = "";
        private int sonBulunanIndeks = 0;

        // Windows Başlık Çubuğu API'leri
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_OLD = 19;

        // Constructor parametre alacak şekilde güncellendi (varsayılan olarak null)
        public Form1(string baslangicDosyaYolu = null)
        {
            InitializeComponent();

            richTextBox1.Font = new Font("Consolas", 12F, FontStyle.Regular);
            richTextBox1.WordWrap = false;

            // Menü tasarımını sabitle
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorTable());
            BaslikCubugunuKoyuYap();

            // Eğer dışarıdan bir dosya yolu gönderildiyse dosyayı yükle
            if (!string.IsNullOrEmpty(baslangicDosyaYolu))
            {
                try
                {
                    mevcutDosyaYolu = baslangicDosyaYolu;
                    richTextBox1.Text = File.ReadAllText(mevcutDosyaYolu);
                    this.Text = "MY Coderpad - " + Path.GetFileName(mevcutDosyaYolu);
                    OtoDilSec(Path.GetExtension(mevcutDosyaYolu).ToLower());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya açılırken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BaslikCubugunuKoyuYap()
        {
            try
            {
                int karanlikModAktif = 1;
                if (DwmSetWindowAttribute(this.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref karanlikModAktif, sizeof(int)) != 0)
                {
                    DwmSetWindowAttribute(this.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE_OLD, ref karanlikModAktif, sizeof(int));
                }
            }
            catch { }
        }

        // --- GLOBAL KISAYOL YÖNETİMİ (Yazı Boyutu + Düzen Kısayolları) ---
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 🟢 CTRL + "+" (Yazı Boyutunu 1px Büyüt)
            if (keyData == (Keys.Control | Keys.Oemplus) || keyData == (Keys.Control | Keys.Add))
            {
                YazitipiBoyutuGuncelle(1);
                return true;
            }
            // 🟢 CTRL + "-" (Yazı Boyutunu 1px Küçült)
            if (keyData == (Keys.Control | Keys.OemMinus) || keyData == (Keys.Control | Keys.Subtract))
            {
                YazitipiBoyutuGuncelle(-1);
                return true;
            }

            // Dosya Kısayolları
            if (keyData == (Keys.Control | Keys.S)) { DosyaKaydetmeIslemi(); return true; }
            if (keyData == (Keys.Control | Keys.R)) { DosyaCalistirIslemi(); return true; }

            // Düzen Kısayolları (Menüden bağımsız klavye tetikleyicileri)
            if (keyData == (Keys.Control | Keys.F)) { BulPencerasiAc(); return true; }
            if (keyData == Keys.F3) { SonrakiniBul(); return true; }
            if (keyData == (Keys.Shift | Keys.F3)) { ÖncekiniBul(); return true; }
            if (keyData == (Keys.Control | Keys.H)) { DegistirPenceresiAc(); return true; }
            if (keyData == (Keys.Control | Keys.G)) { GitPenceresiAc(); return true; }
            if (keyData == Keys.F5) { SaatTarihEkle(); return true; }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // --- YAZI BOYUTU DEĞİŞTİRME MANTIĞI ---
        private void YazitipiBoyutuGuncelle(float miktar)
        {
            float yeniBoyut = richTextBox1.Font.Size + miktar;
            // Yazı boyutunun çok küçülmesini veya absürt büyümesini engelleme sınırı (6px - 72px)
            if (yeniBoyut >= 6 && yeniBoyut <= 72)
            {
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, yeniBoyut, richTextBox1.Font.Style);
            }
        }

        // --- DÜZEN MENÜSÜ FONKSİYONLARI ---
        private void GeriAl() => richTextBox1.Undo();
        private void Kes() => richTextBox1.Cut();
        private void Kopyala() => richTextBox1.Copy();
        private void Yapistir() => richTextBox1.Paste();
        private void Sil() => richTextBox1.SelectedText = "";
        private void TumunuSec() => richTextBox1.SelectAll();

        private void SaatTarihEkle()
        {
            string zaman = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            int imlec = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.Insert(imlec, zaman);
            richTextBox1.SelectionStart = imlec + zaman.Length;
        }

        // --- GELİŞMİŞ BUL / SONRAKİNİ BUL / ÖNCEKİNİ BUL MANTIĞI ---
        private void BulPencerasiAc()
        {
            Form bulForm = CreatePopupForm("Bul", 320, 120);
            Label lbl = new Label() { Text = "Aranan Kelime:", ForeColor = Color.White, Location = new Point(10, 15), AutoSize = true };
            TextBox txt = new TextBox() { Width = 280, Location = new Point(10, 35), BackColor = Color.FromArgb(30, 30, 30), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Text = sonArananKelime };
            Button btn = new Button() { Text = "Bul", Location = new Point(215, 65), Width = 75, BackColor = Color.FromArgb(60, 60, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btn.Click += (s, e) => {
                if (!string.IsNullOrEmpty(txt.Text))
                {
                    sonArananKelime = txt.Text;
                    sonBulunanIndeks = 0;
                    bulForm.Close();
                    SonrakiniBul();
                }
            };
            bulForm.Controls.AddRange(new Control[] { lbl, txt, btn });
            bulForm.ShowDialog();
        }

        private void SonrakiniBul()
        {
            if (string.IsNullOrEmpty(sonArananKelime)) return;

            int indeks = richTextBox1.Find(sonArananKelime, sonBulunanIndeks, RichTextBoxFinds.None);
            if (indeks != -1)
            {
                richTextBox1.Focus();
                richTextBox1.Select(indeks, sonArananKelime.Length);
                sonBulunanIndeks = indeks + sonArananKelime.Length;
            }
            else
            {
                MessageBox.Show($"'{sonArananKelime}' metninin sonuna gelindi. Baştan aranıyor.", "Bul", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sonBulunanIndeks = 0; // Başa sar
            }
        }

        private void ÖncekiniBul()
        {
            if (string.IsNullOrEmpty(sonArananKelime)) return;

            int aramaBasi = sonBulunanIndeks - (sonArananKelime.Length * 2);
            if (aramaBasi < 0) aramaBasi = 0;

            int indeks = richTextBox1.Find(sonArananKelime, 0, richTextBox1.SelectionStart, RichTextBoxFinds.Reverse);
            if (indeks != -1)
            {
                richTextBox1.Focus();
                richTextBox1.Select(indeks, sonArananKelime.Length);
                sonBulunanIndeks = indeks;
            }
            else
            {
                MessageBox.Show($"Yukarı doğru başka sonuç bulunamadı.", "Bul", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- GELİŞMİŞ DEĞİŞTİR MANTIĞI ---
        private void DegistirPenceresiAc()
        {
            Form degistirForm = CreatePopupForm("Değiştir", 340, 170);
            Label lbl1 = new Label() { Text = "Aranan:", ForeColor = Color.White, Location = new Point(10, 15) };
            TextBox txtAranan = new TextBox() { Width = 300, Location = new Point(10, 35), BackColor = Color.FromArgb(30, 30, 30), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Text = sonArananKelime };
            Label lbl2 = new Label() { Text = "Yeni Değer:", ForeColor = Color.White, Location = new Point(10, 65) };
            TextBox txtYeni = new TextBox() { Width = 300, Location = new Point(10, 85), BackColor = Color.FromArgb(30, 30, 30), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            Button btn = new Button() { Text = "Değiştir", Location = new Point(235, 115), Width = 75, BackColor = Color.FromArgb(60, 60, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btn.Click += (s, e) => {
                if (!string.IsNullOrEmpty(txtAranan.Text))
                {
                    richTextBox1.Text = richTextBox1.Text.Replace(txtAranan.Text, txtYeni.Text);
                    degistirForm.Close();
                    MessageBox.Show("Tüm eşleşmeler değiştirildi!", "Değiştir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            degistirForm.Controls.AddRange(new Control[] { lbl1, txtAranan, lbl2, txtYeni, btn });
            degistirForm.ShowDialog();
        }

        // --- GELİŞMİŞ SATIRA GİT MANTIĞI ---
        private void GitPenceresiAc()
        {
            Form gitForm = CreatePopupForm("Satıra Git", 260, 120);
            Label lbl = new Label() { Text = "Satır Numarası:", ForeColor = Color.White, Location = new Point(10, 15), AutoSize = true };
            TextBox txt = new TextBox() { Width = 220, Location = new Point(10, 35), BackColor = Color.FromArgb(30, 30, 30), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            Button btn = new Button() { Text = "Git", Location = new Point(155, 65), Width = 75, BackColor = Color.FromArgb(60, 60, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btn.Click += (s, e) => {
                if (int.TryParse(txt.Text, out int satirHedef) && satirHedef > 0)
                {
                    int indeks = richTextBox1.GetFirstCharIndexFromLine(satirHedef - 1);
                    if (indeks != -1)
                    {
                        richTextBox1.Focus();
                        richTextBox1.SelectionStart = indeks;
                        richTextBox1.SelectionLength = 0;
                        gitForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu satır mevcut değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            };
            gitForm.Controls.AddRange(new Control[] { lbl, txt, btn });
            gitForm.ShowDialog();
        }

        // Pop-up pencereler için ortak stil yardımcısı
        private Form CreatePopupForm(string title, int width, int height)
        {
            Form f = new Form()
            {
                Text = title,
                Width = width,
                Height = height,
                BackColor = Color.FromArgb(24, 24, 24),
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };
            // Açılan alt pencerelerin de başlık çubuklarını siyah yapalım
            try { int val = 1; DwmSetWindowAttribute(f.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref val, sizeof(int)); } catch { }
            return f;
        }

        // --- MAPPED EVENT HANDLERS (Tasarım Tarafı Bağlantıları) ---
        // Bunları dilersen oluşturduğun Düzen / Edit menü butonlarının Click olaylarına bağlayabilirsin.
        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e) => GeriAl();
        private void kesToolStripMenuItem_Click(object sender, EventArgs e) => Kes();
        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e) => Kopyala();
        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e) => Yapistir();
        private void silToolStripMenuItem_Click(object sender, EventArgs e) => Sil();
        private void bulToolStripMenuItem_Click(object sender, EventArgs e) => BulPencerasiAc();
        private void sonrakiniBulToolStripMenuItem_Click(object sender, EventArgs e) => SonrakiniBul();
        private void öncekiniBulToolStripMenuItem_Click(object sender, EventArgs e) => ÖncekiniBul();
        private void değiştirToolStripMenuItem_Click(object sender, EventArgs e) => DegistirPenceresiAc();
        private void gitToolStripMenuItem_Click(object sender, EventArgs e) => GitPenceresiAc();
        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e) => TumunuSec();
        private void saatTarihToolStripMenuItem_Click(object sender, EventArgs e) => SaatTarihEkle();

        // --- ÖNCEKİ DOSYA VE DİL MOTORU METOTLARI ---
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Desteklenen Dosyalar|*.txt;*.html;*.php;*.bat;*.vbs,*.mtext,*.py|Tüm Dosyalar|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mevcutDosyaYolu = ofd.FileName;
                richTextBox1.Text = File.ReadAllText(mevcutDosyaYolu);
                this.Text = "MY Coderpad - " + Path.GetFileName(mevcutDosyaYolu);
                OtoDilSec(Path.GetExtension(mevcutDosyaYolu).ToLower());
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e) => DosyaKaydetmeIslemi();
        private void dosyayıÇalıştırToolStripMenuItem_Click(object sender, EventArgs e) => DosyaCalistirIslemi();

        private bool DosyaKaydetmeIslemi()
        {
            if (string.IsNullOrEmpty(mevcutDosyaYolu))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Metin Belgesi|*.txt|HTML Dosyası|*.html|PHP Dosyası|*.php|Batch Dosyası|*.bat|VBScript|*.vbs|mtext Dosyası|*.mtext|Python projesi *.py|*.py";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    mevcutDosyaYolu = sfd.FileName;
                    File.WriteAllText(mevcutDosyaYolu, richTextBox1.Text);
                    this.Text = "MY Coderpad - " + Path.GetFileName(mevcutDosyaYolu);
                    OtoDilSec(Path.GetExtension(mevcutDosyaYolu).ToLower());
                    return true;
                }
                return false;
            }
            File.WriteAllText(mevcutDosyaYolu, richTextBox1.Text);
            this.Text = "MY Coderpad - " + Path.GetFileName(mevcutDosyaYolu);
            return true;
        }

        private void DosyaCalistirIslemi()
        {
            if (!DosyaKaydetmeIslemi() || string.IsNullOrEmpty(mevcutDosyaYolu)) return;
            try
            {
                Process.Start(new ProcessStartInfo { FileName = mevcutDosyaYolu, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:\n" + ex.Message, "MY Coderpad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
        private void cToolStripMenuItem_Click(object sender, EventArgs e) { aktifDil = "C#"; BasitRenklendir(); }
        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e) { aktifDil = "HTML"; BasitRenklendir(); }
        private void pHPToolStripMenuItem_Click(object sender, EventArgs e) { aktifDil = "PHP"; BasitRenklendir(); }
        private void batchVBSToolStripMenuItem_Click(object sender, EventArgs e) { aktifDil = "Batch/VBS"; BasitRenklendir(); }

        private void OtoDilSec(string uzanti)
        {
            switch (uzanti)
            {
                case ".cs": aktifDil = "C#"; break;
                case ".html": aktifDil = "HTML"; break;
                case ".php": aktifDil = "PHP"; break;
                case ".bat":
                case ".vbs": aktifDil = "Batch/VBS"; break;
                default: aktifDil = "Düz Metin"; break;
            }
            BasitRenklendir();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (renklendiriliyor) return;
            string metin = richTextBox1.Text;
            if (string.IsNullOrWhiteSpace(metin)) return;

            string eskiDil = aktifDil;
            if (metin.Contains("using System") || metin.Contains("namespace ") || metin.Contains("public class")) aktifDil = "C#";
            else if (metin.Contains("<html>") || metin.Contains("<!DOCTYPE")) aktifDil = "HTML";
            else if (metin.Contains("<?php")) aktifDil = "PHP";
            else if (metin.Contains("@echo off") || metin.Contains("MsgBox ")) aktifDil = "Batch/VBS";

            if (eskiDil != aktifDil) BasitRenklendir();
        }

        private void BasitRenklendir()
        {
            if (renklendiriliyor) return;
            renklendiriliyor = true;

            int orijinalKonum = richTextBox1.SelectionStart;
            int orijinalUzunluk = richTextBox1.SelectionLength;

            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.White;

            string[] anahtarKelimeler = new string[] { };
            if (aktifDil == "C#") anahtarKelimeler = new string[] { "using", "public", "private", "class", "void", "string", "int", "new", "if", "else", "return" };
            else if (aktifDil == "HTML" || aktifDil == "PHP") anahtarKelimeler = new string[] { "<html>", "</html>", "<body>", "</body>", "<div>", "</div>", "<?php", "?>", "echo", "if", "else" };
            else if (aktifDil == "Batch/VBS") anahtarKelimeler = new string[] { "@echo", "off", "pause", "set", "goto", "Dim", "MsgBox", "Sub" };
            else if (aktifDil == "mtext") anahtarKelimeler = new string[] { "@echo", "off", "pause", "set", "goto", "Dim", "MsgBox", "Sub" };

            foreach (string kelime in anahtarKelimeler)
            {
                int indeks = 0;
                int sonBulunan = -1;
                while ((indeks = richTextBox1.Find(kelime, indeks, RichTextBoxFinds.WholeWord)) != -1)
                {
                    if (indeks == sonBulunan) { indeks++; continue; }
                    sonBulunan = indeks;
                    richTextBox1.SelectionStart = indeks;
                    richTextBox1.SelectionLength = kelime.Length;
                    richTextBox1.SelectionColor = Color.Cyan;
                    indeks += kelime.Length;
                }
            }

            richTextBox1.SelectionStart = orijinalKonum;
            richTextBox1.SelectionLength = orijinalUzunluk;
            richTextBox1.SelectionColor = Color.White;
            renklendiriliyor = false;
        }
    }

    public class DarkColorTable : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 45);
        public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 45);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 45);
        public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 45);
        public override Color MenuBorder => Color.FromArgb(35, 35, 35);
        public override Color MenuItemBorder => Color.FromArgb(60, 60, 60);
        public override Color MenuItemSelected => Color.FromArgb(60, 60, 60);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(60, 60, 60);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(60, 60, 60);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(35, 35, 35);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(35, 35, 35);
    }
}
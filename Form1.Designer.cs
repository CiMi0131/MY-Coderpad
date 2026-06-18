//KOD1 (Güncellenmiş)
namespace MY_Coderpad
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            richTextBox1 = new RichTextBox();
            menuStrip1 = new MenuStrip();
            dosyaToolStripMenuItem = new ToolStripMenuItem();
            açToolStripMenuItem = new ToolStripMenuItem();
            kaydetToolStripMenuItem = new ToolStripMenuItem();
            dosyayıÇalıştırToolStripMenuItem = new ToolStripMenuItem();
            çıkışToolStripMenuItem = new ToolStripMenuItem();
            düzenToolStripMenuItem = new ToolStripMenuItem();
            geriAlToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            kesToolStripMenuItem = new ToolStripMenuItem();
            kopyalaToolStripMenuItem = new ToolStripMenuItem();
            yapıştırToolStripMenuItem = new ToolStripMenuItem();
            silToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            bulToolStripMenuItem = new ToolStripMenuItem();
            sonrakiniBulToolStripMenuItem = new ToolStripMenuItem();
            öncekiniBulToolStripMenuItem = new ToolStripMenuItem();
            değiştirToolStripMenuItem = new ToolStripMenuItem();
            gitToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tümünüSeçToolStripMenuItem = new ToolStripMenuItem();
            saatTarihToolStripMenuItem = new ToolStripMenuItem();
            dilToolStripMenuItem = new ToolStripMenuItem();
            cToolStripMenuItem = new ToolStripMenuItem();
            hTMLToolStripMenuItem = new ToolStripMenuItem();
            pHPToolStripMenuItem = new ToolStripMenuItem();
            batchVBSToolStripMenuItem = new ToolStripMenuItem();
            mtextToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(40, 40, 40);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(0, 24);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(800, 426);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(35, 35, 35);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dosyaToolStripMenuItem, düzenToolStripMenuItem, dilToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            dosyaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { açToolStripMenuItem, kaydetToolStripMenuItem, dosyayıÇalıştırToolStripMenuItem, çıkışToolStripMenuItem });
            dosyaToolStripMenuItem.ForeColor = Color.White;
            dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            dosyaToolStripMenuItem.Size = new Size(51, 20);
            dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // açToolStripMenuItem
            // 
            açToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            açToolStripMenuItem.ForeColor = Color.White;
            açToolStripMenuItem.Name = "açToolStripMenuItem";
            açToolStripMenuItem.Size = new Size(154, 22);
            açToolStripMenuItem.Text = "Aç";
            açToolStripMenuItem.Click += açToolStripMenuItem_Click;
            // 
            // kaydetToolStripMenuItem
            // 
            kaydetToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            kaydetToolStripMenuItem.ForeColor = Color.White;
            kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            kaydetToolStripMenuItem.Size = new Size(154, 22);
            kaydetToolStripMenuItem.Text = "Kaydet";
            kaydetToolStripMenuItem.Click += kaydetToolStripMenuItem_Click;
            // 
            // dosyayıÇalıştırToolStripMenuItem
            // 
            dosyayıÇalıştırToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            dosyayıÇalıştırToolStripMenuItem.ForeColor = Color.White;
            dosyayıÇalıştırToolStripMenuItem.Name = "dosyayıÇalıştırToolStripMenuItem";
            dosyayıÇalıştırToolStripMenuItem.Size = new Size(154, 22);
            dosyayıÇalıştırToolStripMenuItem.Text = "Dosyayı Çalıştır";
            dosyayıÇalıştırToolStripMenuItem.Click += dosyayıÇalıştırToolStripMenuItem_Click;
            // 
            // çıkışToolStripMenuItem
            // 
            çıkışToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            çıkışToolStripMenuItem.ForeColor = Color.White;
            çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            çıkışToolStripMenuItem.Size = new Size(154, 22);
            çıkışToolStripMenuItem.Text = "Çıkış";
            çıkışToolStripMenuItem.Click += çıkışToolStripMenuItem_Click;
            // 
            // düzenToolStripMenuItem
            // 
            düzenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { geriAlToolStripMenuItem, toolStripSeparator1, kesToolStripMenuItem, kopyalaToolStripMenuItem, yapıştırToolStripMenuItem, silToolStripMenuItem, toolStripSeparator2, bulToolStripMenuItem, sonrakiniBulToolStripMenuItem, öncekiniBulToolStripMenuItem, değiştirToolStripMenuItem, gitToolStripMenuItem, toolStripSeparator3, tümünüSeçToolStripMenuItem, saatTarihToolStripMenuItem });
            düzenToolStripMenuItem.ForeColor = Color.White;
            düzenToolStripMenuItem.Name = "düzenToolStripMenuItem";
            düzenToolStripMenuItem.Size = new Size(52, 20);
            düzenToolStripMenuItem.Text = "Düzen";
            // 
            // geriAlToolStripMenuItem
            // 
            geriAlToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            geriAlToolStripMenuItem.ForeColor = Color.White;
            geriAlToolStripMenuItem.Name = "geriAlToolStripMenuItem";
            geriAlToolStripMenuItem.Size = new Size(143, 22);
            geriAlToolStripMenuItem.Text = "Geri Al";
            geriAlToolStripMenuItem.Click += geriAlToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(140, 6);
            // 
            // kesToolStripMenuItem
            // 
            kesToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            kesToolStripMenuItem.ForeColor = Color.White;
            kesToolStripMenuItem.Name = "kesToolStripMenuItem";
            kesToolStripMenuItem.Size = new Size(143, 22);
            kesToolStripMenuItem.Text = "Kes";
            kesToolStripMenuItem.Click += kesToolStripMenuItem_Click;
            // 
            // kopyalaToolStripMenuItem
            // 
            kopyalaToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            kopyalaToolStripMenuItem.ForeColor = Color.White;
            kopyalaToolStripMenuItem.Name = "kopyalaToolStripMenuItem";
            kopyalaToolStripMenuItem.Size = new Size(143, 22);
            kopyalaToolStripMenuItem.Text = "Kopyala";
            kopyalaToolStripMenuItem.Click += kopyalaToolStripMenuItem_Click;
            // 
            // yapıştırToolStripMenuItem
            // 
            yapıştırToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            yapıştırToolStripMenuItem.ForeColor = Color.White;
            yapıştırToolStripMenuItem.Name = "yapıştırToolStripMenuItem";
            yapıştırToolStripMenuItem.Size = new Size(143, 22);
            yapıştırToolStripMenuItem.Text = "Yapıştır";
            yapıştırToolStripMenuItem.Click += yapıştırToolStripMenuItem_Click;
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            silToolStripMenuItem.ForeColor = Color.White;
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new Size(143, 22);
            silToolStripMenuItem.Text = "Sil";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(140, 6);
            // 
            // bulToolStripMenuItem
            // 
            bulToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            bulToolStripMenuItem.ForeColor = Color.White;
            bulToolStripMenuItem.Name = "bulToolStripMenuItem";
            bulToolStripMenuItem.Size = new Size(143, 22);
            bulToolStripMenuItem.Text = "Bul...";
            bulToolStripMenuItem.Click += bulToolStripMenuItem_Click;
            // 
            // sonrakiniBulToolStripMenuItem
            // 
            sonrakiniBulToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            sonrakiniBulToolStripMenuItem.ForeColor = Color.White;
            sonrakiniBulToolStripMenuItem.Name = "sonrakiniBulToolStripMenuItem";
            sonrakiniBulToolStripMenuItem.Size = new Size(143, 22);
            sonrakiniBulToolStripMenuItem.Text = "Sonrakini Bul";
            sonrakiniBulToolStripMenuItem.Click += sonrakiniBulToolStripMenuItem_Click;
            // 
            // öncekiniBulToolStripMenuItem
            // 
            öncekiniBulToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            öncekiniBulToolStripMenuItem.ForeColor = Color.White;
            öncekiniBulToolStripMenuItem.Name = "öncekiniBulToolStripMenuItem";
            öncekiniBulToolStripMenuItem.Size = new Size(143, 22);
            öncekiniBulToolStripMenuItem.Text = "Öncekini Bul";
            öncekiniBulToolStripMenuItem.Click += öncekiniBulToolStripMenuItem_Click;
            // 
            // değiştirToolStripMenuItem
            // 
            değiştirToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            değiştirToolStripMenuItem.ForeColor = Color.White;
            değiştirToolStripMenuItem.Name = "değiştirToolStripMenuItem";
            değiştirToolStripMenuItem.Size = new Size(143, 22);
            değiştirToolStripMenuItem.Text = "Değiştir...";
            değiştirToolStripMenuItem.Click += değiştirToolStripMenuItem_Click;
            // 
            // gitToolStripMenuItem
            // 
            gitToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            gitToolStripMenuItem.ForeColor = Color.White;
            gitToolStripMenuItem.Name = "gitToolStripMenuItem";
            gitToolStripMenuItem.Size = new Size(143, 22);
            gitToolStripMenuItem.Text = "Git...";
            gitToolStripMenuItem.Click += gitToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(140, 6);
            // 
            // tümünüSeçToolStripMenuItem
            // 
            tümünüSeçToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            tümünüSeçToolStripMenuItem.ForeColor = Color.White;
            tümünüSeçToolStripMenuItem.Name = "tümünüSeçToolStripMenuItem";
            tümünüSeçToolStripMenuItem.Size = new Size(143, 22);
            tümünüSeçToolStripMenuItem.Text = "Tümünü Seç";
            tümünüSeçToolStripMenuItem.Click += tümünüSeçToolStripMenuItem_Click;
            // 
            // saatTarihToolStripMenuItem
            // 
            saatTarihToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            saatTarihToolStripMenuItem.ForeColor = Color.White;
            saatTarihToolStripMenuItem.Name = "saatTarihToolStripMenuItem";
            saatTarihToolStripMenuItem.Size = new Size(143, 22);
            saatTarihToolStripMenuItem.Text = "Saat/Tarih";
            saatTarihToolStripMenuItem.Click += saatTarihToolStripMenuItem_Click;
            // 
            // dilToolStripMenuItem
            // 
            dilToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cToolStripMenuItem, hTMLToolStripMenuItem, pHPToolStripMenuItem, batchVBSToolStripMenuItem, mtextToolStripMenuItem });
            dilToolStripMenuItem.ForeColor = Color.White;
            dilToolStripMenuItem.Name = "dilToolStripMenuItem";
            dilToolStripMenuItem.Size = new Size(33, 20);
            dilToolStripMenuItem.Text = "Dil";
            // 
            // cToolStripMenuItem
            // 
            cToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            cToolStripMenuItem.ForeColor = Color.White;
            cToolStripMenuItem.Name = "cToolStripMenuItem";
            cToolStripMenuItem.Size = new Size(129, 22);
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem.Click += cToolStripMenuItem_Click;
            // 
            // hTMLToolStripMenuItem
            // 
            hTMLToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            hTMLToolStripMenuItem.ForeColor = Color.White;
            hTMLToolStripMenuItem.Name = "hTMLToolStripMenuItem";
            hTMLToolStripMenuItem.Size = new Size(129, 22);
            hTMLToolStripMenuItem.Text = "HTML";
            hTMLToolStripMenuItem.Click += hTMLToolStripMenuItem_Click;
            // 
            // pHPToolStripMenuItem
            // 
            pHPToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            pHPToolStripMenuItem.ForeColor = Color.White;
            pHPToolStripMenuItem.Name = "pHPToolStripMenuItem";
            pHPToolStripMenuItem.Size = new Size(129, 22);
            pHPToolStripMenuItem.Text = "PHP";
            pHPToolStripMenuItem.Click += pHPToolStripMenuItem_Click;
            // 
            // batchVBSToolStripMenuItem
            // 
            batchVBSToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            batchVBSToolStripMenuItem.ForeColor = Color.White;
            batchVBSToolStripMenuItem.Name = "batchVBSToolStripMenuItem";
            batchVBSToolStripMenuItem.Size = new Size(129, 22);
            batchVBSToolStripMenuItem.Text = "Batch/VBS";
            batchVBSToolStripMenuItem.Click += batchVBSToolStripMenuItem_Click;
            // 
            // mtextToolStripMenuItem
            // 
            mtextToolStripMenuItem.BackColor = Color.FromArgb(45, 45, 45);
            mtextToolStripMenuItem.ForeColor = Color.White;
            mtextToolStripMenuItem.Name = "mtextToolStripMenuItem";
            mtextToolStripMenuItem.Size = new Size(129, 22);
            mtextToolStripMenuItem.Text = "mtext";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MY Coderpad";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dosyaToolStripMenuItem;
        private ToolStripMenuItem açToolStripMenuItem;
        private ToolStripMenuItem kaydetToolStripMenuItem;
        private ToolStripMenuItem çıkışToolStripMenuItem;
        private ToolStripMenuItem dilToolStripMenuItem;
        private ToolStripMenuItem cToolStripMenuItem;
        private ToolStripMenuItem hTMLToolStripMenuItem;
        private ToolStripMenuItem pHPToolStripMenuItem;
        private ToolStripMenuItem batchVBSToolStripMenuItem;
        private ToolStripMenuItem dosyayıÇalıştırToolStripMenuItem;

        // Düzen menüsü bileşenlerinin alan (field) tanımlamaları
        private ToolStripMenuItem düzenToolStripMenuItem;
        private ToolStripMenuItem geriAlToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem kesToolStripMenuItem;
        private ToolStripMenuItem kopyalaToolStripMenuItem;
        private ToolStripMenuItem yapıştırToolStripMenuItem;
        private ToolStripMenuItem silToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem bulToolStripMenuItem;
        private ToolStripMenuItem sonrakiniBulToolStripMenuItem;
        private ToolStripMenuItem öncekiniBulToolStripMenuItem;
        private ToolStripMenuItem değiştirToolStripMenuItem;
        private ToolStripMenuItem gitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tümünüSeçToolStripMenuItem;
        private ToolStripMenuItem saatTarihToolStripMenuItem;
        private ToolStripMenuItem mtextToolStripMenuItem;
    }
}
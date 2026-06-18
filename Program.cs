using System;
using System.IO;
using System.Windows.Forms;

namespace MY_Coderpad
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// </summary>
        [STAThread]
        static void Main(string[] args) // args parametresi eklendi
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Çift tıklanan veya "Birlikte Aç" ile gönderilen dosya yolunu kontrol et
            string baslangicDosyasi = null;
            if (args.Length > 0 && File.Exists(args[0]))
            {
                baslangicDosyasi = args[0];
            }

            // Yakalanan dosya yolunu Form1 constructor'ına (yapıcı metoduna) gönderiyoruz
            Application.Run(new Form1(baslangicDosyasi));
        }
    }
}
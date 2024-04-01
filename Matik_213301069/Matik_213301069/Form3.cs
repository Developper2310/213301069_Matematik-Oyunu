using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Matik_213301069
{
    public partial class Form3 : Form
    {
        public int seviye;
        int sorusayaci = 0;
        int limit = 20;
        bool pas = false;
        Form3Fonksiyonlar f3f = new Form3Fonksiyonlar();
        public Form3(int s)
        {
            seviye = s;
            InitializeComponent();
        }
        public int puan = 0;
        public List<List<string>> sorular = new List<List<string>>();
        public List<string> cevaplar = new List<string>();

        public void TextleriTemizle()
        {
            TB1.Text = string.Empty;
            TB2.Text = string.Empty;
            TB3.Text = string.Empty;
            TB4.Text = string.Empty;
            TB5.Text = string.Empty;
        }
      
        public void CevaplariAl()
        {
            List<System.Windows.Forms.TextBox> boxlar = new List<System.Windows.Forms.TextBox>();
            boxlar.Add(TB1);
            boxlar.Add(TB2);
            boxlar.Add(TB3);
            boxlar.Add(TB4);
            boxlar.Add(TB5);
            for (int i = 0; i < boxlar.Count; i++)
            {
                try
                {
                    int result = Convert.ToInt32(boxlar[i].Text);
                    cevaplar.Add(boxlar[i].Text);

                }
                catch 
                {
                    Console.WriteLine("Dönüştürme başarısız. Geçersiz sayı formatı.");
                    boxlar[i].Text = "0";
                    cevaplar.Add(boxlar[i].Text);
               
                }
            }

            TextleriTemizle();
        }
        
        public void SkoruKaydet(int s)
        {
            string klasorYolu = Path.Combine(Application.StartupPath, "Data");
            string skor = Path.Combine(klasorYolu, "Skor Tablosu.txt");
            using (StreamWriter sw = File.Exists(skor) ? File.AppendText(skor) : File.CreateText(skor))
            {

                DateTime now = DateTime.Now;
                sw.WriteLine(seviye + ". Seviye de " + s + " doğru cevap  " + now);
                sw.Close();
            }
        }
        public void YildizlariKaydet(int yildiz, int seviye)
        {
            string klasorYolu = Path.Combine(Application.StartupPath, "Data");
            string yildizYolu = Path.Combine(klasorYolu, "YıldızBilgileri.txt");

            try
            {
                string[] satirlar = File.ReadAllLines(yildizYolu);

                if (satirlar.Length >= seviye)
                {
                    satirlar[seviye - 1] = yildiz.ToString();
                    File.WriteAllLines(yildizYolu, satirlar);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu : " + ex);
            }

        }

        public void IziniKaydet(int seviye)
        {

            string klasorYolu = Path.Combine(Application.StartupPath, "Data");
            string izinYolu = Path.Combine(klasorYolu, "izinBilgileri.txt");
            try
            {

                string[] satirlar = System.IO.File.ReadAllLines(izinYolu);

                satirlar[seviye-1] = true.ToString();
                System.IO.File.WriteAllLines(izinYolu, satirlar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
        public void BitirveKaydet()
        {
            int dogruCevapSayisi = 0;
            int yildiz = 0;
            for (int i = 0; i < limit; i++)
            {
                bool k = f3f.Kontrolcü(sorular[i], cevaplar[i]);
                if (k == true) dogruCevapSayisi++;
            }
            SkoruKaydet(dogruCevapSayisi);
            if (dogruCevapSayisi > 10) yildiz = 1;
            if (dogruCevapSayisi > 15) yildiz = 2;
            if (dogruCevapSayisi > 18) yildiz = 3;

            if (yildiz >= 1) IziniKaydet(seviye);
            YildizlariKaydet(yildiz, seviye);

            this.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

            this.Text = seviye + ". Seviye";
            f3f.OrtayaYaz(TB1);
            f3f.OrtayaYaz(TB2);
            f3f.OrtayaYaz(TB3);
            f3f.OrtayaYaz(TB4);
            f3f.OrtayaYaz(TB5);
            sorular = f3f.SeviyeSorularıUret(this, seviye);
            LabelAtamalari(sorular, sorusayaci);


        }

        private void SS_Click(object sender, EventArgs e)
        {
            sorusayaci = sorusayaci + 5;
            if (sorusayaci >= 20 && pas == false || sorusayaci >= 25 && pas == true)
            {
                CevaplariAl();
                BitirveKaydet();
            }
            else
            {

                CevaplariAl();
                LabelAtamalari(sorular, sorusayaci);
                if (sorusayaci >= 15 && pas == false || sorusayaci >= 20 && pas == true)
                {
                    SS.Text = "Bitir";
                }
            }
        }

        private void A2_Click(object sender, EventArgs e)
        {

        }

        private void B1_Click(object sender, EventArgs e)
        {

        }

        private void TB1_TextChanged(object sender, EventArgs e)
        {
            f3f.IntKarakterOlsun(TB1);
        }
        public void LabelAtamalari(List<List<string>> sorular, int y)
        {

            A1.Text = sorular[y][0];
            O1.Text = sorular[y][1];
            B1.Text = sorular[y][2];
            A2.Text = sorular[y + 1][0];
            O2.Text = sorular[y + 1][1];
            B2.Text = sorular[y + 1][2];
            A3.Text = sorular[y + 2][0];
            O3.Text = sorular[y + 2][1];
            B3.Text = sorular[y + 2][2];
            A4.Text = sorular[y + 3][0];
            O4.Text = sorular[y + 3][1];
            B4.Text = sorular[y + 3][2];
            A5.Text = sorular[y + 4][0];
            O5.Text = sorular[y + 4][1];
            B5.Text = sorular[y + 4][2];


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TB4_TextChanged(object sender, EventArgs e)
        {
            f3f.IntKarakterOlsun(TB4);
        }

        private void O1_Click(object sender, EventArgs e)
        {

        }

        private void O3_Click(object sender, EventArgs e)
        {

        }

        private void TB2_TextChanged(object sender, EventArgs e)
        {
            f3f.IntKarakterOlsun(TB2);
        }

        private void TB3_TextChanged(object sender, EventArgs e)
        {
            f3f.IntKarakterOlsun(TB3);
        }

        private void TB5_TextChanged(object sender, EventArgs e)
        {

            f3f.IntKarakterOlsun(TB5);
        }

        private void Pas_Click(object sender, EventArgs e)
        {
           
                if (!pas)
                {
                    limit = 25;
                    pas = true;
                    TextleriTemizle();
                    for (int i = sorusayaci; i < sorusayaci + 5; i++)
                    {
                        sorular.Add(sorular[i]);

                    }
                    sorusayaci = sorusayaci + 5;


                    CevaplariAl();
                    LabelAtamalari(sorular, sorusayaci);
                    Pas.Text = "Pas (Hakkınız Tükendi)";

                }
                else if(sorusayaci<20)
                {
                    sorusayaci = sorusayaci + 5;
                    TextleriTemizle();
                    CevaplariAl();
                    LabelAtamalari(sorular, sorusayaci);
                }
                
            
        }
     
    }
}

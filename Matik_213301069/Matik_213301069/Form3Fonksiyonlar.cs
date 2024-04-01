using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Matik_213301069
{
   
    class Form3Fonksiyonlar
    {
        public List<List<string>> SeviyeSorularıUret(Form3 form3,int s)
        {
            List<List<string>> Sorular=new List<List<string>>();
            Random rastgele = new Random();
            for(int i=0; i < 20; i++)
            {
                Sorular.Add(SoruOlusturucu(s,form3));
            }


            return Sorular;
        }
        public List<string> SoruOlusturucu(int s,Form3 form3)
        {
            List<string> soru = new List<string>();
            Random random = new Random();  
            int p =random.Next(1,s+1);
            bool sec = random.Next(0, 2) == 0;
            switch (p)
            {
                case 1:
                    soru = ToplamaSorusuOlustur(s);
                    break;
                case 2:

                    soru = CikarmaSorusuOlustur(s);
                    break;
                case 3:
                    
                    soru = sec ? CarpmaSorusuOlustur(s) : BolmeSorusuOlustur(s);
                    break;
                case 4:
                    
                    soru =sec ? CarpmaSorusuOlustur(s) : BolmeSorusuOlustur(s) ;
                    break;
                case 5:
                    soru = sec ? CarpmaSorusuOlustur(s) : BolmeSorusuOlustur(s);
                    break;
                    
                default:
                    MessageBox.Show("Yükleme Hatası: " , "Sorular oluşturulamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        form3.Close();
                    break;
            }
            return soru;
        }

        public List<string> ToplamaSorusuOlustur(int s)
        {
            List<string> toplama=new List<string>();
            Random rastgele = new Random();
            string a = rastgele.Next(1, (int)Math.Pow(10, s)).ToString();
            string o = "+";
            string b = rastgele.Next(1, (int)Math.Pow(10, s)).ToString();
            toplama.Add(a);
            toplama.Add(o);
            toplama.Add(b); 
            return toplama;
        }
        public List<string> CikarmaSorusuOlustur(int s)
        {
            List<string> cıkarma = new List<string>();
            Random rastgele = new Random();
            string a = rastgele.Next(1, (int)Math.Pow(10, s)).ToString();
            string o = "-";
            string b = rastgele.Next(1, int.Parse(a)).ToString();
            cıkarma.Add(a);
            cıkarma.Add(o);
            cıkarma.Add(b);
            return cıkarma;
        }
        public List<string> CarpmaSorusuOlustur(int s)
        {
            List<string> carpma = new List<string>();
            Random rastgele = new Random();
            int c = rastgele.Next(1, 2* s);
            string a = rastgele.Next(1, (int)Math.Pow(c, s-1)).ToString();
            string o = "X";
            string b = rastgele.Next(1, (int)Math.Pow(c, s - 2)).ToString();
            carpma.Add(a);
            carpma.Add(o);
            carpma.Add(b);
            return carpma;
        }
        public List<string> BolmeSorusuOlustur(int s)
        {
            List<string> bolme = new List<string>();
            Random rastgele = new Random();
            string a = rastgele.Next(10, (int)Math.Pow(10, s-1)).ToString();
            string o = "÷";
            string b = (int.Parse(a)*rastgele.Next(1, 10 * s)).ToString();
            bolme.Add(b);
            bolme.Add(o);
            bolme.Add(a);
            return bolme;
        }
        public void OrtayaYaz(TextBox textBox)
        {
            int paddingTop = (textBox.Height - (int)textBox.Font.GetHeight()) / 2;
            textBox.Multiline = true;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Padding = new Padding(0, paddingTop, 0, 0);
            textBox.Font = new Font("Arial", 20);
        }

        public bool Kontrolcü(List<string> soru,string cevap)
        {
            bool sonuc;
            switch (soru[1]) { 
                case "+":
                    sonuc= ToplamaKontrol(soru, cevap);
                    break;
                case "-":
                    sonuc = CikarmaKontrol(soru, cevap);
                    break; 
                case "X":
                    sonuc = CarpmaKontrol(soru, cevap);
                    break; 
                case "÷":
                    sonuc= BolmeKontrol(soru,cevap);
                    break;
                    default:
                     MessageBox.Show("Hata", "Hata ile karşılaşıldı lütfen testi tekrar yapın");
                    Form3 form3 = new Form3(0);
                    form3.Close();
                    return false;
                    break;
            }
            return sonuc;
        }
        public bool CarpmaKontrol(List<string> soru,string cevap)
        {
            if (int.Parse(soru[0]) * int.Parse(soru[2]) == int.Parse(cevap))return true;
            else return false;  
        }
        public bool ToplamaKontrol(List<string> soru, string cevap) 
        {
            if (int.Parse(soru[0]) + int.Parse(soru[2]) == int.Parse(cevap)) return true;
            else return false;
        }
        public bool CikarmaKontrol(List<string> soru, string cevap)
        {
            if (int.Parse(soru[0]) - int.Parse(soru[2]) == int.Parse(cevap)) return true;
            else return false;
        }

        public bool BolmeKontrol(List<string> soru, string cevap)
        {
            if (int.Parse(soru[0]) / int.Parse(soru[2]) == int.Parse(cevap)) return true;
            else return false;
        }

        public void IntKarakterOlsun(TextBox textBox1)
        {
            if (!int.TryParse(textBox1.Text, out int result))
            {
                // Eğer metin bir sayı değilse, son değişikliği geri al
                textBox1.Text = textBox1.Text.Length > 1 ? textBox1.Text.Substring(0, textBox1.Text.Length - 1) : "";
            }
        }
       

    }
}

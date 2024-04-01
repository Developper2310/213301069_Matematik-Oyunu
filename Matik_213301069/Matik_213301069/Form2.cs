using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Matik_213301069
{
    
    public partial class Form2 : Form
    {
        public bool izin2 = false;
        public bool izin3 = false;
        public bool izin4 = false;
        public bool izin5 = false;

        public int yildiz1 = 0;
        public int yildiz2 = 0;
        public int yildiz3 = 0;
        public int yildiz4 = 0;
        public int yildiz5 = 0;

        Form2Fonksiyonlar f2f = new Form2Fonksiyonlar();


        public void BastanIzınOlustur(StreamWriter sw)
        {
            sw.Write(string.Empty);
            IzinOlustur(sw);
        }
        public void YildizOlustur(StreamWriter sw)
        {
            sw.WriteLine(yildiz1.ToString());
            sw.WriteLine(yildiz2.ToString());
            sw.WriteLine(yildiz3.ToString());
            sw.WriteLine(yildiz4.ToString());
            sw.WriteLine(yildiz5.ToString());
            sw.Close();
        }
        public void BastanYildizOlustur(StreamWriter sw)
        {
            sw.Write(string.Empty);
            YildizOlustur(sw);
        }
        public void IzinOlustur(StreamWriter sw)
        {
            sw.WriteLine(izin2.ToString());
            sw.WriteLine(izin3.ToString());
            sw.WriteLine(izin4.ToString());
            sw.WriteLine(izin5.ToString());
            sw.Close();
        }
        public void YildizlariAta(string yildizYolu)
        {
            using (StreamReader sr = File.OpenText(yildizYolu))
            {
                if (int.TryParse(sr.ReadLine(), out yildiz1)) ;
                if (int.TryParse(sr.ReadLine(), out yildiz2)) ;
                if (int.TryParse(sr.ReadLine(), out yildiz3)) ;
                if (int.TryParse(sr.ReadLine(), out yildiz4)) ;
                if (int.TryParse(sr.ReadLine(), out yildiz5)) ;
                sr.Close();
            }
        }
        public void IzinleriAta(string izinYolu)
        {
            using (StreamReader sr = File.OpenText(izinYolu))
            {
                // Satır satır oku ve bool değerlere çevir
                if (bool.TryParse(sr.ReadLine(), out izin2)) ;


                if (bool.TryParse(sr.ReadLine(), out izin3)) ;


                if (bool.TryParse(sr.ReadLine(), out izin4)) ;


                if (bool.TryParse(sr.ReadLine(), out izin5)) ;
                sr.Close();
            }
        }

        public void LabelKontrol()
        {
            List<bool> izinler = new List<bool>();
            List<Label> labels = new List<Label>();
            izinler.Add(izin2);
            izinler.Add(izin3);
            izinler.Add(izin4);
            izinler.Add(izin5);
            labels.Add(L2);
            labels.Add(L3);
            labels.Add(L4);
            labels.Add(L5);
            for (int i = 0; i < labels.LongCount(); i++)
            {
                if (izinler[i] == false)
                {
                    int a = i + 1;
                    labels[i].Text = "KİLİTLİ   Açmak için " + a + ". Seviyeyi tamamlayın";
                    labels[i].ForeColor = Color.Red;
                }

            }

        }


        public void IzinKontrol(string izinyolu)
        {
            using (StreamWriter sw = File.Exists(izinyolu) ? File.AppendText(izinyolu) : File.CreateText(izinyolu))
            {
                if (new FileInfo(izinyolu).Length == 0)
                {
                    BastanIzınOlustur(sw);
                }

                sw.Close();
                IzinleriAta(izinyolu);
            }
        }

        public void YildizKontrol(string yildizYolu)
        {
            using (StreamWriter sw = File.Exists(yildizYolu) ? File.AppendText(yildizYolu) : File.CreateText(yildizYolu))
            {
                if (new FileInfo(yildizYolu).Length == 0)
                {
                    BastanYildizOlustur(sw);
                }

                sw.Close();
                YildizlariAta(yildizYolu);
            }
        }

        public void YildizlariAyarla()
        {
            List<int> yildizlar = new List<int>();
            List<GroupBox> groups = new List<GroupBox>();
            yildizlar.Add(yildiz1);
            yildizlar.Add(yildiz2);
            yildizlar.Add(yildiz3);
            yildizlar.Add(yildiz4);
            yildizlar.Add(yildiz5);


            foreach (Control box in groupBox6.Controls)
            {
                if (box is GroupBox)
                {
                    groups.Add(box as GroupBox);
                }

            }
            groups = groups.OrderBy(pb => pb.Location.Y).ToList();

            for (int i = 0; i < yildizlar.Count; i++)
            {

                YildizaCevir(groups[i], yildizlar[i]);

            }

        }
        public void YildizaCevir(GroupBox box, int s)
        {
            List<PictureBox> pbs = new List<PictureBox>();

            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images\\yıldız7.jpg");


            foreach (Control control in box.Controls)
            {
                if (control is PictureBox)
                {
                    pbs.Add((PictureBox)control);
                }
            }
            pbs = pbs.OrderBy(pb => pb.Location.X).ToList();
            for (int i = 0; i < s; i++)
            {

                pbs[i].Image = Image.FromFile(imagePath);
                pbs[i].SizeMode = PictureBoxSizeMode.Zoom;
            }




        }


        public Form2()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string klasorYolu = Path.Combine(Application.StartupPath, "Data");

            string izinYolu = Path.Combine(klasorYolu, "izinBilgileri.txt");

            string yildizYolu = Path.Combine(klasorYolu, "YıldızBilgileri.txt");
            if (!Directory.Exists(klasorYolu))
            {
                try { Directory.CreateDirectory(klasorYolu); }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            IzinKontrol(izinYolu);
            YildizKontrol(yildizYolu);
            LabelKontrol();
            YildizlariAyarla();


        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void B2_Click(object sender, EventArgs e)
        {
            f2f.SeviyeKontrol(this, izin2, 2);

        }

        private void B3_Click(object sender, EventArgs e)
        {
            f2f.SeviyeKontrol(this, izin3, 3);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            f2f.SeviyeKontrol(this, izin4, 4);
        }

        private void B5_Click(object sender, EventArgs e)
        {
            f2f.SeviyeKontrol(this, izin5, 5);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            f2f.Form3Ac(this, 1);
        }

        private void S1P1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void Sıfırla_Click(object sender, EventArgs e)
        {
            

        }
    }
}

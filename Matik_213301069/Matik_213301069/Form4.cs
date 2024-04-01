using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matik_213301069
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Dosya yolu
            string klasorYolu = Path.Combine(Application.StartupPath, "Data");
            string skor = Path.Combine(klasorYolu, "Skor Tablosu.txt");

            try
            {
                // Dosyadaki tüm satırları oku
                string[] satirlar = System.IO.File.ReadAllLines(skor);

                for (int i = 0; i < satirlar.Length; i++)
                {
                    // Her bir satır için yeni bir ListViewItem öğesi oluştur
                    ListViewItem item = new ListViewItem();

                    // Satırdaki tüm metni ListViewItem öğesine ekle
                    item.Text = satirlar[i];

                    // ListView'a öğeyi ekle
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}

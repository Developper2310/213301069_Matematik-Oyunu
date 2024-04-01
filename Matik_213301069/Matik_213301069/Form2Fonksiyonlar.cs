using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matik_213301069
{
 class Form2Fonksiyonlar
    {
        
      public void SeviyeKontrol(Form2 form2,bool izin,int s)
        {
            if (izin)
            {
               Form3Ac(form2,s);
            }
            else
            {
                Console.WriteLine("Kilitli Seviye", "bölümü açmak için lütfen bir önceki bölümü tamamlayın");
            }
        }
        public void Form3Ac(Form2 form2, int s)
        {
            Form3 form3 = new Form3(s);
            form3.Show();
            form3.FormClosed += (s, args) => { form2.Show(); };
            form2.Hide();
        }

    }
}

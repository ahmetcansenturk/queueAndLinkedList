using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ahmetcansenturk_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class yapi
        {
            public string islem;

            public yapi onceki;
            public yapi sonraki;

            public yapi(string p)
            {
                islem = p;
            }
            public yapi()
            { }
        } 
     
        /// 
       
        public class KUYRUK
        {
            public yapi ilk;
            public yapi son;

            public Boolean isempty()
            {


                return ilk == null;
            } 


            public void Enqueue(string p)
            {
                yapi yeniurun = new yapi(p);
                if (isempty())
                {
                    ilk = yeniurun;
                    son = yeniurun;
                    son.sonraki = null;

                }
                else
                {

                    ilk.onceki = yeniurun;
                    yeniurun.sonraki = ilk;
                    ilk = yeniurun;




                }


            }
            public yapi Dequeue()
            {
                yapi aktif = son;
                if (ilk.sonraki == null)
                    ilk = null;
                else
                    son.onceki.sonraki = null;
                son = son.onceki;
                return aktif;
            }
        }




        ////
        public class YIGIN
        {
            public yapi ilk;
            public yapi son;

            public Boolean isempty()
            {


                return ilk == null;
            }


            public void push(string p)
            {
                yapi yeniurun = new yapi(p);
                if (isempty())
                {
                    ilk = yeniurun;
                    son = yeniurun;
                    son.sonraki = null;

                }
                else
                {

                    son.sonraki = yeniurun;
                    yeniurun.onceki = son;
                    son = yeniurun;
                    son.sonraki = null;



                }
            }
            public yapi pop()
            {
                yapi aktif = son; 
                if (aktif != null)
                {

             
                if (ilk.sonraki == null)
                    ilk = null;
                else
                    son.onceki.sonraki = null;
                son = son.onceki;
                }
                return aktif;
          
            }
        }
        ///
        public string proses1() {
        
            string olusturlan;
            string kalip = "p1-";

            olusturlan = kalip+rnd.Next(0,5).ToString();
  
            pr1.Enqueue(olusturlan);



            return olusturlan;
        }
        public string proses2()
        {

            string olusturlan;
            string kalip = "p2-";

            olusturlan = kalip + rnd.Next(0, 5).ToString();

            pr2.Enqueue(olusturlan);



            return olusturlan;
        }
        public string proses3()
        {

            string olusturlan;
            string kalip = "p3-";

            olusturlan = kalip + rnd.Next(0, 5).ToString();
            pr3.Enqueue(olusturlan);



            return olusturlan;
        }
        public void listele(YIGIN y)
        {
       
            while (y.ilk != null)
            {
                listBox1.Items.Add(y.ilk.islem);

                y.ilk = y.ilk.sonraki;
                
            }


        }
        ///

        Random rnd = new Random();

        YIGIN bitenPr2 = new YIGIN();
        YIGIN bitenPr3 = new YIGIN();
        YIGIN bitenPr1 = new YIGIN();

        KUYRUK pr1 = new KUYRUK();
        KUYRUK pr2 = new KUYRUK();
        KUYRUK pr3 = new KUYRUK();
        KUYRUK kuyruk = new KUYRUK();

        // takip edilebilmek için kullandım 

        int sayac1 = 0;
        int sayac2 = 0;
        int sayac3 = 0;


      

        ///

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval / trackBar2.Value;
            timer4.Interval = timer4.Interval / trackBar1.Value;
            timer4.Start();
            timer1.Start();

            timer2.Interval = timer2.Interval / trackBar3.Value;
            timer2.Start();

            timer3.Interval = timer3.Interval / trackBar4.Value;
            timer3.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //üretici1
            p1.Items.Add(proses1());
            sayac1++;
            if (sayac1==10)
            {
                timer1.Stop();
            }
       
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //üretici2
            p2.Items.Add(proses2());
            sayac2++;
            if (sayac2 == 10)
            {
                timer2.Stop();
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            //üretici3
            p3.Items.Add(proses3());
            sayac3++;
            if (sayac3 == 10)
            {
                timer3.Stop();
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            //işlemci
            string islem1 = "-1";
            string islem2 = "-1";
            string islem3 = "-1";
            string islem11 = " ";
            string islem22 = " ";
            string islem33 = " ";
            if (pr1.son != null)
            {
                islem1 = pr1.son.islem[pr1.son.islem.Length - 1].ToString();
                islem11 = pr1.son.islem;
            }
            if (pr2.son != null)
            {

                islem2 = pr2.son.islem[pr2.son.islem.Length - 1].ToString();
                islem22 = pr2.son.islem;
            }
            if (pr3.son != null)
            {
                islem3 = pr3.son.islem[pr3.son.islem.Length - 1].ToString();
                islem33 = pr3.son.islem;
            }

        


            if (Convert.ToInt32(islem1) > Convert.ToInt32(islem2) && Convert.ToInt32(islem1) > Convert.ToInt32(islem3))
            {
    
                if (pr1.son != null)
                {
                    pr1.Dequeue();
                    bitenPr1.push(islem11);
                }
             
                textBox1.Text += "->" + islem11;


            }
            else if (Convert.ToInt32(islem2) > Convert.ToInt32(islem1) && Convert.ToInt32(islem2) > Convert.ToInt32(islem3))
            {
                if (pr2.son != null)
                {
                    pr2.Dequeue();
                    bitenPr2.push(islem22);
                }
  
                textBox1.Text += "->" + islem22;

            }
            else if (Convert.ToInt32(islem3) > Convert.ToInt32(islem1) && Convert.ToInt32(islem3) > Convert.ToInt32(islem2))
            {
                if (pr3.son != null)
                {
                    pr3.Dequeue();
                    bitenPr3.push(islem33);
                }

                textBox1.Text += "->" + islem33;
            }

            else if (Convert.ToInt32(islem3) == Convert.ToInt32(islem1) && Convert.ToInt32(islem3) == Convert.ToInt32(islem2))
            {

        
                if (pr1.son != null && pr2.son != null && pr3.son != null)
                {
                    pr1.Dequeue(); pr2.Dequeue(); pr3.Dequeue();
                    bitenPr1.push(islem11); bitenPr2.push(islem22); bitenPr3.push(islem33);

                }
                textBox1.Text += "->" + islem33 + "->" + islem22 + "->" + islem11;
            }

            else if (Convert.ToInt32(islem3) == Convert.ToInt32(islem1))
            {


                if (pr1.son != null && pr2.son != null)
                {
                    pr1.Dequeue(); pr3.Dequeue();
                    bitenPr1.push(islem11); bitenPr3.push(islem33); 
                }
                textBox1.Text += "->" + islem33 + "->" + islem11;

            }
            else if (Convert.ToInt32(islem3) == Convert.ToInt32(islem2))
            {


          
                if (pr2.son != null && pr3.son != null)
                {
                    pr2.Dequeue(); pr3.Dequeue();
               bitenPr2.push(islem22); bitenPr3.push(islem33);
                }
                textBox1.Text += "->" + islem22 + "->" + islem33;
            }
            else if (Convert.ToInt32(islem2) == Convert.ToInt32(islem1))
            {


        
                if (pr1.son != null && pr2.son != null)
                {
                    pr1.Dequeue(); pr2.Dequeue();
                    bitenPr1.push(islem11); bitenPr2.push(islem22); 
                }
                textBox1.Text += "->" + islem22 + "->" + islem11;
            }











        }
        private void button2_Click(object sender, EventArgs e)
        {
       
           
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();

        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                listele(bitenPr1);
                listBox1.Items.Add("--");
            }
          if (checkBox2.Checked)
            {
                listele(bitenPr2);
                listBox1.Items.Add("--");
            }
           if (checkBox3.Checked)
            {
                listele(bitenPr3);
                listBox1.Items.Add("--");
            }
            if (!(checkBox1.Checked) && !(checkBox2.Checked) && !(checkBox3.Checked))
         
            {
                MessageBox.Show("Lütfen En Az Bir Prosesi Seçiniz");

            }
        }

        // 
        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }


        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }






    }
}

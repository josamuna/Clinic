using System;
using System.Diagnostics;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class Loading : Form
    {
        int t;
        string s;
        public Loading()
        {
            InitializeComponent();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            t++;
            s = t.ToString(); label2.Text = s;
            label1.Image = (System.Drawing.Bitmap)(GestionClinic_WIN.Properties.Resources.ResourceManager.GetObject(s));
            if (t == 58) 
            {
                this.Hide();
                frmMainMenu frm = new frmMainMenu();
                frm.Show();
            }

            //if (t == (t1*1800))
            //{
            //    t1++;
            //    //Console.WriteLine("Rafraichissement avec t={0} et t1={1}",t,t1);
            //    try
            //    {
            //        clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            //    }
            //    catch { }
            //    //Console.WriteLine("La valeur actuelle de t = " + t);
            //}
        }
    }
}

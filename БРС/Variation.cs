using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace БРС
{
    public partial class Variation : Form
    {
        public Variation()
        {
            InitializeComponent();
        }               
        private void pictureBox2_Click(object sender, EventArgs e)//переходит на форму авторизации в случае нажатия на картинку 
        {
            Login frm2 = new Login();
            frm2.Show();
            this.Hide();
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)//переходит на форму авторизации в случае нажатия на картинку 
        {
            Login frm2 = new Login();
            frm2.Show();
            this.Hide();
        }
        Point lastPoint;
        private void Variation_MouseMove(object sender, MouseEventArgs e)//этот и последующий метод необходим для возможности двигать форму при работе приложения 
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Variation_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

       
    }
}

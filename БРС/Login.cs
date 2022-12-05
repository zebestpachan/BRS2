using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//привет, как дела?
namespace БРС
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.passField.AutoSize = false; //данная и следующая строка выравнивают поле ввода пароля и дают возможность замаскировать его точками
            this.passField.Size = new Size(this.passField.Size.Width, 64);
        }       
         
        private void closeButton_Click(object sender, EventArgs e)//метод описывающий действия кнопки выключения при авторизации 
        {
            Application.Exit();
        }
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)// метод для возможности двигать окно 
        {
            if(e.Button== MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)// устанавливаем координаты , чтобы работал предидущий метод 
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Variation frm2 = new Variation();
            frm2.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = loginField.Text;// записывает в переменную знчанеие с поля логин 
            String passUser = passField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @uL AND `pass`= @uP",db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                MainForm frm2 = new MainForm();
                frm2.Show();
               
            }    
            else
                MessageBox.Show("No");


        }

        private void button1_Click(object sender, EventArgs e)//при нажатии на кнопку регистрация перейдем на соотв. форму
        {
            this.Hide();
            RegisterForm form2 = new RegisterForm();
            form2.Show();
        }
    }
}

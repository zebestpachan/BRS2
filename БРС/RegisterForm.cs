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

namespace БРС
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            userNameField.Text = "Введите имя";//всплывающий текст в окнах регистрации 
            userNameField.ForeColor = Color.Gray;
            userSurnameField.Text = "Введите фамилию";
            userSurnameField.ForeColor = Color.Gray;
            loginField.Text = "Введите логин";
            loginField.ForeColor = Color.Gray;
            passField.Text = "Введите пароль";
            passField.ForeColor = Color.Gray;

        }

        private void closeButton_Click(object sender, EventArgs e)// придание функционала значку выхода 
        {
            Application.Exit();
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)// для движения окна регистрации 
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)// для работы прошлого метода 
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void userNameField_Enter(object sender, EventArgs e)// прописано что будет с текстом в поле ,если мы на него навелись (текст в поле исчезнет)
        {
            if (userNameField.Text == "Введите имя")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)//прописано о появление в поле текста , если мы ничего не написали 
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите имя";
                userNameField.ForeColor = Color.Gray;
            }

        }

        

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите логин")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Введите логин";
                loginField.ForeColor = Color.Gray;
            }

        }

        private void userSurnameFiled_Enter(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "Введите фамилию")
            {
                userSurnameField.Text = "";
                userSurnameField.ForeColor = Color.Black;
            }
        }

        private void userSurnameFiled_Leave(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
            {
                userSurnameField.Text = "Введите фамилию";
                userSurnameField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter_1(object sender, EventArgs e)
        {
            if (passField.Text == "Введите пароль")
            {
                passField.Text = "";
                passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave_1(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.Text = "Введите пароль";
                passField.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)//переход на другую форму в случае нажатия на кнопку
        {
            Login frm2 = new Login();
            frm2.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)// если пользователь не ввел какую-либо сроку выдаст ошибку 
        {
            if(userNameField.Text =="Введите имя")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (userSurnameField.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (loginField.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (passField.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (isUserExists())
                return;

            //далее проверяем есть ли такой аккаунт у нас в БД
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` ( `login`, `pass`, `name`, `surname`) VALUES (@login, @pass, @name,@surname);",db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurnameField.Text;

            db.openConnection();
            //если такие данные есть , то выдаст следующее:
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");

            db.closeConnection();

            

        }

        public Boolean isUserExists()//метод для недопущения создания повторных паролей 
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @uL ", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;
            

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("такой логин уже есть, введите другой");
                return true;
            }
            else
                return false;

        }

       
    }
}

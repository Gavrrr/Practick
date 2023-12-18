using carservice.config;
using carservice.controller;
using carservice.controller.admin;
using carservice.model;
using carservice.repository;
using carservice.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace carservice
{
    public partial class Login : Form
    {
        private static Session session = new Session(false);
        private UserServiseImpl userServise = new UserServiseImpl();
        internal static Session Session { get => session; set => session = value; }
        private int countInput = 0;
        private string text = String.Empty;
        private bool capcha = false;
        private bool end = false;
        UserRepository userRepository = new UserRepository();
        public Login()
        {
            InitializeComponent();
            Loging.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //pictureBox1.Image = CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void LoginEnable()
        {
            if (userNameField.Text.Length > 0 && passwordField.Text.Length > 0)
            {
                Loging.Enabled = true;
            }
            else
            {
                Loging.Enabled = false;
            }
        }
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);

            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((System.Drawing.Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));
            ////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
           

            if (end)
            {
                return;
            }
            User currentUser = userRepository.findUserByUserName(userNameField.Text);
            if (currentUser == null)
            {
                MessageBox.Show("Не верный логин");
                return;
            }

            if (countInput > 0 && countInput < 3 && !capcha)
            {
                if (textBox3.Text == this.text)
                {
                    MessageBox.Show("Верно!");
                    capcha = true;
                    if (currentUser.Password.Equals(passwordField.Text))
                    {
                        controller.admin.StartForm startForm = new controller.admin.StartForm();
                        Session.setSession(currentUser, this);
                        startForm.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Ошибка!");
                    capcha = false;
                    countInput++;
                }
                pictureBox1.Image = CreateImage(pictureBox1.Width, pictureBox1.Height);
                return;
            }

            if (countInput == 3 && !capcha)
            {
                if (textBox3.Text == this.text)
                {
                    MessageBox.Show("Верно!");
                    capcha = true;
                    if (currentUser.Password.Equals(passwordField.Text))
                    {
                        controller.admin.StartForm startForm = new controller.admin.StartForm();
                        Session.setSession(currentUser, this);
                        startForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                    capcha = false;
                    countInput++;
                }
                MessageBox.Show("Приложение заблокировано на 3 минуты");
                Thread.Sleep(180000);
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                return;
            }

            if (countInput == 3 && !capcha)
            {
                if (textBox3.Text == this.text)
                {
                    MessageBox.Show("Верно!");
                    capcha = true;
                    controller.admin.StartForm startForm = new controller.admin.StartForm();
                    Session.setSession(currentUser, this);
                    startForm.Show();
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                    end = true;
                    countInput++;
                }
                MessageBox.Show("Приложение заблокировано до перезапуска");
                return;
            }

            if (!currentUser.Password.Equals(passwordField.Text))
            {
                MessageBox.Show("Не верный пароль");
                countInput++;
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
            }

            if (currentUser.Password.Equals(passwordField.Text))
            {
                controller.admin.StartForm startForm = new controller.admin.StartForm();
                Session.setSession(currentUser, this);
                startForm.Show();
            }


        }

        private void registration_Click(object sender, EventArgs e)
        {
            RegistrationForm registration = new RegistrationForm();
            registration.Show();
            Session.FormLogin = this;
            this.Visible = false;
        }

        private void userNameField_TextChanged(object sender, EventArgs e)
        {
            LoginEnable();
        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {
            LoginEnable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

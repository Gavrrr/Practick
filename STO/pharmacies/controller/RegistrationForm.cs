﻿using carservice.config;

using carservice.model;
using carservice.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carservice.controller
{
    public partial class RegistrationForm : Form
    {
        UserServiseImpl userServise = new UserServiseImpl();

        public RegistrationForm()
        {
            InitializeComponent();

            registration.Enabled = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void registrationEnable()
        {
            if (userNameField.Text.Length > 0 && passwordField.Text.Length > 0)
            {
                registration.Enabled = true;
            }
            else
            {
                registration.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            registrationEnable();
        }

        private void roleField_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = '\0';
        }

        private void userNameField_TextChanged(object sender, EventArgs e)
        {
            registrationEnable();
        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {
            registrationEnable();
        }

        private void registration_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = userNameField.Text;
            user.Password = passwordField.Text;

            if (userServise.saveUser(user))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует!");
            }
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.Session.FormLogin.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}



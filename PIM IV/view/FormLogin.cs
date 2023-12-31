﻿using PIM_IV.control;
using PIM_IV.model;
using PIM_IV.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PIM_IV
{

    public partial class FormLogin : Form
    {

        //variaveis da tela de login
        string comNome, comPassword;
        
        public FormLogin()
        {
            CreateDataBase init = new CreateDataBase();
            init.VerificaDB();
            InitializeComponent();

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            comNome = txtBoxLogin.Text;
            comPassword = txtBoxPassword.Text;
            Login init = new Login();
            CrudUser check = new CrudUser();
            if (init.CheckLogin3(comNome, comPassword))
            {

                if(check.ChecarNivel(comNome) == 1)
                {
                    MessageBox.Show("O seu nível de usuário não consede acesso a plataforma, por vafor entre em contato com o setor responsavél!");
                }
                else 
                {
                    FormHome home = new FormHome(comNome);
                    home.Show();
                    Hide();
                }
            }
         else { MessageBox.Show("Usuário ou senha inválido"); }


        }

        private void linkSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateDataBase vai = new CreateDataBase();
            vai.CrearTableHolerite();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

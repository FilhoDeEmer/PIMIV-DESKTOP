using PIM_IV.control;
using PIM_IV.model;
using PIM_IV.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (init.CheckLogin(comNome, comPassword))
            {
                FormHome home = new FormHome(comNome);
                home.Show();
                Hide();
            }
            else { MessageBox.Show("Usuário ou senha invalido"); }


        }

        private void linkSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            MessageBox.Show(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

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
            InitializeComponent();

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           comNome = txtBoxLogin.Text;
           comPassword = txtBoxPassword.Text;
            DBcommand tenta = new DBcommand();
           string teste = tenta.CmdLogin(comNome,comPassword);

            if(teste == comNome)
            {
                MessageBox.Show("Bem Vindo! " + comNome);
                FormHome home = new FormHome( comNome);
                home.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Login ou Senha invalidos!");
            }

           /* Login testar = new Login();
            bool check = testar.CheckLogin(comNome, comPassword);

            if (check)
            {
                MessageBox.Show("Bem Vindo! " + comNome);
                FormHome home = new FormHome();
                home.Show();
                Hide();
                
            }
            else 
            {
                MessageBox.Show("Login ou Senha invalidos!");
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

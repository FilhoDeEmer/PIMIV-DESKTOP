using PIM_IV.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV.view
{
    public partial class FormPrimeiroLogin : Form
    {
        public FormPrimeiroLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string senha = txtSenha.Text;
            int nivel = 5;

            CreateDataBase init = new CreateDataBase();
            init.CriarNovoUsuario(user, senha, nivel);
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("O usuário não sera criado e vocÊ não poderar acessar o sistema. Deseja continuar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                Application.Exit();

            }
            else
            {

            }
        }
    }
}

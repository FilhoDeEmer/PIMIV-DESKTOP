using PIM_IV.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV
{
    public partial class FormHome : Form
    {
        string username;
        public FormHome(string username)
        {
            InitializeComponent();
            this.username = username;
            nomeUsuario.Text = username;
        }
        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do programa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               FormLogin login = new FormLogin();
                Close();
                
            }
            else
            {

            }
        }

        private void btnGerarFolha_Click(object sender, EventArgs e)
        {
            AtivarBotao(btnGerarFolha);
            FormAtivar(new FormGerarFolha());//mudar pro form correspondente
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGerenciarUsuarios_Click(object sender, EventArgs e)
        {
            AtivarBotao(btnGerenciarUsuarios);
            FormAtivar(new FormUsuarios());//mudar pro form correspondente

        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private Form formAtivo;
        private void FormAtivar(Form form)
        {
            FormDesativar(form);
            form.TopLevel = false;
            formAtivo = form;
            panelHome.Controls.Add(form);
            form.BringToFront();
            form.Show();

        }

        private void FormDesativar(Form form)
        {
            pictureLogo.Visible = false;
            if (formAtivo != null)
                formAtivo.Close();
        }

        private void AtivarBotao (Button formAtivo)
        {
            //mudar
            foreach (Control control in groupBox1.Controls)
                control.ForeColor = Color.AliceBlue;//muda a cor da letra de todos os botões
            foreach (Control control in groupBox1.Controls)//muda a cor de fundo de todos os botões
                control.BackColor = Color.RoyalBlue;//muda a cor de todos os botões
            formAtivo.ForeColor = Color.AliceBlue;//muda a cor só do texto do botão selecionado
            formAtivo.BackColor = Color.Gray;//muda a cor de fundo só do botão selecionado
        }

        private void btnGerenciarFuncionarios_Click(object sender, EventArgs e)
        {
            AtivarBotao(btnGerenciarFuncionarios);
            FormAtivar(new FormFuncionarios());//mudar pro form correspondente
        }

        private void btnRelatorioHoras_Click(object sender, EventArgs e)
        {
            //AtivarBotao(btnRelatorioHoras);
           // FormAtivar(new FormFuncionarios());//mudar pro form correspondente
        }

        private void btnRelatoriosGerais_Click(object sender, EventArgs e)
        {
           // AtivarBotao(btnRelatoriosGerais);
           // FormAtivar(new FormFuncionarios());//mudar pro form correspondente

        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
           // AtivarBotao(btnAjuda);
            //FormAtivar(new FormFuncionarios());//mudar pro form correspondente
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AtivarBotao(btnGerenciarEmpresas);
            FormAtivar(new FormEmpresas());
        }

        private void btnConfiguracao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui deve vir as configurações!");
        }
    }
}

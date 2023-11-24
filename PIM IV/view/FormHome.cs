using PIM_IV.view;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PIM_IV
{
    public partial class FormHome : Form
    {
        public FormHome(string username)
        {
            InitializeComponent();
            nomeUsuario.Text = username;
        }
        private void FormHome_Load(object sender, EventArgs e)
        {

        }
        string codEmpresa = null;
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do programa?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormLogin login = new FormLogin();
                this.Close();
                login.Show();
            }
            else
            {

            }
        }

        private void btnGerarFolha_Click(object sender, EventArgs e)
        {
            FormSelecEpresa empresa = new FormSelecEpresa();
            empresa.ShowDialog();
            codEmpresa = empresa.CodEmpresa;
            if (codEmpresa != null)
            {
                AtivarBotao(btnGerarFolha);
                FormAtivar(new FormGerarFolha(codEmpresa));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            //pictureLogo.Visible = false;
            if (formAtivo != null)
                formAtivo.Close();
        }

        private void AtivarBotao(Button formAtivo)
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

       

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Você tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else { Application.Exit(); }
        }


    }
}

using PIM_IV.control;
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
    public partial class FormCRUDFuncionario : Form
    {
        string cod;
        public FormCRUDFuncionario()
        {
            InitializeComponent();
        }
        public FormCRUDFuncionario(int edicao, string cod)
        {            
            InitializeComponent();
            if (edicao == 1)
            {
                txtCodFun.Enabled = true;
                this.cod = cod;
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Os dados alteradso serão perdidos. Deseja continuar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();

            }
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CrudFuncionario salvarFuncionario = new CrudFuncionario();
            salvarFuncionario.Nome = txtNomeEmpresa.Text;
            salvarFuncionario.DataNascimento = txtDataNascimento.Text;
            salvarFuncionario.DataAdimicao = txtDataAdmi.Text;
            salvarFuncionario.RG = txtRgFun.Text;
            salvarFuncionario.Rua = txtEndFun.Text;
            salvarFuncionario.Cep = txtCepFun.Text;
            salvarFuncionario.Numero = txtNumFun.Text;
            salvarFuncionario.Cidade = txtCidadeFun.Text;
            salvarFuncionario.Estado = txtUfFun.Text;
            salvarFuncionario.Telefone = txtTelefone.Text;
            salvarFuncionario.Email = txtEmail.Text;
            salvarFuncionario.Cod_empresa = boxCodEmpresa.Text;
            salvarFuncionario.Cod_cargo = boxCodCargo.Text;
            salvarFuncionario.Salario = txtSalarioFun.Text;
            salvarFuncionario.VTransporte = txtTransporte.Text;
            salvarFuncionario.VAlimentacao = txtAlimentacao.Text;
            salvarFuncionario.VRefeicao = txtRefeicao.Text;
            salvarFuncionario.PlanoSaude =txtPlanoSaude.Text;
            salvarFuncionario.AddPericulosidade = txtPericulosidae.Text;
            salvarFuncionario.AddNoturno = txtNoturno.Text;
            salvarFuncionario.DescontoSindical = txtSindical.Text;
            salvarFuncionario.Cod_banco = txtCodBanco.Text;
            salvarFuncionario.NomeBanco = txtBanco.Text;
            salvarFuncionario.AgenciaBanco = txtAgencia.Text;
            salvarFuncionario.NConta = txtConta.Text;

            if (this.cod == null)
            {
                salvarFuncionario.CadastrarFuncionario();
                Close();
            }
            else
            {
                salvarFuncionario.Codigo = this.cod;
                salvarFuncionario.AlterarFuncionario(cod);
                Close();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtSalarioFun_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtCodFun_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

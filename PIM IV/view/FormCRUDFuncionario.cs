using PIM_IV.control;
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

namespace PIM_IV
{
    public partial class FormCRUDFuncionario : Form
    {
        string cod;
        private List<string> codList;
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
            CrudUser criarUser = new CrudUser();
            if(criarUser.CriarNovoUsuario(txtCPF.Text, txtCPF.Text, Convert.ToInt32(txtNivel.Text)))
            {
                CrudFuncionario salvarFuncionario = new CrudFuncionario();
                salvarFuncionario.Cod_User = criarUser.BuscarUser(txtCPF.Text);
                salvarFuncionario.Nome = txtNomeFun.Text;
                salvarFuncionario.Cpf = txtCPF.Text;
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
                salvarFuncionario.Nivel = txtNivel.Text;
            
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
        }
        private void FormCRUDFuncionario_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hERMESDataSet1.Cargos'. Você pode movê-la ou removê-la conforme necessário.
            this.cargosTableAdapter.Fill(this.hERMESDataSet1.Cargos);
            // TODO: esta linha de código carrega dados na tabela 'hERMESDataSet.Empresas'. Você pode movê-la ou removê-la conforme necessário.
            this.empresasTableAdapter.Fill(this.hERMESDataSet.Empresas);
            // TODO: esta linha de código carrega dados na tabela 'hERMESDataSetUsers.Usuarios'. Você pode movê-la ou removê-la conforme necessário.
            this.usuariosTableAdapter.Fill(this.hERMESDataSetUsers.Usuarios);

        }

        private void boxCodEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrudEmpresas nomeEmpresa = new CrudEmpresas();
            CrudCargos pesquisaCargos = new CrudCargos();
            txtNomeEmpresa.Text = nomeEmpresa.BuscarEmpresaNomeById(Convert.ToInt16(boxCodEmpresa.Text));
            txtCnpjEmpresa.Text = nomeEmpresa.Cnpj;
            boxCodCargo.DisplayMember = "CodCargo";
            boxCodCargo.ValueMember = "CodCargo";
            boxCodCargo.DataSource = pesquisaCargos.GetListCod(boxCodEmpresa.Text);

            
        }

        private void boxCodCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrudCargos pesquisaCargos = new CrudCargos();
            pesquisaCargos.BuscaCargo(boxCodCargo.Text);
            txtNomeCargo.Text = pesquisaCargos.NomeCargo;
            txtSalarioFun.Text = pesquisaCargos.SalarioBase;
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            txtLogin.Text = txtCPF.Text;
            txtSenha.Text = txtCPF.Text;
        }
    }
}

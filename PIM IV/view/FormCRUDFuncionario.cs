using PIM_IV.control;
using PIM_IV.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PIM_IV
{
    public partial class FormCRUDFuncionario : Form
    {
        string cod = null;
        int codEmpresa;
        public FormCRUDFuncionario()//criar novo funcionário
        {
            InitializeComponent();
            PreencherComboBoxEstados();
            LoadEmpresas();
            
            btnExcluirFun.Enabled = false;
        }
        public FormCRUDFuncionario(string cod)//alterar funcionário
        {
            InitializeComponent();
            if (cod != null)
            {
                LoadEmpresas();
                //txtCodFun.Enabled = true;
                txtCodFun.Text = cod;
                //txtSenha.Enabled = true;
                this.cod = cod;
                CrudFuncionario alterarFuncionario = new CrudFuncionario();
                alterarFuncionario.BuscarFuncionario(this.cod);
                codEmpresa = Convert.ToInt16(alterarFuncionario.Cod_empresa);
                PreencherComboBoxEstados();
                txtNomeFun.Text = alterarFuncionario.Nome;
                txtCPF.Text = alterarFuncionario.Cpf;
                txtRgFun.Text = alterarFuncionario.RG;
                txtDataNascimento.Text = alterarFuncionario.DataNascimento;
                txtEndFun.Text = alterarFuncionario.Rua;
                txtNumFun.Text = alterarFuncionario.Numero;
                txtCepFun.Text = alterarFuncionario.Cep;
                txtUfFun.Text = alterarFuncionario.Estado;
                txtCidadeFun.Text = alterarFuncionario.Cidade;
                txtCodBanco.Text = alterarFuncionario.Cod_banco;
                txtBanco.Text = alterarFuncionario.NomeBanco;
                txtAgencia.Text = alterarFuncionario.AgenciaBanco;
                txtConta.Text = alterarFuncionario.NConta;
                boxCodEmpresa.Text = alterarFuncionario.Cod_empresa;
                boxCodEmpresa_SelectedIndexChanged(null, null);
                boxCodCargo.Text = alterarFuncionario.Cod_cargo;
                boxCodCargo_SelectedIndexChanged(null, null);
                txtSalarioFun.Text = alterarFuncionario.Salario;
                txtDataAdmi.Text = alterarFuncionario.DataAdimicao;
                txtTransporte.Text = alterarFuncionario.VTransporte;
                txtRefeicao.Text = alterarFuncionario.VRefeicao;
                txtAlimentacao.Text = alterarFuncionario.VAlimentacao;
                txtPericulosidae.Text = alterarFuncionario.AddPericulosidade;
                txtInss.Text = alterarFuncionario.Inss;
                txtPlanoSaude.Text = alterarFuncionario.PlanoSaude;
                txtNoturno.Text = alterarFuncionario.AddNoturno;
                txtDependentes.Text = alterarFuncionario.NDependentes;
                txtLogin.Text = alterarFuncionario.Login;
                txtNivel.Text = alterarFuncionario.Nivel;
                txtTelefone.Text = alterarFuncionario.Telefone;
                txtEmail.Text = alterarFuncionario.Email;
                txtSenha.Text = "";
                
                //txtSenha.Text = alterarFuncionario.Senha;
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
            if(cod != null)//usuario carregado e será alterado
            {
                if (checkBox1.Checked)// vai alterar só o usuário
                {
                    alterarUsuario();
                    
                }
                else// vai alterar só o funcionário
                {
                    SalvarTudo();
                }
            }
            else// vai criar um novo funcionário/usuário
            {
                SalvarTudo();
            }
        }

       

        private void alterarUsuario()
        {
            if (txtLogin.Text.Length > 3) //verifica login
            {
                if (txtSenha.Text.Length > 5)//Verifica senha
                {
                    CrudUser alterar = new CrudUser();
                    alterar.AlterarSenha(txtLogin.Text, txtSenha.Text);
                    Close();
                }
                else
                {
                    MessageBox.Show("Senha muito curta! ");

                }
            }
            else
            {
                MessageBox.Show("Login deve ter mais de 3 caracteres! ");
            }
        }

        private void boxCodEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeBox();
        }

        private void boxCodCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int config = boxCodCargo.SelectedIndex;

            CrudCargos pesquisaCargos = new CrudCargos();
            pesquisaCargos.BuscaCargo(boxCodCargo.Text);
            txtNomeCargo.Text = pesquisaCargos.NomeCargo;
            txtSalarioFun.Text = pesquisaCargos.SalarioBase;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public void AtualizaComboCod(int indice)
        {
            
        }


        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            txtLogin.Text = txtCPF.Text;
            txtSenha.Text = txtCPF.Text;
        }

        private void btnExcluirFun_Click(object sender, EventArgs e)
        {

            if (cod != null)
            {
                CrudFuncionario addFuncionario = new CrudFuncionario();
                if (addFuncionario.DeletarFuncionario(cod, txtLogin.Text))
                {
                    MessageBox.Show("Funcionario deletado com Sucesso!");
                    Close();
                }
                MessageBox.Show("O Funcionario não foi deletado!");
            }
            else { MessageBox.Show("Nenhum Funcionario Selecionado!"); }
        }


        private void txtNomeEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrudCargos pesquisaCargos = new CrudCargos();
            boxCodCargo.DisplayMember = "CodCargo";
            boxCodCargo.ValueMember = "CodCargo";
            boxCodCargo.DataSource = pesquisaCargos.GetListCod(boxCodEmpresa.Text);
        }

        private void ChangeBox()
        {
            CrudEmpresas nomeEmpresa = new CrudEmpresas();
            CrudCargos pesquisaCargos = new CrudCargos();
            //boxCodEmpresa.SelectedItem = codEmpresa;
            txtNomeEmpresa.Text = nomeEmpresa.BuscarEmpresaNomeById(boxCodEmpresa.Text);
            txtCnpjEmpresa.Text = nomeEmpresa.Cnpj;
            boxCodCargo.DisplayMember = "CodCargo";
            boxCodCargo.ValueMember = "CodCargo";
            boxCodCargo.DataSource = pesquisaCargos.GetListCod(boxCodEmpresa.Text);
        }

        private void txtNomeCargo_TextChanged(object sender, EventArgs e)
        {

        }
        private void PreencherComboBoxEstados()
        {
            // Cria uma lista de estados brasileiros
            List<string> estados = new List<string>
            {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES",
                "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR",
                "PE", "PI", "RJ", "RN", "RS", "RO", "RR",
                "SC", "SP", "SE", "TO"
            };

            // Associa a lista de estados ao ComboBox
            txtUfFun.DataSource = estados;
        }

        public void LoadEmpresas()
        {
            CrudEmpresas loadEmpresas = new CrudEmpresas();
            txtNomeEmpresa.DisplayMember = "NomeEmpresa";
            txtNomeEmpresa.ValueMember = "CodEmpresa";
            txtNomeEmpresa.DataSource = loadEmpresas.BuscarEmpresas();
            boxCodEmpresa.DisplayMember = "CodEmpresa";
            boxCodEmpresa.ValueMember = "CodEmpresa";
            boxCodEmpresa.DataSource = loadEmpresas.BuscarEmpresas();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cod != null)
            {
                if (checkBox1.Checked)
                {
                    groupBox8.Enabled = true;
                    txtLogin.Enabled = true;
                    txtSenha.Enabled = true;
                    txtNivel.Enabled = true;
                    DesativarCampor();
                    
                }
                else
                {
                    groupBox8.Enabled = false;
                    txtLogin.Enabled = false;
                    txtSenha.Enabled = false;
                    txtNivel.Enabled = false;
                    AtivarCampor();
                }
            }
            else
            {
                if (checkBox1.Checked)
                {
                    groupBox8.Enabled = true;
                    txtLogin.Enabled = true;
                    txtSenha.Enabled = true;
                    txtNivel.Enabled = true;
                    //DesativarCampor();
                    
                }
                else
                {
                    groupBox8.Enabled = false;
                    txtLogin.Enabled = false;
                    txtSenha.Enabled = false;
                    txtNivel.Enabled = false;
                    //AtivarCampor();
                }
            }
        }

        private void SalvarTudo()
        {
            CrudFuncionario salvarFuncionario = new CrudFuncionario();
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
            salvarFuncionario.PlanoSaude = txtPlanoSaude.Text;
            salvarFuncionario.AddPericulosidade = txtPericulosidae.Text;
            salvarFuncionario.AddNoturno = txtNoturno.Text;
            salvarFuncionario.NDependentes = txtDependentes.Text;
            salvarFuncionario.Cod_banco = txtCodBanco.Text;
            salvarFuncionario.NomeBanco = txtBanco.Text;
            salvarFuncionario.AgenciaBanco = txtAgencia.Text;
            salvarFuncionario.NConta = txtConta.Text;
            CrudUser check = new CrudUser();
            salvarFuncionario.Cod_User = check.BuscarCod();
            MessageBox.Show(salvarFuncionario.Cod_User);

            if (cod == null)
            {
                salvarFuncionario.Nivel = txtNivel.Text;
                salvarFuncionario.Login = txtLogin.Text;
                salvarFuncionario.SSS = txtSenha.Text;
                // CrudUser criarUser = new CrudUser();
                //if (criarUser.CriarNovoUsuario(txtLogin.Text, txtSenha.Text, Convert.ToInt32(txtNivel.Text)))
                //{
                //salvarFuncionario.Cod_User = criarUser.BuscarUser(txtCPF.Text);
                if (salvarFuncionario.CadastrarFuncionario())
                {
                    Close();
                }

                //}
            }
            else
            {
                salvarFuncionario.Codigo = this.cod;
                salvarFuncionario.AlterarFuncionario(cod);
                Close();
            }
        }

        private void DesativarCampor()
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox6.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox9.Enabled = false;
        }
        private void AtivarCampor()
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox6.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
            groupBox9.Enabled = true;
        }

    }
}

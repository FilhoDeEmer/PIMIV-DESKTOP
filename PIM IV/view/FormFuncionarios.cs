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
    public partial class FormFuncionarios : Form
    {
        public FormFuncionarios()
        {
            InitializeComponent();
        }
        string codFuncionario;
        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hERMESDataSet2.Funcionarios'. Você pode movê-la ou removê-la conforme necessário.
            this.funcionariosTableAdapter.Fill(this.hERMESDataSet2.Funcionarios);

        }

        private void btnCadastrarFun_Click(object sender, EventArgs e)
        {
            CrudCargos contaCargo = new CrudCargos();
            CrudEmpresas contaEmpresa = new CrudEmpresas();

            if (contaEmpresa.ContaEmpresa())
            {
                if (contaCargo.ContaCargo())
                { 
                    FormCRUDFuncionario addFuncionario = new FormCRUDFuncionario();
                    addFuncionario.ShowDialog();
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("Pelo menos um cargo deve ser cadastrada!");
                }
            }
            else
            {
                MessageBox.Show("Pelo menos uma empresa deve ser cadastrada!");
            }
        }

        private void btnAlterarFun_Click(object sender, EventArgs e)
        {
            if(codFuncionario != null)
            {
                FormCRUDFuncionario addFuncionario = new FormCRUDFuncionario(codFuncionario);
                addFuncionario.Show();
             }
            else { MessageBox.Show("Nenhum Funcionario Selecionado!"); }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
        }

       
        

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.funcionariosTableAdapter.FillBy(this.hERMESDataSet2.Funcionarios);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnPesquisaFuncionario_Click(object sender, EventArgs e)
        {
            if (txtCpfBusca.TextLength > 0)
            {
                CrudFuncionario buscaFun = new CrudFuncionario();
                string retorno = buscaFun.BuscarFuncionarioByCPF(txtCpfBusca.Text);
                if (retorno != null)
                {
                    FormCRUDFuncionario crudFun = new FormCRUDFuncionario(retorno);
                    crudFun.ShowDialog();

                }else { MessageBox.Show("CPF digitado não encontrado!"); };
            }
            else { MessageBox.Show("O campo não pode estar vazio!"); };
        }

        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                codFuncionario = dataGridView1["codigo_funcionario", e.RowIndex].Value.ToString();

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                codFuncionario = dataGridView1["codigo_funcionario", e.RowIndex].Value.ToString();

            }
        }

       

        private void btnBuscaCNPJ_Click(object sender, EventArgs e)
        {
            CrudEmpresas pesquisaFun = new CrudEmpresas();
            pesquisaFun.BuscarEmpresaNomeById(txtCnpjBusca.Text);
            string cnpj = pesquisaFun.Cnpj;
            try
            {
                this.funcionariosTableAdapter.FillBy1(this.hERMESDataSet2.Funcionarios, new System.Nullable<int>(((int)(System.Convert.ChangeType(cnpj, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Empresa não cadastrada ou não possui funcionario relacionado a ela!");
            }
        }
    }
}

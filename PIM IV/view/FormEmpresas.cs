using PIM_IV.control;
using System;
using System.Windows.Forms;

namespace PIM_IV.view
{
    public partial class FormEmpresas : Form
    {
        public FormEmpresas()
        {
            InitializeComponent();
        }
        string cod;
        private void btnCadastrarEmpresa_Click(object sender, EventArgs e)
        {
            FormGerEmpresas crudEmpresa = new FormGerEmpresas();   
            crudEmpresa.ShowDialog();
        }

        private void FormEmpresas_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hERMESDataSet.Empresas'. Você pode movê-la ou removê-la conforme necessário.
            this.empresasTableAdapter.Fill(this.hERMESDataSet.Empresas);

        }

        private void btnAlterarEmpresa_Click(object sender, EventArgs e)
        {
            if (cod != null)
            {
                FormGerEmpresas crudEmpresa = new FormGerEmpresas(cod);
                crudEmpresa.ShowDialog();
            }
            else { MessageBox.Show("Selecione uma Empresa!"); };

        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                cod = dataGridView1["codigo", e.RowIndex].Value.ToString();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
               cod = dataGridView1["codigo", e.RowIndex].Value.ToString();

            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("A empresa selecionada sera deletada do sistema. Deseja continuar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cod != null)
                {
                    CRUDEmpresas deletar = new CRUDEmpresas();
                    deletar.DeletarEmpresa(cod);
                }
                else { MessageBox.Show("Selecione uma Empresa!"); };

            }
            else
            {

            }
            
        }

        private void btnBuscaCNPJ_Click(object sender, EventArgs e)
        {
            if (txtCnpjBusca.TextLength >0)
            {
                CRUDEmpresas pesquisa = new CRUDEmpresas();
                string retorno = pesquisa.BuscarEmpresaCnpj(txtCnpjBusca.Text);
                if(retorno != null)
                {
                    FormGerEmpresas crudEmpresa = new FormGerEmpresas(retorno);
                    crudEmpresa.ShowDialog();
                }
                else { MessageBox.Show("CNPJ digitado não encontrado!"); };

            }
            else { MessageBox.Show("O campo não pode estar vazio!"); };
            
        }
    }
}

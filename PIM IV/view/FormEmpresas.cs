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
            LoadEmpresas();
        }

        private void LoadEmpresas()
        {
            CrudEmpresas carregar = new CrudEmpresas();
            try
            {
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = carregar.BuscarEmpresas();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        string cod;
        private void btnCadastrarEmpresa_Click(object sender, EventArgs e)
        {
            FormCRUDEEmpresas crudEmpresa = new FormCRUDEEmpresas();   
            crudEmpresa.ShowDialog();
            LoadEmpresas();
        }

        private void FormEmpresas_Load(object sender, EventArgs e)
        {
            

        }

        private void btnAlterarEmpresa_Click(object sender, EventArgs e)
        {
            if (cod != null)
            {
                FormCRUDEEmpresas crudEmpresa = new FormCRUDEEmpresas(cod);
                crudEmpresa.ShowDialog();
            }
            else { MessageBox.Show("Selecione uma Empresa!"); }
            LoadEmpresas();

        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                cod = dataGridView2["codEmpresa", e.RowIndex].Value.ToString();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
               cod = dataGridView2["codEmpresa", e.RowIndex].Value.ToString();

            }
        }

        

        private void btnBuscaCNPJ_Click(object sender, EventArgs e)
        {
            if (txtCnpjBusca.TextLength >0)
            {
                CrudEmpresas pesquisa = new CrudEmpresas();
                string retorno = pesquisa.BuscarEmpresaCnpj(txtCnpjBusca.Text);
                if(retorno != null)
                {
                    FormCRUDEEmpresas crudEmpresa = new FormCRUDEEmpresas(retorno);
                    crudEmpresa.ShowDialog();
                }
                else { MessageBox.Show("CNPJ digitado não encontrado!"); };

            }
            else { MessageBox.Show("O campo não pode estar vazio!"); };
            
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            FormCRUDCargos cargos = new FormCRUDCargos();
            cargos.ShowDialog();
            
        }

        private void btnVoltarUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIM_IV
{
    public partial class FormFuncionarios : Form
    {
        public FormFuncionarios()
        {
            InitializeComponent();
            LoadFuncionarios();
        }
        string codFuncionario;
        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
         

        }

        private void LoadFuncionarios()
        {
            CrudFuncionario carregar = new CrudFuncionario();
            try
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = carregar.CarregarFuncionario();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
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
            LoadFuncionarios();
        }

        private void btnAlterarFun_Click(object sender, EventArgs e)
        {
            if(codFuncionario != null)
            {
                FormCRUDFuncionario addFuncionario = new FormCRUDFuncionario(codFuncionario);
                addFuncionario.Show();
                dataGridView1.Refresh();

            }
            else { MessageBox.Show("Nenhum Funcionario Selecionado!"); }

            LoadFuncionarios();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
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
                codFuncionario = dataGridView1["codigo", e.RowIndex].Value.ToString();

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                codFuncionario = dataGridView1["codigo", e.RowIndex].Value.ToString();

            }
        }

       

        private void btnBuscaCNPJ_Click(object sender, EventArgs e)
        {
            CrudEmpresas pesquisaFun = new CrudEmpresas();
            string cod = pesquisaFun.BuscaCod(txtCnpjBusca.Text);
            
            BuscaFuncionarios(cod);
        }
        public void BuscaFuncionarios(string codEmpresa)
        {
            CrudFuncionario loadFuncionario = new CrudFuncionario();
            try
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = loadFuncionario.CarregarFuncionarioEmpresa(codEmpresa);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

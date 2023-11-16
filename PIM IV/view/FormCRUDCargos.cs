using PIM_IV.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIM_IV.view
{
    public partial class FormCRUDCargos : Form
    {
        public FormCRUDCargos()
        {
            InitializeComponent();
        }
        string codCargo;
        private void FormCRUDCargos_Load(object sender, EventArgs e)
        {
            PreencherCargos();
        }

        private void byEmpresasToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
               // this.cargosTableAdapter.ByEmpresas(this.hERMESDataSet3.Cargos, new System.Nullable<int>(((int)(System.Convert.ChangeType(codEmpresaToolStripTextBox.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormCargos cargo = new FormCargos();
            cargo.ShowDialog();
        }

        private void codEmpresaToolStripTextBox_Click(object sender, EventArgs e)
        {

        }
        public class Cargos
        {
            public string Nome { get; set; }
            public string Salario_Base { get; set; }
            public string Cod_Empresa { get; set; }
            public string Cod_Cargo { get; set; }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CrudCargos loadEmpresas = new CrudCargos();
            //List<Cargos> listaProdutos = loadEmpresas.BuscaCargos();
            try
            {
                var dataSource = dataGridView1.DataSource as List<Cargos>;

                if (dataSource != null)
                {
                    // Filtrar a lista com base no termo de pesquisa
                   // var resultados = dataSource.Where(produto => produto.Nome.Contains(termoPesquisa)).ToList();

                    // Atualizar o DataGridView com os resultados da pesquisa
                   // dataGridView1.DataSource = resultados;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (codCargo != null)
            {
                FormCargos cargo = new FormCargos(codCargo);
                cargo.ShowDialog();

            }
            else { MessageBox.Show("Selecione um Cargo!"); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Os dados alterados serão perdidos. Deseja continuar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();

            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0)
            {

            }
            else
            {
                codCargo = dataGridView1["cod_cargo", e.RowIndex].Value.ToString();

            }
        }

        public void PreencherCargos()
        {
            CrudCargos loadCargos = new CrudCargos();
            try
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = loadCargos.BuscaCargos();
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void cargosBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

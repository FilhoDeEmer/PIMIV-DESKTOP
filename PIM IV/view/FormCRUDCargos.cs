using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                //this.cargosTableAdapter.ByEmpresas(this.hERMESDataSet3.Cargos, new System.Nullable<int>(((int)(System.Convert.ChangeType(txtEmpresas.Text, typeof(int))))));
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                codCargo = dataGridView1["cod_cargo", e.RowIndex].Value.ToString();

            }
        }
    }
}

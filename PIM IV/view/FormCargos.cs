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

namespace PIM_IV.view
{
    public partial class FormCargos : Form
    {
        public FormCargos()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCargos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hERMESDataSet.Empresas'. Você pode movê-la ou removê-la conforme necessário.
            this.empresasTableAdapter.Fill(this.hERMESDataSet.Empresas);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Os dados alterados serão perdidos. Deseja continuar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();

            }
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            

            if (txtNome.TextLength >0 )
            {
                if(txtSalarioBase.TextLength > 0)
                {
                    string cargoNome = txtNome.Text;
                    decimal salarioBase = decimal.Parse(txtSalarioBase.Text);
                    int empresa = (int)comboBox1.SelectedValue;
                    CrudCargos novoCargo = new CrudCargos();
                    novoCargo.CadastrarCargo(cargoNome, salarioBase, empresa);
                    Close();
                }
                else
                {
                    MessageBox.Show("O campo Salário deve ser preenchido!");
                }
            }
            else
            {
                MessageBox.Show("O campo Nome deve ser preenchido!");
            }
        }
    }
}

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
            FormCRUDFuncionario addFuncionario = new FormCRUDFuncionario();
            addFuncionario.Show();

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}

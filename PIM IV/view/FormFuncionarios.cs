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
           
        }

        private void btnCadastrarFun_Click(object sender, EventArgs e)
        {
            FormCRUDFuncionario addFuncionario = new FormCRUDFuncionario();
            addFuncionario.ShowDialog();
            dataGridView1.Refresh();
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
    }
}

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
            // TODO: esta linha de código carrega dados na tabela 'pIMIIIDataSet1.FUNCIONARIOS_teste'. Você pode movê-la ou removê-la conforme necessário.
            this.fUNCIONARIOS_testeTableAdapter.Fill(this.pIMIIIDataSet1.FUNCIONARIOS_teste);
            // TODO: esta linha de código carrega dados na tabela 'pIMIIIDataSet.FUNCIONARIOS'. Você pode movê-la ou removê-la conforme necessário.
            this.fUNCIONARIOSTableAdapter.Fill(this.pIMIIIDataSet.FUNCIONARIOS);

        }

        private void btnCadastrarFun_Click(object sender, EventArgs e)
        {
            cdFuncionario cadastrar = new cdFuncionario();
            cadastrar.Show();
            dataGridView1.Refresh();
        }
    }
}

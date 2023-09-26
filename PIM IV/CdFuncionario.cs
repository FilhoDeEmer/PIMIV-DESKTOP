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
    public partial class cdFuncionario : Form
    {
        public cdFuncionario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            DBcommand cadastra = new DBcommand();
            cadastra.cadFuncionario(nome, cpf);
            Close();
        }
    }
}

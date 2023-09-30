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
    public partial class FormCRUDUsers : Form
    {
        public FormCRUDUsers()
        {
            InitializeComponent();
        }

        private void Nivel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Os dados alteradso serão perdidos. Deseja continuar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();

            }
            else
            {

            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sucesso!");
        }
    }
}

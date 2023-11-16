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
    public partial class FormSelecEpresa : Form
    {
        public FormSelecEpresa()
        {
            InitializeComponent();
            LoadEmpresa();
        }
       public string CodEmpresa { get; set; }
        

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length <= 0)
            {
                MessageBox.Show("Selecione um empresa!");
                //return null;
            }
            else
            {
                CodEmpresa = Convert.ToString(comboBox1.SelectedValue);
                Close();
                //return CodEmpresa;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void LoadEmpresa() 
        {
            CrudEmpresas loadEmpresas = new CrudEmpresas();
            comboBox1.DisplayMember = "NomeEmpresa";
            comboBox1.ValueMember = "CodEmpresa";
            comboBox1.DataSource = loadEmpresas.BuscarEmpresas();
        }
    }
}

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

namespace PIM_IV.view
{
    public partial class FormCargos : Form
    {
        public FormCargos()
        {
            InitializeComponent();
            LoadEmpresas();
        }
        string cod = null;
        public FormCargos(string cod)
        {
            this.cod = cod;
            InitializeComponent();
            CrudCargos cargo = new CrudCargos();
            LoadEmpresas();
            cargo.BuscaCargo(cod);
            txtNome.Text = cargo.NomeCargo;
            txtSalarioBase.Text = cargo.SalarioBase;
            comboCod.Text = cargo.CodEmpresa.ToString();
            comboBox1_SelectedIndexChanged(null, null);

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCargos_Load(object sender, EventArgs e)
        {
           

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
            if (cod != null)
            {
                if (txtNome.TextLength > 0)
                {
                    if (txtSalarioBase.TextLength > 0)
                    {
                        
                        CrudCargos alterarCargo = new CrudCargos();
                        alterarCargo.NomeCargo = txtNome.Text;
                        alterarCargo.SalarioBase = txtSalarioBase.Text;
                        alterarCargo.CodEmpresa = Convert.ToString(comboCod.Text);
                        alterarCargo.CodCargo = cod;
                        alterarCargo.AlteraCargo(cod);
                        this.Close();
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
            else
            {
                if (txtNome.TextLength > 0)
                {
                    if (txtSalarioBase.TextLength > 0)
                    {
                        string cargoNome = txtNome.Text;
                        decimal salarioBase = decimal.Parse(txtSalarioBase.Text);
                        string empresa = comboCod.Text;
                        CrudCargos novoCargo = new CrudCargos();
                        novoCargo.CadastrarCargo(cargoNome, salarioBase, empresa);
                        this.Close();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Os dados serão perdidos. Deseja continuar?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CrudCargos delete = new CrudCargos();
                delete.CodCargo = cod;
                delete.DeletaCargo();
                this.Close();

            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int config = comboBox1.SelectedIndex;
            AtualizaComboCod(config);
        }
        public void AtualizaComboCod(int indice)
        {
            if (indice >= 0 && indice < comboCod.Items.Count)
            {
                comboCod.SelectedItem = comboCod.Items[indice];
            }
        }


        private void comboCod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int config = comboCod.SelectedIndex;
            AtualizaCombobox(config);
        }
        public void AtualizaCombobox(int indice)
        {
            if (indice >= 0 && indice < comboBox1.Items.Count)
            {
                comboBox1.SelectedItem = comboBox1.Items[indice];
            }
        }


        public void LoadEmpresas()
        {
            CrudEmpresas loadEmpresas = new CrudEmpresas();
            comboBox1.DisplayMember = "NomeEmpresa";
            comboBox1.ValueMember = "CodEmpresa";
            comboBox1.DataSource = loadEmpresas.BuscarEmpresas();
            comboCod.DisplayMember = "CodEmpresa";
            comboCod.ValueMember = "CodEmpresa";
            comboCod.DataSource = loadEmpresas.BuscarEmpresas();
        }

        
    }
}

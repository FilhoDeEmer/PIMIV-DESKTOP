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
            LoadEmpresas();
        }
        string codCargo;
        private void FormCRUDCargos_Load(object sender, EventArgs e)
        {
            PreencherCargos();
        }

        

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            AbrirTela(0);
        }

                

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
            if (txtEmpresas.Text.Length > 0)
            {
                CrudEmpresas codigo = new CrudEmpresas();
                codigo.BuscarCodEmpresa(txtEmpresas.Text);
                string codParcial = codigo.Codigo;
                CrudCargos loadCargos = new CrudCargos();
                try
                {
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = loadCargos.BuscaCargos(codParcial);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
            else
            {
                PreencherCargos();
            }
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AbrirTela(1);
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
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
        public void LoadEmpresas()
        {
            CrudEmpresas loadEmpresas = new CrudEmpresas();
            txtEmpresas.DisplayMember = "NomeEmpresa";
            txtEmpresas.ValueMember = "codEmpresa";
            txtEmpresas.DataSource = loadEmpresas.BuscarEmpresas();
            
        }


        public void AbrirTela(int tela)
        {
            if (tela == 0)//cadastrar
            {
                FormCargos cargo = new FormCargos();
                cargo.FormClosed -= Cargo_FormClosed;
                cargo.FormClosed += Cargo_FormClosed;
                cargo.ShowDialog();
                
            }
            else if(tela == 1)//alterar
            {
                if (codCargo != null)
                {
                    FormCargos cargo = new FormCargos(codCargo);
                    cargo.FormClosed -= Cargo_FormClosed;
                    cargo.FormClosed += Cargo_FormClosed;
                    cargo.ShowDialog();
                    

                }
                else { MessageBox.Show("Selecione um Cargo!"); }
            }
           

        }

        private void Cargo_FormClosed(object sender, FormClosedEventArgs e)
        {
            PreencherCargos();
            dataGridView1.Refresh();
            this.Refresh();
        }
    }
}

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
    public partial class FormGerarFolha : Form
    {
        string codEmpresa = null;
        public FormGerarFolha(string codEmpresa)
        {
            this.codEmpresa = codEmpresa;
            InitializeComponent();
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;

            EditarEmpresa();
            
        }
       
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            EditarFuncionario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFolha novaFolha = new FormFolha();
            novaFolha.ShowDialog();

        }




        private void EditarEmpresa()
        {
            CrudEmpresas empresa = new CrudEmpresas();
            empresa.BuscarEmpresa(codEmpresa);
            string textFormatado = string.Format("{0}\n" +
                                                 "CNPJ: {1}\n" +
                                                 "Endereço: {2}, {3}\n" +
                                                 "{4}\n" +
                                                 "{5}" , empresa.Nome ,empresa.Cnpj, empresa.Rua, empresa.Numero , empresa.Cidade , empresa.Cep);
            labDadosEmpresa.Text = textFormatado;
            CrudFuncionario funcionario2 = new CrudFuncionario();
            boxCPFFUn.DataSource = funcionario2.GetListCpf(codEmpresa);
            boxCPFFUn.DisplayMember = "CpfFun";
            boxCPFFUn.ValueMember = "CodFun";
            
            
                
        }
        private void EditarFuncionario()
        {
            CrudFuncionario funcionario = new CrudFuncionario();
            funcionario.Codigo = boxCPFFUn.Text;
            funcionario.BuscarFuncionario(boxCPFFUn.SelectedValue.ToString());
            string textFormatado = string.Format("{0}\n" +
                                                 "CPF: {1}\n" +     
                                                 "Cargo: {2}\n" + 
                                                 "Admissão: {3}",funcionario.Nome,funcionario.Cpf,funcionario.NomeCargo,funcionario.DataAdimicao);
            labelDadosFuncionarios.Text = textFormatado;
            labelDadosFuncionarios.Visible = true;
        }

        private void FormGerarFolha_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hERMESDataSet4.Referencias'. Você pode movê-la ou removê-la conforme necessário.
            this.referenciasTableAdapter.Fill(this.hERMESDataSet4.Referencias);
            // TODO: esta linha de código carrega dados na tabela 'hERMESDataSet2.Funcionarios'. Você pode movê-la ou removê-la conforme necessário.
            this.funcionariosTableAdapter.Fill(this.hERMESDataSet2.Funcionarios);

        }
    }
}

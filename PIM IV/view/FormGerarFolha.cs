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
    public partial class FormGerarFolha : Form
    {
        string codEmpresa = null;
        decimal valorIRRF;
        public FormGerarFolha(string codEmpresa)
        {
            this.codEmpresa = codEmpresa;
            InitializeComponent();
            groupBox1.Enabled = true;
            c.Enabled = true;
            groupBox3.Enabled = true;

            EditarEmpresa();
            Colocar();
            

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
        private bool EditarFuncionario()
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
            if (funcionario.Nome.Length > 0)
            {   
                c.Enabled = true;
                labelSalarioBase.Text = funcionario.Salario;
                labelSalarioBase.Visible = true;
                labelSalarioINSS.Text = funcionario.Salario;
                labelSalarioINSS.Visible = true;
                labelBaseFGTS.Text = funcionario.Salario;
                labelBaseFGTS.Visible = true;
                labelFGTSMes.Text =Convert.ToString(FGTSCalculo(funcionario.Salario));
                labelFGTSMes.Visible = true;
                labelIRRF.Text = Convert.ToString(CalculoIRRF(Convert.ToDecimal(funcionario.Salario), Convert.ToInt32(funcionario.NDependentes)));
                labelIRRF.Visible = true;

                return true;
            }else {
                c.Enabled = false; 
                return false; }
        }

        private void FormGerarFolha_Load(object sender, EventArgs e)
        {
           

        }

        private void referencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia1Nome.Text = referencias.DescricaRef(referencia1.Text);
        }

        private void referencia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia2Nome.Text = referencias.DescricaRef(referencia2.Text);
        }

        private void referencia3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia3Nome.Text = referencias.DescricaRef(referencia3.Text);
        }

        private void referencia4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia4Nome.Text = referencias.DescricaRef(referencia4.Text);
        }

        private void referencia5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia5Nome.Text = referencias.DescricaRef(referencia5.Text);
        }

        private void referencia6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia6Nome.Text = referencias.DescricaRef(referencia6.Text);
        }

        private void referencia7_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia7Nome.Text = referencias.DescricaRef(referencia7.Text);
        }
        private void Colocar()//insere dados no select box
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia1.DataSource = referencias.GetListCod();
            referencia2.DataSource = referencias.GetListCod();
            referencia3.DataSource = referencias.GetListCod();
            referencia4.DataSource = referencias.GetListCod();
            referencia5.DataSource = referencias.GetListCod();
            referencia6.DataSource = referencias.GetListCod();
            referencia7.DataSource = referencias.GetListCod();

            referencia1.DisplayMember = "Codigo";
            referencia1.ValueMember = "Codigo";
            referencia1.SelectedIndex = -1;

            referencia2.DisplayMember = "Codigo";
            referencia2.ValueMember = "Codigo";
            referencia2.SelectedIndex = -1;

            referencia3.DisplayMember = "Codigo";
            referencia3.ValueMember = "Codigo";
            referencia3.SelectedIndex = -1;

            referencia4.DisplayMember = "Codigo";
            referencia4.ValueMember = "Codigo";
            referencia4.SelectedIndex = -1;

            referencia5.DisplayMember = "Codigo";
            referencia5.ValueMember = "Codigo";
            referencia5.SelectedIndex = -1;

            referencia6.DisplayMember = "Codigo";
            referencia6.ValueMember = "Codigo";
            referencia6.SelectedIndex = -1;

            referencia7.DisplayMember = "Codigo";
            referencia7.ValueMember = "Codigo";
            referencia7.SelectedIndex = -1;

            
        }

        public double FGTSCalculo(string salarioBase)
        {
            double salarioConvertido = Convert.ToDouble(salarioBase);
            double resultado = (8 / 100) * salarioConvertido;
            return resultado;
        }

        public decimal CalculoInss(decimal salarioBase)
        {
            decimal inss, irrf, resultadoInss, resultadoIrrf, salarioConvertido;
            
            salarioConvertido = salarioBase;

            if (salarioConvertido <= 1320.00m)
            {
                inss = salarioConvertido * 0.075m;
            }
            else if (salarioConvertido <= 2571.29m)
            {
                inss = (salarioConvertido - 1320.00m) * 0.09m + 1320.00m * 0.075m;
            }
            else if (salarioConvertido <= 3856.94m)
            {
                inss = (salarioConvertido - 2571.30m) * 0.12m + 1320.00m * 0.075m + (2571.30m - 1320.00m) * 0.09m;
            }
            else if (salarioConvertido <= 6101.06m)
            {
                inss = (salarioConvertido - 3856.94m) * 0.14m + 1320.00m * 0.075m + (2571.300m - 1320.00m) * 0.09m + (3856.94m - 2571.30m) * 0.12m;
            }
            else
            {
                inss = 876.97m; // Teto máximo de contribuição em 20/10/2023
            }

            return inss;

        }

        public decimal CalculoIRRF(decimal salarioBruto, int nDependentes)
        {
            decimal salarioBase = salarioBruto;
            decimal inss = CalculoInss(salarioBase);
            decimal calculoIRRF = (salarioBruto - inss) - (nDependentes * 189.59m);
            calculoIRRF = calculoIRRF - 2112.01m ;

            decimal irrf = 0;

            if (salarioBruto <= 2112.00m)
            {
                irrf = 0;
            }
            else if (salarioBruto <= 2826.65m)
            {
                irrf = calculoIRRF * 0.075m - 142.80m;
            }
            else if (salarioBruto <= 3751.05m)
            {
                irrf = calculoIRRF * 0.15m - 354.80m;
            }
            else if (salarioBruto <= 4664.68m)
            {
                irrf = calculoIRRF * 0.225m - 636.13m;
            }
            else
            {
                irrf = calculoIRRF * 0.275m - 869.36m;
            }

            return irrf;
        }

        
       
    }
}

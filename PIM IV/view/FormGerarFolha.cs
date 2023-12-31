﻿using PIM_IV.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        string valorIRRF;
        double salarioBruto;
        double usoGeral;
        string codFuncionario;
        string nomeFun;
        int larguraImage;
        int alturaImage;
        private string dependentes;
        double VT, VA, VR, addNoturno;
        DateTime dataHoraAtual = DateTime.Now;


        public FormGerarFolha(string codEmpresa)
        {
            this.codEmpresa = codEmpresa;
            InitializeComponent();
            groupBox1.Enabled = true;

            larguraImage = this.Width;
            alturaImage = this.Height;
            label9.Text = Convert.ToString(dataHoraAtual);
            EditarEmpresa();
            Colocar();
            referencia1.KeyPress += referencia1_KeyPress;
        }
       
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            EditarFuncionario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrudFolha folha = new CrudFolha();
            folha.CodFuncionario = codFuncionario;
            folha.CodEmpresa = codEmpresa;
            folha.Salario = salarioBruto.ToString("C2");
            folha.ValorProventos = labelTotal.Text;
            folha.ValorDescontos = labelTotalDesconto.Text;
            folha.ValorLiquido = labelTotalLiquido.Text;
            folha.FaixaIrrf = labelIRRF.Text;
            folha.FgtsMes = labelFGTSMes.Text;
            folha.Mensagem = textBox1.Text;
            folha.SalvarFolha();
            label10.Visible = true;
            label12.Visible = true;
            label14.Visible = true;
            groupBox1.Visible = false;
            btnEmitir.Visible = false;
            button2.Visible = false;

            //folha.GerarImg(nomeFun);
            try
            {
                string diretorioDeSalvamento = "C:\\Users\\eme_s\\OneDrive\\Documentos\\GitHub\\PIMIV-DESKTOP\\Holerite";

                // Criar uma imagem com base no formulário
                Bitmap minhaImagem = new Bitmap(larguraImage, alturaImage);
                this.DrawToBitmap(minhaImagem, new Rectangle(0, 0, larguraImage, alturaImage));

                // Salvar a imagem em um arquivo
                minhaImagem.Save(Path.Combine(diretorioDeSalvamento, $"{nomeFun}{dataHoraAtual.Day}{dataHoraAtual.Month}{dataHoraAtual.Year}.png"), System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show("Folha de Pagamento criada e salva com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            //FormFolha novaFolha = new FormFolha();
            //novaFolha.ShowDialog();
            this.Close();
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
            if (boxCPFFUn.Text.Length <= 0)
            {
                MessageBox.Show("Funcionário não encontrado");
                return false;
            }
            else
            {
                funcionario.BuscarFuncionario(boxCPFFUn.SelectedValue.ToString());
                string textFormatado = string.Format("{0}\n" +
                                                     "CPF: {1}\n" +
                                                     "Cargo: {2}\n" +
                                                     "Admissão: {3}", funcionario.Nome, funcionario.Cpf, funcionario.NomeCargo, funcionario.DataAdimicao);
                labelDadosFuncionarios.Text = textFormatado;
                labelDadosFuncionarios.Visible = true;
                label14.Text = funcionario.Nome;
                if (funcionario.Nome.Length > 0)
                {
                    codFuncionario = funcionario.Codigo;
                    salarioBruto = Convert.ToDouble(funcionario.Salario);
                    c.Enabled = true;
                    btnEmitir.Enabled = true;
                    M.Enabled = true;
                    labelSalarioBase.Text = salarioBruto.ToString("C2");
                    labelSalarioBase.Text = salarioBruto.ToString("C2");
                    nomeFun = funcionario.Nome;
                    labelSalarioBase.Visible = true;
                    labelSalarioINSS.Text = salarioBruto.ToString("C2");
                    labelSalarioINSS.Visible = true;
                    labelBaseFGTS.Text = salarioBruto.ToString("C2");
                    FGTSCalculo(funcionario.Salario);
                    labelBaseFGTS.Visible = true;
                    labelFGTSMes.Visible = true;
                    valorIRRF = Convert.ToString(CalculoIRRF(Convert.ToDecimal(funcionario.Salario, new CultureInfo("pt-BR")), Convert.ToInt32(funcionario.NDependentes)));
                    labelIRRF.Visible = true;
                    labelBaseIRRF.Visible = true;
                    dependentes = funcionario.NDependentes;
                    VT = Convert.ToDouble(funcionario.VTransporte);
                    VR = Convert.ToDouble(funcionario.VRefeicao);
                    VA = Convert.ToDouble(funcionario.VAlimentacao);
                    addNoturno = Convert.ToDouble(funcionario.AddNoturno);
                    return true;
                }
                else
                {
                    c.Enabled = false;
                    return false;
                }
            }
            
        }

        private void FormGerarFolha_Load(object sender, EventArgs e)
        {
           

        }

        private void referencia1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números, tecla de controle (por exemplo, Backspace) 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void referencia1_SelectedIndexChanged(object sender, EventArgs e)
        {

            CRUDReferencias referencias = new CRUDReferencias();
            referencia1Nome.Text = referencias.DescricaRef(referencia1.Text);
            try
            {
                int teste1 = Convert.ToInt32(referencia1.Text);
                if (teste1 < 2000)
                {
                    textBox29.Enabled = true;
                    textBox29.Text = "0";
                    textBox36.Enabled = false;
                    textBox36.Text = "0";
                    if (referencia1.Text == "1002")
                    {
                        textBox22.Text = "30";
                    }
                }
                else
                {
                    textBox29.Enabled = false;
                    textBox29.Text = "0";
                    textBox36.Enabled = true;
                    textBox36.Text = "0";
                }
            }
            catch (Exception)
            { 
            }
        }
        
        private void referencia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia2Nome.Text = referencias.DescricaRef(referencia2.Text);
            try
            {
                int teste1 = Convert.ToInt32(referencia2.Text);
                if (teste1 < 2000)
                {
                    textBox28.Enabled = true;
                    textBox28.Text = "0";
                    textBox35.Enabled = false;
                    textBox35.Text = "0";
                }
                else
                {
                    textBox28.Enabled = false;
                    textBox28.Text = "0";
                    textBox35.Enabled = true;
                    textBox35.Text = "0";
                }
            }
            catch (Exception)
            {
            }
        }

        private void referencia3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia3Nome.Text = referencias.DescricaRef(referencia3.Text);
            try
            {
                int teste1 = Convert.ToInt32(referencia3.Text);
                if (teste1 < 2000)
                {
                    textBox27.Enabled = true;
                    textBox27.Text = "0";
                    textBox34.Enabled = false;
                    textBox34.Text = "0";
                }
                else
                {
                    textBox27.Enabled = false;
                    textBox27.Text = "0";
                    textBox34.Enabled = true;
                    textBox34.Text = "0";
                }
            }
            catch (Exception)
            {
            }
        }

        private void referencia4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia4Nome.Text = referencias.DescricaRef(referencia4.Text);
           
            try
            {
                int teste1 = Convert.ToInt32(referencia4.Text);
                if (teste1 < 2000)
                {
                    textBox26.Enabled = true;
                    textBox26.Text = "0";
                    textBox33.Enabled = false;
                    textBox33.Text = "0";
                }
                else
                {
                    textBox26.Enabled = false;
                    textBox26.Text = "0";
                    textBox33.Enabled = true;
                    textBox33.Text = "0";
                }
            }
            catch (Exception)
            {
            }
        }

        private void referencia5_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia5Nome.Text = referencias.DescricaRef(referencia5.Text);
            try
            {
                int teste1 = Convert.ToInt32(referencia5.Text);
                if (teste1 < 2000)
                {
                    textBox25.Enabled = true;
                    textBox25.Text = "0";
                    textBox32.Enabled = false;
                    textBox32.Text = "0";
                }
                else
                {
                    textBox25.Enabled = false;
                    textBox25.Text = "0";
                    textBox32.Enabled = true;
                    textBox32.Text = "0";
                }
            }
            catch (Exception)
            {
            }
        }

        private void referencia6_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia6Nome.Text = referencias.DescricaRef(referencia6.Text);
            try
            {
                int teste1 = Convert.ToInt32(referencia6.Text);
                if (teste1 < 2000)
                {
                    textBox24.Enabled = true;
                    textBox24.Text = "0";
                    textBox31.Enabled = false;
                    textBox31.Text = "0";
                }
                else
                {
                    textBox24.Enabled = false;
                    textBox31.Text = "0";
                    textBox31.Enabled = true;
                    textBox31.Text = "0";
                }
            }
            catch (Exception)
            {
            }
        }

        private void referencia7_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDReferencias referencias = new CRUDReferencias();
            referencia7Nome.Text = referencias.DescricaRef(referencia7.Text);
            try
            {
                int teste1 = Convert.ToInt32(referencia7.Text);
                if (teste1 < 2000)
                {
                    textBox23.Enabled = true;
                    textBox23.Text = "0";
                    textBox30.Enabled = false;
                    textBox30.Text = "0";
                }
                else
                {
                    textBox23.Enabled = false;
                    textBox23.Text = "0";
                    textBox30.Enabled = true;
                    textBox30.Text = "0";
                }
            }
            catch (Exception)
            {
            }
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

        public decimal FGTSCalculo(string salarioBase)
        {

            double resultado = Convert.ToDouble(salarioBruto);
            resultado = resultado * 0.08 ;

            labelFGTSMes.Text = resultado.ToString("C2");
            return (decimal)resultado;
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
            labelBaseIRRF.Text = calculoIRRF.ToString("C2");

            calculoIRRF = calculoIRRF - 2112.01m ;
            //MessageBox.Show($"IRRF base = {calculoIRRF}");
            decimal irrf;

            if (salarioBruto <= 2112.00m)
            {
                irrf = 0;
                labelIRRF.Text = "Isento";
            }
            else if (salarioBruto <= 2826.65m)
            {
                irrf = calculoIRRF * 0.075m;
                labelIRRF.Text = "7,5%";
            }
            else if (salarioBruto <= 3751.05m)
            {
                irrf = calculoIRRF * 0.15m ;
                labelIRRF.Text = "15%";
            }
            else if (salarioBruto <= 4664.68m)
            {
                irrf = calculoIRRF * 0.225m;
                labelIRRF.Text = "22,5%";
            }
            else
            {
                irrf = calculoIRRF * 0.275m;
                labelIRRF.Text = "27,5%";
            }

            return irrf;
        }

        public double CalculoProventos()
        {
            double resultadoP, provento1, provento2, provento3, provento4, provento5, provento6, provento7;

            if (double.TryParse(textBox23.Text, out provento1) &&
                double.TryParse(textBox24.Text, out provento2) &&
                double.TryParse(textBox25.Text, out provento3) &&
                double.TryParse(textBox26.Text, out provento4) &&
                double.TryParse(textBox27.Text, out provento5) &&
                double.TryParse(textBox28.Text, out provento6) &&
                double.TryParse(textBox29.Text, out provento7))
            {
                // Todas as conversões foram bem-sucedidas
                resultadoP = provento1 + provento2 + provento3 + provento4 + provento5 + provento6 + provento7;
                labelTotal.Text = resultadoP.ToString("F2");
                // Faça o que precisar com resultadoP
            }
            else
            {
                // Tratar o caso em que a conversão falhou
                // Por exemplo, exibir uma mensagem de erro ao usuário
                //MessageBox.Show("Pelo menos um dos valores inseridos não é um número válido.");
                resultadoP = 0;
            }



            return resultadoP;
        }
        public double CalculoDescontos()
        {
            double resultadoP, provento1, provento2, provento3, provento4, provento5, provento6, provento7;

            if (double.TryParse(textBox30.Text, out provento1) &&
                double.TryParse(textBox31.Text, out provento2) &&
                double.TryParse(textBox32.Text, out provento3) &&
                double.TryParse(textBox33.Text, out provento4) &&
                double.TryParse(textBox34.Text, out provento5) &&
                double.TryParse(textBox35.Text, out provento6) &&
                double.TryParse(textBox36.Text, out provento7))
            {
                // Todas as conversões foram bem-sucedidas
                resultadoP = provento1 + provento2 + provento3 + provento4 + provento5 + provento6 + provento7;
                labelTotalDesconto.Text = resultadoP.ToString("F2");
                // Faça o que precisar com resultadoP
            }
            else
            {
                // Tratar o caso em que a conversão falhou
                // Por exemplo, exibir uma mensagem de erro ao usuário
                //MessageBox.Show("Pelo menos um dos valores inseridos não é um número válido.");
                resultadoP = 0;
            }



            return resultadoP;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            var resultado = CalculosFolha(referencia1.Text, textBox22.Text);
            string campo1 = resultado.Item1;
            string campo2 = resultado.Item2;
            int verificador = resultado.Item3;
            if (verificador == 1)
            {
                textBox29.Text = campo2;
            }
            else
            {
                textBox36.Text = campo2;
            }

            
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            var resultado = CalculosFolha(referencia2.Text, textBox21.Text);
            string campo1 = resultado.Item1;
            string campo2 = resultado.Item2;
            int verificador = resultado.Item3;
            if (verificador == 1)
            {
                textBox28.Text = campo2;
            }
            else
            {
                textBox35.Text = campo2;
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            var resultado = CalculosFolha(referencia3.Text, textBox20.Text);
            string campo1 = resultado.Item1;
            string campo2 = resultado.Item2;
            int verificador = resultado.Item3;
            if (verificador == 1)
            {
                textBox27.Text = campo2;
            }
            else
            {
                textBox34.Text = campo2;
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            var resultado = CalculosFolha(referencia4.Text, textBox19.Text);
            string campo1 = resultado.Item1;
            string campo2 = resultado.Item2;
            int verificador = resultado.Item3;
            if (verificador == 1)
            {
                textBox26.Text = campo2;
            }
            else
            {
                textBox33.Text = campo2;
            }
        }

        private void referencia5_TextChanged(object sender, EventArgs e)
        {
            var resultado = CalculosFolha(referencia5.Text, textBox18.Text);
            string campo1 = resultado.Item1;
            string campo2 = resultado.Item2;
            int verificador = resultado.Item3;
            if (verificador == 1)
            {
                textBox25.Text = campo2;
            }
            else
            {
                textBox32.Text = campo2;
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            var resultado = CalculosFolha(referencia6.Text, textBox17.Text);
            string campo1 = resultado.Item1;
            string campo2 = resultado.Item2;
            int verificador = resultado.Item3;
            if (verificador == 1)
            {
                textBox24.Text = campo2;
            }
            else
            {
                textBox31.Text = campo2;
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            var resultado = CalculosFolha(referencia7.Text, textBox16.Text);
            string campo1 = resultado.Item1;
            string campo2 = resultado.Item2;
            int verificador = resultado.Item3;
            if (verificador == 1)
            {
                textBox23.Text = campo2;
            }
            else
            {
                textBox30.Text = campo2;
            }
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            if (textBox29.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox29.Text);
                textBox29.Text = usoGeral.ToString("F2");
                CalculoProventos();
            }
            else
            {
                textBox29.Text = "0";
                CalculoProventos();
            }
            CalculoProventos();
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            if (textBox28.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox28.Text);
                textBox28.Text = usoGeral.ToString("F2");
                CalculoProventos();
            }
            else
            {
                textBox28.Text = "0";
                CalculoProventos();
            }
            CalculoProventos();
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (textBox27.Text.Length > 0)
            {
                double txt = Convert.ToDouble(textBox27.Text);
                textBox27.Text = txt.ToString("F2");
                CalculoProventos();
            }
            else
            {
                textBox27.Text = "0";
                CalculoProventos();
            }
            CalculoProventos();
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            if (textBox26.Text.Length > 0)
            {
                double txt = Convert.ToDouble(textBox26.Text);
                textBox26.Text = txt.ToString("F2");
                CalculoProventos();
            }
            else
            {
                textBox26.Text = "0";
                CalculoProventos();
            }
            CalculoProventos();
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            if (textBox25.Text.Length > 0)
            {
                double txt = Convert.ToDouble(textBox25.Text);
                textBox25.Text = txt.ToString("F2");
                CalculoProventos();
            }
            else
            {
                textBox25.Text = "0";
                CalculoProventos();
            }
            CalculoProventos();
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (textBox24.Text.Length > 0)
            {
                double txt = Convert.ToDouble(textBox24.Text);
                textBox24.Text = txt.ToString("F2");
                CalculoProventos();
            }
            else
            {
                textBox24.Text = "0";
                CalculoProventos();
            }
            CalculoProventos();
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            if (textBox23.Text.Length > 0)
            {
                double txt = Convert.ToDouble(textBox23.Text);
                textBox23.Text = txt.ToString("F2");
                CalculoProventos();
            }
            else
            {
                textBox23.Text = "0";
                CalculoProventos();
            }
            CalculoProventos();
        }



        public (string,string, int) CalculosFolha(string cod, string referencia)
        {
            int verificar = Convert.ToInt32(cod);
            int referir = 0;
            if (referencia.Length > 0)
            {
                referir = Convert.ToInt32(referencia);
            }
            if(verificar < 2000)
            {
                if(verificar  == 1002)//salario mensal
                {
                    double salarioB = Convert.ToDouble(salarioBruto);
                    double salarioH, salarioD, result;
                    int diasTrabalhados;
                    
                    salarioD = salarioB / 30;

                    result = referir * salarioD;
                    
                    CalculoProventos();
                   
                    return (null, Convert.ToString(result), 1);
                }
                else if (verificar == 1003)// ferias
                {
                    double feriasPorMes = salarioBruto / 12;
                    double ferias = referir * feriasPorMes;
                    CalculoProventos();
                    return (null, Convert.ToString(ferias), 1);
                }
                else if (verificar == 1004)// decimo terceiro
                {
                    double feriasPorMes = salarioBruto / 12;
                    double ferias = referir * feriasPorMes;
                    return (null, Convert.ToString(ferias), 1);
                }
                else if (verificar == 1005)// adiantamento 13º
                {
                    double feriasPorMes = salarioBruto / 12;
                    double ferias = referir * feriasPorMes;
                    return (null, Convert.ToString(ferias), 1);
                }
                else if (verificar == 1006)// aviso previo
                {
                    return (null, null, 0);
                }
                else if (verificar == 1007)// insalubridade
                {
                    if (referir == 10 || referir == 20 || referir == 40)
                    {
                        if (referir == 10)
                        {
                            double valor = 1320 * (10 / 100);
                            return (null, valor.ToString("F2"), 1);

                        }
                        else if (referir == 20)
                        {
                            double valor = 1320 * (20 / 100);
                            return (null, valor.ToString("F2"), 1);
                        }
                        else
                        {
                            double valor = 1320 * (40 / 100);
                            return (null, valor.ToString("F2"), 1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("´Somente será aceito valores com 10, 20 ou 40 porcento!");
                        return (null, null, 0);
                    }

                }
                else if (verificar == 1008)// fgts
                {
                    double resultado = Convert.ToDouble(salarioBruto);
                    resultado = resultado * 0.08;
                    return (null, resultado.ToString("F2"), 1);
                }
                else if (verificar == 1009)// Vale transporte
                {
                    
                    return (null, VT.ToString("F2"), 1);
                }
                else if (verificar == 1010)// Vale Alimentação
                {
                    
                    return (null, VA.ToString("F2"), 1);
                }
                else if (verificar == 1011)// adicional noturno
                {
                    double valorH = salarioBruto / 190;
                    double feriasPorMes = salarioBruto / 12;
                    double ferias = referir * feriasPorMes;
                    return (null, addNoturno.ToString("F2"), 1);
                }
                else if (verificar == 1012)// hora extra 50%
                {
                    double valorH = ((salarioBruto / 190) * 0.50) * referir;
                    return (null, valorH.ToString("F2"), 1);
                }
                else if (verificar == 1013)// hora extra 100%
                {
                    double valorH = ((salarioBruto / 190) * 1) * referir;
                    return (null, valorH.ToString("F2"), 1);
                }
                else if (verificar == 1014)// periculosidade
                {
                    double valorP = salarioBruto * 0.30;
                    return (null, valorP.ToString("F2"), 1);
                }
                else if (verificar == 1015)// premiação
                {
                    return (null, null, 0);
                }
                else if (verificar == 1016)// participação de lucros
                {
                    return (null, null, 0);
                }
                else if (verificar == 1017)// abono salarial
                {
                    return (null, null, 0);
                }
                else if (verificar == 1018)// ferias
                {
                    return (null, null, 0);
                }
                else if (verificar == 1019)// ferias
                {
                    return (null, null, 0);
                }
                else if (verificar == 1001)// ferias
                {
                    return (null, null, 0);
                }
                else
                {
                    return (null, null, 0);
                }
                
            }
            else
            {
                if (verificar == 2001)//irrf
                {
                    decimal valor =  CalculoIRRF(Convert.ToDecimal(salarioBruto), Convert.ToInt32(dependentes));

                    return (null, valor.ToString("F2"),2 );

                }
                else if (verificar == 2002)// inss
                {
                    decimal valor = CalculoInss(Convert.ToDecimal(salarioBruto));
                    return (null, valor.ToString("F2"), 2);
                }
                else if (verificar == 2003)// ferias
                {
                    return (null,null, 2);
                }
                
                else
                {
                    return (null, null, 0);
                }
            }

        }

        private void labelTotal_TabIndexChanged(object sender, EventArgs e)
        {
            SomaFinal();
        }

        private void labelTotalDesconto_TextChanged(object sender, EventArgs e)
        {
            SomaFinal();
        }
        public void SomaFinal()
        {
            double resultado, soma, descontos;
            descontos = Convert.ToDouble(labelTotalDesconto.Text);
            soma = Convert.ToDouble(labelTotal.Text);

            resultado = soma - descontos;
            labelTotalLiquido.Text = resultado.ToString("F2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            if (textBox36.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox36.Text);
                textBox36.Text = usoGeral.ToString("F2");
                CalculoDescontos();
            }
            else
            {
                textBox36.Text = "0";
                CalculoDescontos();
            }
           
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            if (textBox35.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox35.Text);
                textBox35.Text = usoGeral.ToString("F2");
                CalculoDescontos();
            }
            else
            {
                textBox35.Text = "0";
                CalculoDescontos();
            }
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            if (textBox34.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox34.Text);
                textBox34.Text = usoGeral.ToString("F2");
                CalculoDescontos();
            }
            else
            {
                textBox34.Text = "0";
                CalculoDescontos();
            }
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            if (textBox33.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox33.Text);
                textBox33.Text = usoGeral.ToString("F2");
                CalculoDescontos();
            }
            else
            {
                textBox23.Text = "0";
                CalculoDescontos();
            }
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            if (textBox32.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox32.Text);
                textBox32.Text = usoGeral.ToString("F2");
                CalculoDescontos();
            }
            else
            {
                textBox32.Text = "0";
                CalculoDescontos();
            }
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            if (textBox31.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox31.Text);
                textBox31.Text = usoGeral.ToString("F2");
                CalculoDescontos();
            }
            else
            {
                textBox31.Text = "0";
                CalculoDescontos();
            }
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            if (textBox30.Text.Length > 0)
            {
                usoGeral = Convert.ToDouble(textBox30.Text);
                textBox30.Text = usoGeral.ToString("F2");
                CalculoDescontos();
            }
            else
            {
                textBox30.Text = "0";
                CalculoDescontos();
            }
        }
    }
}

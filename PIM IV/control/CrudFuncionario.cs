using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV.control
{
    internal class CrudFuncionario
    {
        public string Codigo { get; set; }
        public string Cpf { get; set; }
        public string DataAdimicao { get; set; }
        public string DataNascimento { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Cidade {  get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cod_empresa { get; set; }
        public string Cod_cargo { get; set; }
        public string Salario { get; set; }
        public string VTransporte { get; set; }
        public string PlanoSaude { get; set; }
        public string VRefeicao { get; set; }
        public string VAlimentacao { get; set; }
        public string AddPericulosidade { get; set; }
        public string AddNoturno { get; set; }
        public string Inss { get; set; }
        public string DescontoSindical { get; set; }
        public string Cod_banco { get; set; }
        public string NomeBanco { get; set; }
        public string AgenciaBanco { get; set; }
        public string NConta { get; set; }

        public void CadastrarFuncionario()
        {
            if (VerificaFuncionarios())
            {
                SqlParameter paramNome = new SqlParameter();
                paramNome.ParameterName = "@Nome";
                paramNome.Value = Nome;

                SqlParameter paramCpf = new SqlParameter();
                paramCpf.ParameterName = "@CPF";
                paramCpf.Value = Cpf;

                SqlParameter paramRua = new SqlParameter();
                paramRua.ParameterName = "@Rua";
                paramRua.Value = Rua;

                SqlParameter paramCep = new SqlParameter();
                paramCep.ParameterName = "@Cep";
                paramCep.Value = Cep;

                SqlParameter paramNumero = new SqlParameter();
                paramNumero.ParameterName = "@Numero";
                paramNumero.Value = Numero;

                SqlParameter paramCidade = new SqlParameter();
                paramCidade.ParameterName = "@Cidade";
                paramCidade.Value = Cidade;

                SqlParameter paramEstado = new SqlParameter();
                paramEstado.ParameterName = "@Estado";
                paramEstado.Value = Estado;

                SqlParameter paramTelefone = new SqlParameter();
                paramTelefone.ParameterName = "@Telefone";
                paramTelefone.Value = Telefone;

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = Email;

                SqlParameter paramCodEmpresa = new SqlParameter();
                paramCodEmpresa.ParameterName = "@CodEmpresa";
                paramCodEmpresa.Value = Cod_empresa;

                SqlParameter paramCodCargo = new SqlParameter();
                paramCodCargo.ParameterName = "@CodCargo";
                paramCodCargo.Value = Cod_cargo;

                SqlParameter paramSalario = new SqlParameter();
                paramSalario.ParameterName = "@CodCargo";
                paramSalario.Value = Salario;

                SqlParameter paramRg = new SqlParameter();
                paramRg.ParameterName = "@RG";
                paramRg.Value = RG;

                SqlParameter paramAdimicao = new SqlParameter();
                paramAdimicao.ParameterName = "@Admicao";
                paramAdimicao.Value = DataAdimicao;

                SqlParameter paramAniversario = new SqlParameter();
                paramAniversario.ParameterName = "@Aniversario";
                paramAniversario.Value = DataNascimento;

                SqlParameter paramCodFun = new SqlParameter();
                paramCodFun.ParameterName = "@Cod_Fun";
                paramCodFun.Value = Codigo;

                SqlParameter paramTransporte = new SqlParameter();
                paramTransporte.ParameterName = "@Transporte";
                paramTransporte.Value = VTransporte;

                SqlParameter paramRefeicao = new SqlParameter();
                paramRefeicao.ParameterName = "@Refeicao";
                paramRefeicao.Value = VRefeicao;

                SqlParameter paramAlimentacao = new SqlParameter();
                paramAlimentacao.ParameterName = "@Alimentacao";
                paramAlimentacao.Value = VAlimentacao;

                SqlParameter paramPlanoSaude = new SqlParameter();
                paramPlanoSaude.ParameterName = "@Saude";
                paramPlanoSaude.Value = PlanoSaude;

                SqlParameter paramPericulosidade = new SqlParameter();
                paramPericulosidade.ParameterName = "@Periculosidade";
                paramPericulosidade.Value = AddPericulosidade;

                SqlParameter paramNoturno = new SqlParameter();
                paramNoturno.ParameterName = "@Noturno";
                paramNoturno.Value = AddNoturno;

                SqlParameter paramInss = new SqlParameter();
                paramInss.ParameterName = "@Noturno";
                paramInss.Value = Inss;

                SqlParameter paramCodBanco = new SqlParameter();
                paramCodBanco.ParameterName = "@CodBanco";
                paramCodBanco.Value = Cod_banco;

                SqlParameter paramNomeBanco = new SqlParameter();
                paramNomeBanco.ParameterName = "@NomeBanco";
                paramNomeBanco.Value = NomeBanco;

                SqlParameter paramAgencia = new SqlParameter();
                paramAgencia.ParameterName = "@Agencia";
                paramAgencia.Value = AgenciaBanco;

                SqlParameter paramNumConta = new SqlParameter();
                paramNumConta.ParameterName = "@NumConta";
                paramNumConta.Value = NConta;

                string comando = "INSERT into Funcionarios " +
                                  "(Cpf," +
                                  "RG," +
                                  "Nome," +
                                  "Rua," +
                                  "CEP," +
                                  "Numero," +
                                  "Cidade," +
                                  "Estado," +
                                  "Telefone," +
                                  "Email," +
                                  "Cod,"+
                                  "Data," +
                                  "Nome," +
                                  "Rua," +
                                  "CEP," +
                                  "Numero," +
                                  "Cidade," +
                                  "Estado," +
                                  "Telefone," +
                                  "Email," +
                                  "Cod," +
                                  "RG," +
                                  "Nome," +
                                  "Rua," +
                                  "CEP," +
                                  "Numero," +
                                  "Cidade," +
                                  "values " +
                                  "(@CNPJ," +
                                  " @Inscricao," +
                                  "@Nome," +
                                  "@Rua," +
                                  "@Cep," +
                                  "@Numero," +
                                  "@Cidade," +
                                  "@Estado," +
                                  "@Telefone," +
                                  "@Email," +
                                  "@Responsavel)";

                string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {
                            connection.Open();
                            cmd.Parameters.AddWithValue("@Nome", Nome);
                            cmd.Parameters.AddWithValue("@Rua", Rua);
                            cmd.Parameters.AddWithValue("@Cep", Cep);
                            cmd.Parameters.AddWithValue("@Numero", Numero);
                            cmd.Parameters.AddWithValue("@Cidade", Cidade);
                            cmd.Parameters.AddWithValue("@Estado", Estado);
                            cmd.Parameters.AddWithValue("@Telefone", Telefone);
                            cmd.Parameters.AddWithValue("@Email", Email);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cadastro realizado com sucesso!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                finally
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Close();
                }

            }
        }
        public bool VerificaFuncionarios()
        {
            string comando = "SELECT count(*) from Funcionario where CPF = '" + Cpf + "';";
            string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        connection.Open();
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("O CPF informado já possui cadastro na base de dados, informe um CPF diferente!");
                            return false;
                        }
                        else { return true; }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
            finally
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Close();
            }
        }
        public void AlterarFuncionario(string cod)
        {

        }
    }

}

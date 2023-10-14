using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        public string Nivel {  get; set; }
        public string Cod_User { get; set; }

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
                paramSalario.ParameterName = "@Salario";
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
                paramInss.ParameterName = "@INSS";
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

                SqlParameter paramSindical = new SqlParameter();
                paramSindical.ParameterName = "@Sindical";
                paramSindical.Value = DescontoSindical;

                SqlParameter paramCodUser = new SqlParameter();
                paramCodUser.ParameterName = "@CodUser";
                paramCodUser.Value = Cod_User;

                string comando = "INSERT into Funcionarios " +
                                  "(nome" +
                                  ",cpf " +
                                  ",rg " +
                                  ",data_nascimento " +
                                  ",rua " +
                                  ",cep " +
                                  ",numero " +
                                  ",estado " +
                                  ",cidade " +
                                  ",codigo_empresa " +
                                  ",codigo_cargo " +
                                  ",salario " +
                                  ",data_adimicao " +
                                  ",vale_transporte " +
                                  ",vale_alimentacao " +
                                  ",vale_refeicao " +
                                  ",PLANO_DE_SAUDE " +
                                  ",add_notuno " +
                                  ",add_perigo " +
                                  ",INSS " +
                                  ",DESCONTO_SINDICAL " +
                                  ",cod_banco " +
                                  ",nome_banco " +
                                  ",agencia " +
                                  ",n_conta " +
                                  ",telefone " +
                                  ",codigo_usuario"+
                                  ",email )" +
                                  "values " +
                                  "(@Nome" +
                                  ",@Cpf " +
                                  ",@RG " +
                                  ",@Aniversasrio " +
                                  ",@Rua " +
                                  ",@Cep " +
                                  ",@Numero " +
                                  ",@Estado " +
                                  ",@Cidade " +
                                  ",@CodEmpresa " +
                                  ",@CodCargo " +
                                  ",@Salario " +
                                  ",@Adimicao " +
                                  ",@Transporte " +
                                  ",@Alimentacao " +
                                  ",@Refeicao " +
                                  ",@Saude " +
                                  ",@Notuno " +
                                  ",@Periculosidade " +
                                  ",@INSS " +
                                  ",@Sindical " +
                                  ",@CodBanco " +
                                  ",@NomeBanco" +
                                  ",@Agencia " +
                                  ",@NumConta " +
                                  ",@Telefone " +
                                  ",@CodUser" +
                                  ",@Email )";

                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {
                            connection.Open();
                            cmd.Parameters.AddWithValue("@Nome", Nome);
                            cmd.Parameters.AddWithValue("@Cpf", Cpf);
                            cmd.Parameters.AddWithValue("@RG", RG);
                            cmd.Parameters.AddWithValue("@Rua", Rua);
                            cmd.Parameters.AddWithValue("@Cep", Cep);
                            cmd.Parameters.AddWithValue("@Numero", Convert.ToInt32(Numero));
                            cmd.Parameters.AddWithValue("@Cidade", Cidade);
                            cmd.Parameters.AddWithValue("@Estado", Estado);
                            cmd.Parameters.AddWithValue("@Telefone", Telefone);
                            cmd.Parameters.AddWithValue("@Email", Email);
                            cmd.Parameters.AddWithValue("@Aniversasrio", DataNascimento);
                            cmd.Parameters.AddWithValue("@CodEmpresa", Convert.ToInt32(Cod_empresa));
                            cmd.Parameters.AddWithValue("@CodCargo", Convert.ToInt32(Cod_cargo));
                            cmd.Parameters.AddWithValue("@Salario", Convert.ToDecimal(Salario));
                            cmd.Parameters.AddWithValue("@Adimicao", DataAdimicao);
                            cmd.Parameters.AddWithValue("@Transporte", Convert.ToDecimal(VTransporte));
                            cmd.Parameters.AddWithValue("@Alimentacao", Convert.ToDecimal(VAlimentacao));
                            cmd.Parameters.AddWithValue("@Refeicao", Convert.ToDecimal(VRefeicao));
                            cmd.Parameters.AddWithValue("@Saude", Convert.ToDecimal(PlanoSaude));
                            cmd.Parameters.AddWithValue("@Notuno", Convert.ToDecimal(AddNoturno));
                            cmd.Parameters.AddWithValue("@Periculosidade", Convert.ToDecimal(AddPericulosidade));
                            cmd.Parameters.AddWithValue("@INSS", Convert.ToDecimal(Inss));
                            cmd.Parameters.AddWithValue("@Sindical", Convert.ToDecimal(DescontoSindical));
                            cmd.Parameters.AddWithValue("@CodBanco", Convert.ToInt32(Cod_banco));
                            cmd.Parameters.AddWithValue("@NomeBanco", NomeBanco);
                            cmd.Parameters.AddWithValue("@Agencia", Convert.ToInt32(AgenciaBanco));
                            cmd.Parameters.AddWithValue("@NumConta", Convert.ToInt32(NConta));
                            cmd.Parameters.AddWithValue("@CodUser", Convert.ToInt32(Cod_User));


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
            string comando = "SELECT count(*) from Funcionarios where CPF = @Cpf;";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        cmd.Parameters.AddWithValue("@Cpf", Cpf);
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
        public void CriarUsuario(string nome, string senha, string nivel)
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

            string name = nome;
            int level = Convert.ToInt16(nivel);
            Criptografia md5 = new Criptografia();
            string password = md5.RetornaMD5(senha);

            // Criar objetos SqlParameter para cada parâmetro
            SqlParameter paramNome = new SqlParameter();
            paramNome.ParameterName = "@Name";
            paramNome.Value = name;

            SqlParameter paramSenha = new SqlParameter();
            paramSenha.ParameterName = "@Senha";
            paramSenha.Value = password;

            SqlParameter paramNivel = new SqlParameter();
            paramNivel.ParameterName = "@Nivel";
            paramNivel.Value = level;

            // Criando o SqlCommand com um parâmetro
            string cmd = "insert into Usuarios (Nome, SenhaHash, Nivel) values (@Name, @Senha, @Nivel) ";
            // adiciona o parametro ao comando 
            
            // Criar um objeto SqlCommand e associá-lo com a conexão e a consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.Parameters.AddWithValue("@Name", nome);
                    command.Parameters.AddWithValue("@Senha", password);
                    command.Parameters.AddWithValue("@Nivel", level);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }

        }

        public void BuscarUser(string cpf)
        {
            if (cpf != null)
            {
                
                SqlParameter paramCpf = new SqlParameter();
                paramCpf.ParameterName = "@Cpf";
                paramCpf.Value = Cpf;

                string comando = "SELECT cod_usuario," +
                    " FROM Usuarios " +
                    " WHERE nome = @Cpf ";
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {

                            cmd.Parameters.AddWithValue("@Cpf", Cpf);
                            connection.Open();

                            SqlDataReader data = cmd.ExecuteReader();
                            if (data.Read())
                            {
                                Cod_User = Convert.ToString(data["cod_usuario"]);
                                
                            }

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
    }

}

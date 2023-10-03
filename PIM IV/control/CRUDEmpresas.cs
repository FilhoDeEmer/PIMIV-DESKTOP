using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV.control
{
    internal class CRUDEmpresas
    {
        private string codigo;
        private string cnpj;
        private string nome;
        private string inscricaoEstadual;
        private string rua;
        private string cep;
        private int numero;
        private string cidade;
        private string estado;
        private string telefone;
        private string email;
        private string nomeResponsavel;

        

        public string Codigo { get => codigo; set => codigo = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string Nome { get => nome; set => nome = value; }
        public string InscricaoEstadual { get => inscricaoEstadual; set => inscricaoEstadual = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Cep { get => cep; set => cep = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string NomeResponsavel { get => nomeResponsavel; set => nomeResponsavel = value; }

        public void CadastraEmpresa()
        {
            if(VerificarEmpresa())
            {
                SqlParameter paramNome = new SqlParameter();
                paramNome.ParameterName = "@Nome";
                paramNome.Value = nome;

                SqlParameter paramCnpj = new SqlParameter();
                paramCnpj.ParameterName = "@CNPJ";
                paramCnpj.Value = cnpj;

                SqlParameter paramIncricao = new SqlParameter();
                paramIncricao.ParameterName = "@Inscricao";
                paramIncricao.Value = inscricaoEstadual;

                SqlParameter paramRua = new SqlParameter();
                paramRua.ParameterName = "@Rua";
                paramRua.Value = rua;

                SqlParameter paramCep = new SqlParameter();
                paramCep.ParameterName = "@Cep";
                paramCep.Value = cep;

                SqlParameter paramNumero = new SqlParameter();
                paramNumero.ParameterName = "@Numero";
                paramNumero.Value = numero;

                SqlParameter paramCidade = new SqlParameter();
                paramCidade.ParameterName = "@Cidade";
                paramCidade.Value = cidade;

                SqlParameter paramEstado = new SqlParameter();
                paramEstado.ParameterName = "@Estado";
                paramEstado.Value = estado;

                SqlParameter paramTelefone = new SqlParameter();
                paramTelefone.ParameterName = "@Telefone";
                paramTelefone.Value = telefone;

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = email;

                SqlParameter paramResponsavel = new SqlParameter();
                paramResponsavel.ParameterName = "@Responsavel";
                paramResponsavel.Value = nomeResponsavel;



                string comando = "INSERT into Empresas (CNPJ,Inscricao_estadual,Nome,Rua,CEP,Numero,Cidade,Estado,Telefone,Email,Nome_responsavel) values " +
                                                      "(@CNPJ, @Inscricao,@Nome,@Rua,@Cep,@Numero,@Cidade,@Estado,@Telefone,@Email,@Responsavel)";
                string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        
                        using (SqlCommand cmd = new SqlCommand(comando,connection))
                        {
                            connection.Open();
                            cmd.Parameters.AddWithValue("@Nome", nome);
                            cmd.Parameters.AddWithValue("@CNPJ", cnpj);
                            cmd.Parameters.AddWithValue("@Inscricao", inscricaoEstadual);
                            cmd.Parameters.AddWithValue("@Rua", rua);
                            cmd.Parameters.AddWithValue("@Cep", cep);
                            cmd.Parameters.AddWithValue("@Numero", (int)numero);
                            cmd.Parameters.AddWithValue("@Cidade", cidade);
                            cmd.Parameters.AddWithValue("@Estado", estado);
                            cmd.Parameters.AddWithValue("@Telefone", telefone);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Responsavel", nomeResponsavel);

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

        public void AlterarEmpresa(string cod)
        {
            if (cod!=null)
            {
                SqlParameter paramCod = new SqlParameter();
                paramCod.ParameterName = "@Cod";
                paramCod.Value = cod;

                SqlParameter paramNome = new SqlParameter();
                paramNome.ParameterName = "@Nome";
                paramNome.Value = nome;

                SqlParameter paramCnpj = new SqlParameter();
                paramCnpj.ParameterName = "@CNPJ";
                paramCnpj.Value = cnpj;

                SqlParameter paramIncricao = new SqlParameter();
                paramIncricao.ParameterName = "@Inscricao";
                paramIncricao.Value = inscricaoEstadual;

                SqlParameter paramRua = new SqlParameter();
                paramRua.ParameterName = "@Rua";
                paramRua.Value = rua;

                SqlParameter paramCep = new SqlParameter();
                paramCep.ParameterName = "@Cep";
                paramCep.Value = cep;

                SqlParameter paramNumero = new SqlParameter();
                paramNumero.ParameterName = "@Numero";
                paramNumero.Value = numero;

                SqlParameter paramCidade = new SqlParameter();
                paramCidade.ParameterName = "@Cidade";
                paramCidade.Value = cidade;

                SqlParameter paramEstado = new SqlParameter();
                paramEstado.ParameterName = "@Estado";
                paramEstado.Value = estado;

                SqlParameter paramTelefone = new SqlParameter();
                paramTelefone.ParameterName = "@Telefone";
                paramTelefone.Value = telefone;

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = email;

                SqlParameter paramResponsavel = new SqlParameter();
                paramResponsavel.ParameterName = "@Responsavel";
                paramResponsavel.Value = nomeResponsavel;



                string comando = "UPDATE  Empresas set CNPJ = @CNPJ," +
                    "Inscricao_estadual = @Inscricao," +
                    "Nome = @Nome," +
                    "Rua = @Rua," +
                    "CEP = @Cep," +
                    "Numero = @Numero," +
                    "Cidade = @Cidade," +
                    "Estado = @Estado," +
                    "Telefone = @Telefone," +
                    "Email = @Email," +
                    "Nome_responsavel = @Responsavel " +
                    " WHERE codigo_empresa = @Cod ;";
                string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {
                            
                            cmd.Parameters.AddWithValue("@Nome", nome);
                            cmd.Parameters.AddWithValue("@CNPJ", cnpj);
                            cmd.Parameters.AddWithValue("@Inscricao", inscricaoEstadual);
                            cmd.Parameters.AddWithValue("@Rua", rua);
                            cmd.Parameters.AddWithValue("@Cep", cep);
                            cmd.Parameters.AddWithValue("@Numero", (int)numero);
                            cmd.Parameters.AddWithValue("@Cidade", cidade);
                            cmd.Parameters.AddWithValue("@Estado", estado);
                            cmd.Parameters.AddWithValue("@Telefone", telefone);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Responsavel", nomeResponsavel);
                            cmd.Parameters.AddWithValue("@Cod", cod);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Empresa alterada com sucesso!");
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

        public void DeletarEmpresa(string cod)
        {
            if (cod != null)
            {
                SqlParameter paramCod = new SqlParameter();
                paramCod.ParameterName = "@Cod";
                paramCod.Value = cod;
                                
                string comando = "DELETE FROM Empresas WHERE codigo_empresa = @Cod ;";
                string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {
                            cmd.Parameters.AddWithValue("@Cod", cod);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Empresa DELETADA com sucesso!");
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

        public void BuscarEmpresa(string cod)
        {
            if (cod != null)
            {
                SqlParameter paramCod = new SqlParameter();
                paramCod.ParameterName = "@Cod";
                paramCod.Value = cod;

                SqlParameter paramCnpj = new SqlParameter();
                paramCnpj.ParameterName = "@CNPJ";
                paramCnpj.Value = cnpj;

                

                string comando = "SELECT CNPJ," +
                    "Inscricao_estadual," +
                    "Nome," +
                    "Rua," +
                    "CEP," +
                    "Numero," +
                    "Cidade," +
                    "Estado," +
                    "Telefone," +
                    "Email," +
                    "Nome_responsavel " +
                    " FROM Empresas " +
                    " WHERE codigo_empresa = @Cod ";
                string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {                            
                            
                            cmd.Parameters.AddWithValue("@Cod", cod);
                            connection.Open();

                            SqlDataReader data = cmd.ExecuteReader();
                            if(data.Read())
                            {
                              cnpj = Convert.ToString(data["CNPJ"]);
                              nome = Convert.ToString(data["Nome"]);
                              inscricaoEstadual = Convert.ToString(data["Inscricao_estadual"]);
                              rua = Convert.ToString(data["rua"]);
                              cep = Convert.ToString(data["cep"]);
                              numero = (int)(data["numero"]);
                              cidade = Convert.ToString(data["cidade"]);
                              estado = Convert.ToString(data["estado"]);
                              telefone = Convert.ToString(data["telefone"]);
                              email = Convert.ToString(data["email"]);
                              nomeResponsavel = Convert.ToString(data["Nome_responsavel"]);
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

        public string BuscarEmpresaCnpj(string cnpj)
        {
            if (cnpj != null)
            {
                            

                SqlParameter paramCnpj = new SqlParameter();
                paramCnpj.ParameterName = "@CNPJ";
                paramCnpj.Value = cnpj;

                
                string comando = "SELECT codigo_empresa from Empresas WHERE CNPJ = @CNPJ ";
                string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {

                            cmd.Parameters.AddWithValue("@CNPJ", cnpj);
                            connection.Open();

                            SqlDataReader data = cmd.ExecuteReader();
                            if (data.Read())
                            {
                                codigo = Convert.ToString(data["codigo_empresa"]);
                                return codigo;
                            }
                            else { return null; }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                    return null;
                }
                finally
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Close();
                }
            }
            else { return null; }
        }

        public bool VerificarEmpresa()
        {
            string comando = "SELECT count(*) from Empresas where CNPJ = '" + cnpj + "';";
            string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    using (SqlCommand cmd = new SqlCommand(comando,connection))
                    {
                        connection.Open();
                        int count = (int)cmd.ExecuteScalar();

                        if (count> 0)
                        {
                            MessageBox.Show("O CNPJ informado já possui cadastro na base de dados, informe um CNPJ diferente!");
                            return false;
                        }
                        else {  return true; }
                    }
                }
            }catch(Exception ex)
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




    }
}

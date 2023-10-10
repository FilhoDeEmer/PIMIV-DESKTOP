using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV.control
{
    internal class CrudEmpresas
    {

        public string Codigo { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string NomeResponsavel { get; set; }

        public void CadastraEmpresa()
        {
            if(VerificarEmpresa())
            {
                SqlParameter paramNome = new SqlParameter();
                paramNome.ParameterName = "@Nome";
                paramNome.Value = Nome;

                SqlParameter paramCnpj = new SqlParameter();
                paramCnpj.ParameterName = "@CNPJ";
                paramCnpj.Value = Cnpj;

                SqlParameter paramIncricao = new SqlParameter();
                paramIncricao.ParameterName = "@Inscricao";
                paramIncricao.Value = InscricaoEstadual;

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

                SqlParameter paramResponsavel = new SqlParameter();
                paramResponsavel.ParameterName = "@Responsavel";
                paramResponsavel.Value = NomeResponsavel;



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
                            cmd.Parameters.AddWithValue("@Nome", Nome);
                            cmd.Parameters.AddWithValue("@CNPJ", Cnpj);
                            cmd.Parameters.AddWithValue("@Inscricao", InscricaoEstadual);
                            cmd.Parameters.AddWithValue("@Rua", Rua);
                            cmd.Parameters.AddWithValue("@Cep", Cep);
                            cmd.Parameters.AddWithValue("@Numero", Numero);
                            cmd.Parameters.AddWithValue("@Cidade", Cidade);
                            cmd.Parameters.AddWithValue("@Estado", Estado);
                            cmd.Parameters.AddWithValue("@Telefone", Telefone);
                            cmd.Parameters.AddWithValue("@Email", Email);
                            cmd.Parameters.AddWithValue("@Responsavel", NomeResponsavel);

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
                paramNome.Value = Nome;

                SqlParameter paramCnpj = new SqlParameter();
                paramCnpj.ParameterName = "@CNPJ";
                paramCnpj.Value = Cnpj;

                SqlParameter paramIncricao = new SqlParameter();
                paramIncricao.ParameterName = "@Inscricao";
                paramIncricao.Value = InscricaoEstadual;

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

                SqlParameter paramResponsavel = new SqlParameter();
                paramResponsavel.ParameterName = "@Responsavel";
                paramResponsavel.Value = NomeResponsavel;



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
                            
                            cmd.Parameters.AddWithValue("@Nome", Nome);
                            cmd.Parameters.AddWithValue("@CNPJ", Cnpj);
                            cmd.Parameters.AddWithValue("@Inscricao", InscricaoEstadual);
                            cmd.Parameters.AddWithValue("@Rua", Rua);
                            cmd.Parameters.AddWithValue("@Cep", Cep);
                            cmd.Parameters.AddWithValue("@Numero", Numero);
                            cmd.Parameters.AddWithValue("@Cidade", Cidade);
                            cmd.Parameters.AddWithValue("@Estado", Estado);
                            cmd.Parameters.AddWithValue("@Telefone", Telefone);
                            cmd.Parameters.AddWithValue("@Email", Email);
                            cmd.Parameters.AddWithValue("@Responsavel", NomeResponsavel);
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
                paramCnpj.Value = Cnpj;

                

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
                              Cnpj = Convert.ToString(data["CNPJ"]);
                              Nome = Convert.ToString(data["Nome"]);
                              InscricaoEstadual = Convert.ToString(data["Inscricao_estadual"]);
                              Rua = Convert.ToString(data["rua"]);
                              Cep = Convert.ToString(data["cep"]);
                              Numero = (int)(data["numero"]);
                              Cidade = Convert.ToString(data["cidade"]);
                              Estado = Convert.ToString(data["estado"]);
                              Telefone = Convert.ToString(data["telefone"]);
                              Email = Convert.ToString(data["email"]);
                              NomeResponsavel = Convert.ToString(data["Nome_responsavel"]);
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
                                Codigo = Convert.ToString(data["codigo_empresa"]);
                                return Codigo;
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
            string comando = "SELECT count(*) from Empresas where CNPJ = '" + Cnpj + "';";
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

        public string BuscarEmpresaNome()
        {
                string comando = "SELECT nome from Empresas ";
                string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {

                            connection.Open();

                            SqlDataReader data = cmd.ExecuteReader();
                            if (data.Read())
                            {
                                Nome = Convert.ToString(data["nome"]);
                                return Nome;
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


    }
}

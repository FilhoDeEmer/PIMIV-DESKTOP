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
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";
                string comando = "INSERT INTO Empresas (CNPJ,Inscricao_estadual,Nome,Rua,CEP,Numero,Cidade,Estado,Telefone,Email,Nome_responsavel)" +
                                " VALUES (@CNPJ, @Inscricao,@Nome,@Rua,@Cep,@Numero,@Cidade,@Estado,@Telefone,@Email,@Responsavel);";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(comando,connection))
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

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cadastro realizado com sucesso!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                               
            }
        }

        public void AlterarEmpresa(string cod)
        {
            if (cod!=null)
            {
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
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
                catch(SqlException)//0x80131904
                {
                    MessageBox.Show("Não é possível excluir esta empresa, pois existem cargos associados a ela.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                
            }
        }

        public void BuscarEmpresa(string cod)
        {
            if (cod != null)
            {
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
                    " WHERE codigo_empresa = @Cod ;";
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
               
            }
        }

        public class Empresas
        {
            public string NomeEmpresa { get; set; }
            public string CodEmpresa { get; set; }
        }

        public List<Empresas> BuscarEmpresas()
        {
            List<Empresas> empresas = new List<Empresas>();


            string comando = "SELECT Nome, codigo_empresa FROM Empresas; ";
                   
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(comando, connection))
                {

                    connection.Open();

                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        Empresas empresa = new Empresas
                        {
                            NomeEmpresa = data["nome"].ToString(),
                            CodEmpresa = data["codigo_empresa"].ToString()
                        };
                        empresas.Add(empresa);
                    }
                }
            }
            return empresas;
        }

        public string BuscarEmpresaCnpj(string cnpj)
        {
            if (cnpj != null)
            {
                            

                SqlParameter paramCnpj = new SqlParameter();
                paramCnpj.ParameterName = "@CNPJ";
                paramCnpj.Value = cnpj;

                
                string comando = "SELECT codigo_empresa from Empresas WHERE CNPJ = @CNPJ ";
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
            string comando = "SELECT count(*) from Empresas where CNPJ = @Cnpj;";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(comando,connection))
                    {
                        cmd.Parameters.AddWithValue("@Cnpj", Cnpj);
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
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
        public string BuscarEmpresaNomeById(string cod)
        {
            string comando = "SELECT nome,cnpj from Empresas where codigo_empresa = @cod";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        cmd.Parameters.AddWithValue("@cod", cod);
                        connection.Open();

                        SqlDataReader data = cmd.ExecuteReader();
                        if (data.Read())
                        {
                            Nome = Convert.ToString(data["nome"]);
                            Cnpj = Convert.ToString(data["cnpj"]);
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


        public bool ContaEmpresa()
        {
            string comando = "SELECT count(*) from Empresas ;";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
                            return true;
                        }
                        else { return false; }
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

    }
}

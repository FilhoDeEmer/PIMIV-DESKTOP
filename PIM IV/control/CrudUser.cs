using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV.control
{
    internal class CrudUser
    {
        public string Nome { get; set; }
        public string Nivel { get; set; }
        public string Senha { get; set; }
        public string Cod { get; set; }
        public bool CriarNovoUsuario(string nome, string senha, int nivel)
        {
            if (VerificarUser(nome))
            {

                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                string name = nome;
                int level = nivel;
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
                string comando ="insert into Usuarios (Nome, SenhaHash, Nivel) values (@Name, @Senha, @Nivel) ";
                // adiciona o parametro ao comando 
                
                // Criar um objeto SqlCommand e associá-lo com a conexão e a consulta
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", nome);
                        cmd.Parameters.AddWithValue("@Senha", password);
                        cmd.Parameters.AddWithValue("@Nivel", level);
                        try
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cadastro Realizado com Sucesso");//Lembrar de apagar
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return false;

                        }
                        finally
                        {
                            connection.Close();
                        }

                    }
                }
            }
            else { return false; }

        }

        public bool VerificarUser(string cpf)
        {
            string comando = "SELECT count(*) from Usuarios where nome = @Nome;";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nome", cpf);
                        connection.Open();
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("O Usuário informado já possui cadastro na base de dados, informe um CNPJ diferente!");
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

        public string BuscarUser(string cpf)
        {
            string comando = "SELECT cod_usuario from Usuarios where nome = @Nome;";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nome", cpf);
                        connection.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        if (data.Read())
                        {
                            Cod = Convert.ToString(data["cod_usuario"]);
                            return Cod;
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

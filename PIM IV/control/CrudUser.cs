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
                // Gere o hash da senha usando BCrypt
                string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string sqlInsert = "INSERT INTO Usuarios (nome, SenhaHash, Nivel) VALUES (@nome, @senhaHash, @Nivel)";
                        using (SqlCommand command = new SqlCommand(sqlInsert, connection))
                        {
                            command.Parameters.AddWithValue("@nome", nome);
                            command.Parameters.AddWithValue("@senhaHash", senhaHash);
                            command.Parameters.AddWithValue("@Nivel", nivel);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao registrar novo usuário: " + ex.Message);
                }
                return true;

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

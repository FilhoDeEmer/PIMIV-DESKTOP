using Org.BouncyCastle.Crypto.Generators;
using PIM_IV.control;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using BCrypt.Net;
using System.Windows.Forms;

namespace PIM_IV
{
    internal class Login
    {

        public bool CheckLogin2(string getLogin, string getSenha)
        {
            string login1;
            string senhaVem;
            Criptografia conferirSenha = new Criptografia();

            login1 = getLogin;
            senhaVem = getSenha;
            bool result;
            string senhaVai = "";

            conferirSenha.RetornaMD5(senhaVem);//transforma senha em um md5
            string sqlLogin = "SELECT SenhaHash from Usuarios where nome = @Login1;";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlLogin, connection))
                    {
                        command.Parameters.AddWithValue("@Login1", login1);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                senhaVai = reader["SenhaHash"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            result = conferirSenha.ComparaMD5(senhaVem, senhaVai);
            if (result)
            { return true; }
            else { return false; }
        }

        public bool CheckLogin(string getLogin, string getSenha)
        {
            string login1 = getLogin;
            string senhaVem = getSenha;
            // Hash a senha inserida pelo usuário
            string senhaVemHash = HashSenha(senhaVem);
            // Configurar a string de conexão de forma segura
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use uma consulta parametrizada para evitar a injeção de SQL
                    string sqlLogin = "SELECT SenhaHash FROM Usuarios WHERE nome = @login";
                    using (SqlCommand command = new SqlCommand(sqlLogin, connection))
                    {
                        command.Parameters.AddWithValue("@login", login1);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtenha a senha hash do banco de dados
                                string senhaVai = reader["SenhaHash"].ToString();

                                // Compare as senhas com segurança
                                bool result = ComparaSenhas(senhaVemHash, senhaVai);

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao verificar o login: " + ex.Message);
            }

            return false; 
        }

        private string HashSenha(string senha)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(senha);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool ComparaSenhas(string senhaInserida, string senhaArmazenada)
        {
            StringComparer comparar = StringComparer.OrdinalIgnoreCase;//retorna ignorando o case sensitive

            if (comparar.Compare(senhaInserida, senhaArmazenada) == 0)
            {
                return true;
            }
            else { return false; }
            //return senhaInserida == senhaArmazenada;
        }

        public bool CheckLogin3(string getLogin, string getSenha)
        {
            string login1 = getLogin;
            string senhaVem = getSenha;

            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + "\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlLogin = "SELECT SenhaHash FROM Usuarios WHERE nome = @login";
                    using (SqlCommand command = new SqlCommand(sqlLogin, connection))
                    {
                        command.Parameters.AddWithValue("@login", login1);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string senhaVai = reader["SenhaHash"].ToString();

                                if (BCrypt.Net.BCrypt.Verify(senhaVem, senhaVai))
                                {
                                    return true; // Senha válida
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao verificar o login: " + ex.Message);
            }

            return false; // Senha inválida ou erro
        }

        public void RegistrarNovoUsuario(string nome, string senha, int level)//não usado
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
                        command.Parameters.AddWithValue("@senhaHash", level);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao registrar novo usuário: " + ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Specialized;
using static System.Net.Mime.MediaTypeNames;

namespace PIM_IV
{
    internal class DBcommand
    {
        SqlConnection connection;
        SqlCommand cmd;

        
        string strCmd;

        public void Connection()
        {
            connection = new SqlConnection(@"Server=EMERSON\SQLEXPRESS;Database=PIMIII;User Id=sa;Password='Eme13081998';");
            try
            {
                connection.Open();
                MessageBox.Show("Conexao pronta");
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

        public string CmdLogin(string username, string password)
        {
            string login = username;
            string senha = password;
            string result;
            string nomeUser, senhaUser;


            connection = new SqlConnection(@"Server=EMERSON\SQLEXPRESS;Database=PIMIII;User Id=sa;Password='Eme13081998';");
            SqlDataReader reader = null;

            // Criar objetos SqlParameter para cada parâmetro
            SqlParameter paramLogin = new SqlParameter();
            paramLogin.ParameterName = "@Login";
            paramLogin.Value = login;

            SqlParameter paramSenha = new SqlParameter();
            paramSenha.ParameterName = "@Senha";
            paramSenha.Value = senha;

            // Criando o SqlCommand com um parâmetro
             cmd = new SqlCommand(
            "select login, senha from teste where login= @Login and senha = @Senha", connection);
               
            
            // Criar um objeto SqlCommand e associá-lo com a conexão e a consulta
            using (connection)
            {
                using (cmd)
                {
                    // Adicionar os parâmetros ao comando
                    cmd.Parameters.Add(paramLogin);
                    cmd.Parameters.Add(paramSenha);

                    // Abrir a conexão e executar a consulta
                    try
                    {
                        connection.Open();
                         reader = cmd.ExecuteReader();

                        // Processar os resultados
                        while (reader.Read())
                        {
                            // Acessar os dados recuperados
                            Console.WriteLine("{0},{1}",
                                reader["Login"],
                                reader["Senha"]);
                            //nomeUser = reader["Login"];
                            //senhaUser = reader["Senha"];

                            // Realizar alguma ação com os dados
                            
                        }
                        result = (string)reader["Login"];
                        MessageBox.Show(result);
                        return result;
                        


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return "false";
                    }
                    finally
                    { // Fecha o datareader
                        if (reader != null)
                        {
                            reader.Close();
                        }

                        // Fecha a conexão
                        if (connection != null)
                        {
                            connection.Close();
                        }
                    }
                    
                    
                }
            }


           

        }


    }
}

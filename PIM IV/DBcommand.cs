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
using System.Data;

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


            connection = new SqlConnection(@"Server=EMERSON\SQLEXPRESS;Database=PIMIII;User Id=sa;Password='Eme13081998';");
            SqlDataReader reader = null;

            // Criar objetos SqlParameter para cada parâmetro
            SqlParameter paramLogin = new SqlParameter();
            paramLogin.ParameterName = "@Login";
            paramLogin.Value = login;
                       

            // Criando o SqlCommand com um parâmetro
            cmd = new SqlCommand(
           "select * from teste where login= @Login ", connection);
            // adiciona o parametro ao comando 
            cmd.Parameters.AddWithValue("@login", login);

            // Criar um objeto SqlCommand e associá-lo com a conexão e a consulta
            using (connection)
            {
                using (cmd)
                {

                    try
                    {
                        connection.Open();
                        using (reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["senha"].ToString() == senha)
                                {
                                    return reader["login"].ToString();
                                }
                                else
                                {
                                    return result = "Senha inválida!";
                                }
                            }
                            else
                            {
                                result = "Usuário não encontrado!";
                                return result;
                            }
                        }
                     }catch (Exception ex)
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
        }// fecha o metodo CmdLogin


        public void cadFuncionario(string nome, string cpf)
        {
            connection = new SqlConnection(@"Server=EMERSON\SQLEXPRESS;Database=PIMIII;User Id=sa;Password='Eme13081998';");
            SqlDataReader reader = null;

            // Criar objetos SqlParameter para cada parâmetro
            SqlParameter paramNome = new SqlParameter();
            paramNome.ParameterName = "@Nome";
            paramNome.Value = nome;

            SqlParameter paramCPF = new SqlParameter();
            paramCPF.ParameterName = "@cpf";
            paramCPF.Value = cpf;

            // Criando o SqlCommand com um parâmetro
            cmd = new SqlCommand(
           "insert into FUNCIONARIOS_teste (nome, CPF) values (@Nome, @CPF) ", connection);
            // adiciona o parametro ao comando 
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@CPF", cpf);

            // Criar um objeto SqlCommand e associá-lo com a conexão e a consulta
            using (connection)
            {
                using (cmd)
                {

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cadastro Realizado com Sucesso");
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
      
    } 
}

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PIM_IV
{
    internal class Login
    {


        private string login1 { get; set; }
        private string senha { get; set; }

        public bool CheckLogin(string getLogin, string getSenha)
        {
            login1 = getLogin;
            senha = getSenha;
            bool result = false;

            string connectionString = @"Data Source = EMERSON\SQLEXPRESS; Initial Catalog = PIMIII; User ID = EMERSON\eme_s; Password ='' ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    SqlCommand sqlLogin = new SqlCommand("SELECT * from teste where login = '" + login1 + "'and senha= '" + senha + "';", connection);
                    connection.Open();
                    SqlDataReader dados = sqlLogin.ExecuteReader();
                    result = dados.HasRows;
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
            return result;



        }
    }
}

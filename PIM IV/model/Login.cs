using PIM_IV.control;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PIM_IV
{
    internal class Login
    {


        string login1;
        string senhaVem;

        public bool CheckLogin(string getLogin, string getSenha)
        {
            Criptografia conferirSenha = new Criptografia();

            login1 = getLogin;
            senhaVem = getSenha;
            bool result;
            string senhaVai ="";

            conferirSenha.RetornaMD5(senhaVem);//transforma senha em um md5
            string sqlLogin = "SELECT SenhaHash from Usuarios where nome = '" + login1 + "';";
            string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlLogin, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while(reader.Read())
                            {
                                 senhaVai = reader["SenhaHash"].ToString();
                            }                        
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            result = conferirSenha.ComparaMD5(senhaVem, senhaVai);
            if(result)
            { return true; }
            else { return false; }
        }
    }
}

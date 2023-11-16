using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV.control
{
    internal class CRUDReferencias
    {
        public class Referencias
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; }
        }

        public List<Referencias> GetListCod()
        {
            List<Referencias> codigos = new List<Referencias>();
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = "SELECT codigo, descricao FROM Referencias";
                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Referencias codigo = new Referencias
                            {
                                Codigo = Convert.ToInt32(reader["codigo"]),
                                Descricao = reader["descricao"].ToString()
                            };
                            codigos.Add(codigo);
                        }
                    }
                }
                return codigos;
            }
        }

        public string DescricaRef(string cod)
        {
            string comando = "SELECT descricao from Referencias where codigo = @cod";
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
                            string Nome = Convert.ToString(data["descricao"]);
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
        }
        
    }
}

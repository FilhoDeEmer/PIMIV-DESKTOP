using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PIM_IV.control
{
    internal class CrudCargos
    {
        public void CadastrarCargo(string nome, decimal salario, int cod)
        {
            if (VerificarCargo(nome))
            {

                SqlParameter paramNome = new SqlParameter();
                paramNome.ParameterName = "@Nome";
                paramNome.Value = nome;

                SqlParameter paramSalario = new SqlParameter();
                paramSalario.ParameterName = "@Salario";
                paramSalario.Value = salario;

                SqlParameter paramCodEmpresa = new SqlParameter();
                paramCodEmpresa.ParameterName = "@CodEmpresa";
                paramCodEmpresa.Value = cod;



                string comando = "INSERT into Cargos (nome,salario_base,codigo_empresa) values " +
                                                      "(@Nome,@Salario,@CodEmpresa)";
                string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {
                            connection.Open();
                            cmd.Parameters.AddWithValue("@Nome", nome);
                            cmd.Parameters.AddWithValue("@Salario", salario);
                            cmd.Parameters.AddWithValue("@CodEmpresa", cod);

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
        public bool VerificarCargo(string nome)
        {
            string comando = "SELECT count(*) from Cargos where nome = '" + nome + "';";
            string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

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
                            MessageBox.Show("O Cargo informado já possui cadastro na base de dados, informe um Cargo diferente!");
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
        public void DeletaCargo(string cod)
        {
            if (cod != null)
            {
                SqlParameter paramCod = new SqlParameter();
                paramCod.ParameterName = "@Cod";
                paramCod.Value = cod;

                string comando = "DELETE FROM Cargos WHERE codigo_cargo = @Cod ;";
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
                            MessageBox.Show("Cargo DELETADA com sucesso!");
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
        public void AlteraCargo(string codCargo, string nome, decimal salario, int codEmpresa)
        {
            if (VerificarCargo(nome))
            {
                if (codCargo != null)
                {
                    SqlParameter paramCod = new SqlParameter();
                    paramCod.ParameterName = "@CodCargo";
                    paramCod.Value = codCargo;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = nome;

                    SqlParameter paramSalario = new SqlParameter();
                    paramSalario.ParameterName = "@Salario";
                    paramSalario.Value = salario;

                    SqlParameter paramCodEmpresa = new SqlParameter();
                    paramCodEmpresa.ParameterName = "@CodEmpresa";
                    paramCodEmpresa.Value = codEmpresa;



                    string comando = "UPDATE  Cargos set cod = @CodCargo," +
                        "Nome = @Nome," +
                        "Salario_base=@Salario " +
                        "codigo_empresa=@CodEmpresa " +
                        " WHERE codigo_cargo = @CodCargo ;";
                    string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {

                            using (SqlCommand cmd = new SqlCommand(comando, connection))
                            {
                                cmd.Parameters.AddWithValue("@Nome", nome);
                                cmd.Parameters.AddWithValue("@Salario", salario);
                                cmd.Parameters.AddWithValue("@CodEmpresa", codEmpresa);
                                cmd.Parameters.AddWithValue("@CodCargo", codCargo);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Cargo alterada com sucesso!");
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
        }

        
    }
}

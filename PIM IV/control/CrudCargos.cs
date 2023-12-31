﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Policy;

namespace PIM_IV.control
{
    internal class CrudCargos
    {
        public string CodCargo { get; set; }
        public string NomeCargo { get; set; }
        public string SalarioBase { get; set; }
        public string Codigo { get; set; }
        public string CodEmpresa { get; set; }

        //static string connectionString = @"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";
        public void CadastrarCargo(string nome, decimal salario, string cod)
        {
            int codConvertido = Convert.ToInt32(cod);

            string comando = "INSERT into Cargos (nome,salario_base,codigo_empresa) values " +
                                                  "(@Nome,@Salario,@CodEmpresa)";
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
            
        }
        public bool VerificarCargo(string nome)
        {
            string comando = "SELECT count(*) from Cargos where nome = @Nome;";

            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
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
        public void DeletaCargo()
        {
            if (Codigo != null)
            {
                string comando = "DELETE FROM Cargos WHERE codigo_cargo = @Cod ;";
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {
                            cmd.Parameters.AddWithValue("@Cod", Codigo);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cargo DELETADO com sucesso!");
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
        public void AlteraCargo(string codCargo)
        {
            if (codCargo != null)
            {

                string comando = "UPDATE  Cargos set " +
                    "Nome = @Nome," +
                    "Salario_base = @Salario, " +
                    "codigo_empresa = @CodEmpresa " +
                    " WHERE codigo_cargo = @CodCargo ;";
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {
                            cmd.Parameters.AddWithValue("@Nome", NomeCargo);
                            cmd.Parameters.AddWithValue("@Salario",Convert.ToDecimal(SalarioBase));
                            cmd.Parameters.AddWithValue("@CodEmpresa",CodEmpresa);
                            cmd.Parameters.AddWithValue("@CodCargo", Convert.ToInt32(codCargo));
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

        public bool ContaCargo()
        {
            string comando = "SELECT count(*) from Cargos;";
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

        public class Codigos
        {
            public int CodCargo { get; set; }
            public string NomeCargo { get; set; }
        }

        public List<Codigos> GetListCod(string empresa)
        {
            List<Codigos> codigos = new List<Codigos>();
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = "SELECT codigo_cargo, nome FROM Cargos WHERE codigo_empresa = @empresa";
                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@empresa", empresa);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Codigos codigo = new Codigos
                            {
                                CodCargo = Convert.ToInt32(reader["codigo_cargo"]),
                                NomeCargo = reader["nome"].ToString()
                            };
                            codigos.Add(codigo);
                        }


                    }
                }
                return codigos;
            }
        }
        public void BuscaCargo(string cod)
        {
            Codigo = cod;
            string comando = "SELECT nome, salario_base, codigo_empresa from Cargos where codigo_cargo = @cod";
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
                            NomeCargo = Convert.ToString(data["nome"]);
                            SalarioBase = Convert.ToString(data["salario_base"]);
                            CodEmpresa = Convert.ToString(data["codigo_empresa"]);

                        }
                        

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
        public class Cargos
        {
            public string Cod_Cargo { get; set; }
            public string  Nome { get; set; }
            public string Salario_Base { get; set; }
            public string Cod_Empresa { get; set; }
            public string NomeEmpresa { get; set; }
            
            

        }
        public List<Cargos> BuscaCargos()
        {
            List<Cargos> cargos = new List<Cargos>();

            string comando = @"select
                             C.[codigo_cargo],
                             C.[nome] as [Nome_Cargo],
                             C.[salario_base],
                             C.[codigo_empresa],
                             E.[nome] as [Nome_Empresa]
                             from [HERMES].[dbo].[Cargos] C
                             INNER JOIN [HERMES].[dbo].[Empresas] E on E.[codigo_empresa] = C.[codigo_empresa]";

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
                            Cargos cargo = new Cargos
                            {
                                Cod_Cargo = Convert.ToString(data["codigo_cargo"]),
                                Nome = Convert.ToString(data["nome_cargo"]),
                                Salario_Base = Convert.ToString(data["salario_base"]),
                                Cod_Empresa = Convert.ToString(data["codigo_empresa"]),
                                NomeEmpresa = Convert.ToString(data["nome_empresa"])
                                

                            };
                            cargos.Add(cargo);
                        }


                    }
                }
               return cargos;
            
            
        }
        public List<Cargos> BuscaCargos(string cod)
        {
            List<Cargos> cargos = new List<Cargos>();

            string comando = @"select
                             C.[codigo_cargo],
                             C.[nome] as [Nome_Cargo],
                             C.[salario_base],
                             C.[codigo_empresa],
                             E.[nome] as [Nome_Empresa]
                             from [HERMES].[dbo].[Cargos] C
                             INNER JOIN [HERMES].[dbo].[Empresas] E on E.[codigo_empresa] = C.[codigo_empresa]
                             where C.[codigo_empresa] = @Cod;";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(comando, connection))
                {
                    cmd.Parameters.AddWithValue("@cod", cod);
                    connection.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        Cargos cargo = new Cargos
                        {
                            Cod_Cargo = Convert.ToString(data["codigo_cargo"]),
                            Nome = Convert.ToString(data["nome_cargo"]),
                            Salario_Base = Convert.ToString(data["salario_base"]),
                            Cod_Empresa = Convert.ToString(data["codigo_empresa"]),
                            NomeEmpresa = Convert.ToString(data["nome_empresa"])

                        };
                        cargos.Add(cargo);
                    }


                }
            }
            return cargos;


        }
    }
}

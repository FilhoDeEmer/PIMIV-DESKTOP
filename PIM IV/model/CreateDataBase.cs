using Microsoft.Win32;
using PIM_IV.control;
using PIM_IV.view;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PIM_IV.model
{
    internal class CreateDataBase
    {
        private void CrearDB()//cria o banco de dados 
        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"; 

            string nomeBancoDeDados = "HERMES";

            string createDatabaseSql = $"CREATE DATABASE {nomeBancoDeDados}";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Cria o banco de dados
                    using (SqlCommand command = new SqlCommand(createDatabaseSql, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Banco de dados '{nomeBancoDeDados}' criado com sucesso.");
                        CrearTableEmpresa();
                        CrearTableCargos();
                        CrearTableUsuarios();
                        CrearTableFuncionarios();
                        CrearTableFolha();
                        CrearTableNotificacao();
                        CrearTableHolerite();
                        FormPrimeiroLogin init = new FormPrimeiroLogin();
                        init.ShowDialog();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o banco de dados: {ex.Message}");
               
            }
            finally
            {
                
            }
                        
        }


        public void VerificaDB() 
        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Integrated Security=True"; 

            // Nome do banco de dados que você deseja verificar
            string nomeBancoDeDados = "HERMES";

            string query = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{nomeBancoDeDados}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            Console.WriteLine($"O banco de dados '{nomeBancoDeDados}' existe.");
                        }
                        else
                        {
                            MessageBox.Show($"O banco de dados '{nomeBancoDeDados}' não existe.");
                            CrearDB();
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar a existência do banco de dados: {ex.Message}");
            }
        }

        private void CrearTableFuncionarios()//Cria a tabela Funcionarios
        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Funcionarios";
            string cmd = "(codigo_funcionario INT PRIMARY KEY NOT NULL IDENTITY(1, 1), "+
                         "codigo_empresa INT," +
                         "nome VARCHAR(255) NOT NULL," +
                         "cpf VARCHAR(14) NOT NULL," +
                         "rg VARCHAR(20)," +
                         "rua VARCHAR(255)," +
                         "cep VARCHAR(9)," +
                         "cidade VARCHAR(100)," +
                         "numero INT," +
                         "estado CHAR(2)," +
                         "email VARCHAR(255)," +
                         "telefone VARCHAR(15)," +
                         "vale_alimentacao DECIMAL(5, 2)," +
                         "vale_transporte DECIMAL(5, 2)," +
                         "vale_refeicao DECIMAL(5, 2)," +
                         "INSS DECIMAL(5, 2)," +
                         "PLANO_DE_SAUDE DECIMAL(5, 2)," +
                         "DESCONTO_SINDICAL DECIMAL(5, 2)," +
                         "salario DECIMAL(10,2)," +
                         "codigo_usuario INT," +
                         "codigo_cargo INT," +
                         "FOREIGN KEY (codigo_empresa) REFERENCES Empresas(codigo_empresa)," +
                         "FOREIGN KEY (codigo_usuario) REFERENCES Usuarios(cod_usuario)," +
                         "FOREIGN KEY (codigo_cargo) REFERENCES Cargos(codigo_cargo),)";

            string query = $"IF OBJECT_ID('{nomeTabela}', 'U') IS NULL CREATE TABLE {nomeTabela} {cmd}";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Tabela '{nomeTabela}' verificada/criada com sucesso.");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar/criar a tabela: {ex.Message}");
            }
        }

        private void CrearTableEmpresa()//Cria a tabela Empresas
        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Empresas";
            string cmd = "  (codigo_empresa INT PRIMARY KEY IDENTITY(1,1),"+
                            "CNPJ VARCHAR(18) NOT NULL,"+
                            "Inscricao_estadual VARCHAR(20),"+
                            "Nome VARCHAR(255) NOT NULL,"+
                            "rua VARCHAR(255),"+
                            "cep VARCHAR(9),"+
                            "cidade VARCHAR(100),"+
                            "numero INT,"+
                            "estado CHAR(2),"+
                            "email VARCHAR(255),"+
                            "telefone VARCHAR(15),"+
                            "Nome_responsavel VARCHAR(100)); ";

            string query = $"IF OBJECT_ID('{nomeTabela}', 'U') IS NULL CREATE TABLE {nomeTabela} {cmd}";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Tabela '{nomeTabela}' verificada/criada com sucesso.");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar/criar a tabela: {ex.Message}");
            }
        }

        private void CrearTableUsuarios()//Cria a tabela Usuarios
        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True"; 

            string nomeTabela = "Usuarios";
            string cmd = "(cod_usuario INT IDENTITY(1,1) PRIMARY KEY," +
                           "nome VARCHAR(255) NOT NULL," +
                           "SenhaHash VARCHAR(255) NOT NULL," +
                           "Nivel INT DEFAULT 1);";

            string query = $"IF OBJECT_ID('{nomeTabela}', 'U') IS NULL CREATE TABLE {nomeTabela} {cmd}";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Tabela '{nomeTabela}' verificada/criada com sucesso.");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar/criar a tabela: {ex.Message}");
            }

           
        }


        //alterar
        private void CrearTableHolerite()//Cria a tabela de referencias de holerite
        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Holerite";
            string cmd = "(cod_usuario INT IDENTITY(1,1) PRIMARY KEY," +
                           "nome NVARCHAR(255) NOT NULL," +
                           "SenhaHash VARBINARY(255) NOT NULL," +
                           "Nivel INT DEFAULT 1);";

            string query = $"IF OBJECT_ID('{nomeTabela}', 'U') IS NULL CREATE TABLE {nomeTabela} {cmd}";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Tabela '{nomeTabela}' verificada/criada com sucesso.");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar/criar a tabela: {ex.Message}");
            }
        }

        private void CrearTableFolha()//Cria a tabela Folha de pagamentos
        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "FolhaPagamentos";
            string cmd = "(codigo_folha INT PRIMARY KEY," +
                         "codigo_empresa INT," +
                         "codigo_funcionario INT," +
                         "FOREIGN KEY (codigo_empresa) REFERENCES Empresas (codigo_empresa)," +
                         "FOREIGN KEY (codigo_funcionario) REFERENCES Funcionarios (codigo_funcionario))";

            string query = $"IF OBJECT_ID('{nomeTabela}', 'U') IS NULL CREATE TABLE {nomeTabela} {cmd}";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Tabela '{nomeTabela}' verificada/criada com sucesso.");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar/criar a tabela: {ex.Message}");
            }
        }

        private void CrearTableCargos()//Cria a tabela cargos
        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Cargos";
            string cmd = "(codigo_cargo INT PRIMARY KEY IDENTITY(1,1)," +
                         "nome VARCHAR(255) NOT NULL," +
                         "salario_base DECIMAL(10, 2)," +
                         "codigo_empresa INT," +
                         "FOREIGN KEY (codigo_empresa) REFERENCES empresas(codigo_empresa))";

            string query = $"IF OBJECT_ID('{nomeTabela}', 'U') IS NULL CREATE TABLE {nomeTabela} {cmd}";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Tabela '{nomeTabela}' verificada/criada com sucesso.");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar/criar a tabela: {ex.Message}");
            }
        }


        //alterar
        private void CrearTableNotificacao()//Cria a tabela de notificações

        {
            string connectionString = "Data Source=EMERSON\\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Notificacao";
            string cmd = "(cod_usuario INT IDENTITY(1,1) PRIMARY KEY," +
                           "nome NVARCHAR(255) NOT NULL," +
                           "SenhaHash VARBINARY(255) NOT NULL," +
                           "Nivel INT DEFAULT 1);";

            string query = $"IF OBJECT_ID('{nomeTabela}', 'U') IS NULL CREATE TABLE {nomeTabela} {cmd}";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Tabela '{nomeTabela}' verificada/criada com sucesso.");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar/criar a tabela: {ex.Message}");
            }
        }


        public void CriarNovoUsuario(string nome, string senha, int nivel)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=EMERSON\SQLEXPRESS;Initial Catalog=HERMES;Integrated Security=True");
            
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
            SqlCommand cmd = new SqlCommand("insert into Usuarios (Nome, SenhaHash, Nivel) values (@Name, @Senha, @Nivel) ", connection);
            // adiciona o parametro ao comando 
            cmd.Parameters.AddWithValue("@Name", nome);
            cmd.Parameters.AddWithValue("@Senha", password);
            cmd.Parameters.AddWithValue("@Nivel", level);
            // Criar um objeto SqlCommand e associá-lo com a conexão e a consulta
            using (connection)
            {
                using (cmd)
                {

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cadastro Realizado com Sucesso");//Lembrar de apagar
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

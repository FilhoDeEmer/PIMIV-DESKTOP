using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using PIM_IV.control;
using PIM_IV.view;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PIM_IV.model
{
    internal class CreateDataBase
    {
       
        
        private void CrearDB()//cria o banco de dados 
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" +nomeServidor+ ";Initial Catalog=master;Integrated Security=True"; 
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
                        CrearTableEmpresa();
                        CrearTableCargos();
                        CrearTableUsuarios();
                        CrearTableFuncionarios();
                        CrearTableFolha();
                        Referencias();
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
            
                        
        }
       
        public void VerificaDB() 
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=master;Integrated Security=True";

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
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Funcionarios";
            string cmd = "(codigo_funcionario INT PRIMARY KEY NOT NULL IDENTITY(1, 1), "+
                         "nome VARCHAR(255) NOT NULL," +
                         "cpf VARCHAR(14) NOT NULL," +
                         "rg VARCHAR(20)," +
                         "data_nascimento varchar(10)," +
                         "rua VARCHAR(255)," +
                         "cep VARCHAR(9)," +
                         "numero INT," +
                         "n_dependentes int," +
                         "estado CHAR(2)," +
                         "cidade VARCHAR(100)," +
                         "codigo_empresa INT," +
                         "codigo_cargo INT," +
                         "salario DECIMAL(10,2)," +
                         "data_adimicao varchar(10)," +
                         "vale_transporte DECIMAL(5, 2)," +
                         "vale_alimentacao DECIMAL(5, 2)," +
                         "vale_refeicao DECIMAL(5, 2)," +
                         "PLANO_DE_SAUDE DECIMAL(5, 2)," +
                         "add_notuno DECIMAL (5,2)," +
                         "add_perigo DECIMAL (5,2)," +
                         "INSS DECIMAL(5, 2)," +
                         "cod_banco INT," +
                         "nome_banco varchar(255)," +
                         "agencia INT," +
                         "n_conta INT," +
                         "telefone VARCHAR(15)," +
                         "email VARCHAR(255)," +
                         "codigo_usuario INT," +
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
                MessageBox.Show($"Erro ao verificar/criar a tabela Funcionarios: {ex.Message}");
            }
        }

        private void CrearTableEmpresa()//Cria a tabela Empresas
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
                MessageBox.Show($"Erro ao verificar/criar a tabela Empresas: {ex.Message}");
            }
        }

        private void CrearTableUsuarios()//Cria a tabela Usuarios
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Usuarios";
            string cmd = "(cod_usuario INT IDENTITY(1,1) PRIMARY KEY," +
                           "login VARCHAR(255) NOT NULL," +
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
                MessageBox.Show($"Erro ao verificar/criar a tabela Usuarios: {ex.Message}");
            }

           
        }


        //alterar
        public void CrearTableHolerite()//Cria a tabela de referencias de holerite
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Holerite";
            string cmd = @"(COD_FOLHA INT PRIMARY KEY NOT NULL IDENTITY(1,1),
                            COD_EMPRESA INT NOT NULL,
                            COD_FUNCIONARIO INT NOT NULL,
	                        SALARIO NVARCHAR(255),
                            VALORPROVENTOS NVARCHAR(255),
                            VALORDESCONTOS NVARCHAR(255),
                            VALORLIQUIDO NVARCHAR(255),
                            FAIXAIRRF NVARCHAR(255),
                            FGTSMES NVARCHAR(255),
	                        MENSAGEM NVARCHAR(255),
                            FOREIGN KEY (COD_EMPRESA) REFERENCES Empresas(codigo_empresa),
                            FOREIGN KEY (COD_FUNCIONARIO) REFERENCES FUNCIONARIOS(codigo_funcionario)
	                        );";

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
                MessageBox.Show($"Erro ao verificar/criar a tabela Holerite: {ex.Message}");
            }
        }

        private void CrearTableFolha()//Cria a tabela Folha de pagamentos
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
                MessageBox.Show($"Erro ao verificar/criar a tabela FolhaPagamentos: {ex.Message}");
            }
        }

        private void CrearTableCargos()//Cria a tabela cargos
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

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
                MessageBox.Show($"Erro ao verificar/criar a tabela Cargos: {ex.Message}");
            }
        }


        //alterar
        public void CrearTableNotificacao()//Cria a tabela de notificações

        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            string nomeTabela = "Notificacao";
            string cmd = "(COD_FUNCIONARIO INT IDENTITY(1,1) PRIMARY KEY," +
                           "nome NVARCHAR(255) NOT NULL," +
                           "Mensagem NVARCHAR(255) NOT NULL," +
                           "Data DATETIME  NOT NULL DEFAULT GETDATE()," +
                           "FOREIGN KEY (COD_FUNCIONARIO) REFERENCES FUNCIONARIOS(codigo_funcionario));";

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
                MessageBox.Show($"Erro ao verificar/criar a tabela Notificacao: {ex.Message}");
            }
        }


        public void CriarNovoUsuario(string nome, string senha, int nivel)
        {
            // Gere o hash da senha usando BCrypt
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlInsert = "INSERT INTO Usuarios (login, SenhaHash, Nivel) VALUES (@nome, @senhaHash, @Nivel)";
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

        }

        public void DeletarDB()
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=master;Integrated Security=True";
            string nomeBancoDeDados = "HERMES";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();

                    string sqlDesconectarSessoes = $"ALTER DATABASE [{nomeBancoDeDados}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    using (SqlCommand cmdDesconectarSessoes = new SqlCommand(sqlDesconectarSessoes, connection))
                    {
                        cmdDesconectarSessoes.ExecuteNonQuery();
                    }

                    // Exclua o banco de dados
                    string sqlExcluirBanco = $"DROP DATABASE [{nomeBancoDeDados}]";
                    using (SqlCommand cmdExcluirBanco = new SqlCommand(sqlExcluirBanco, connection))
                    {
                        cmdExcluirBanco.ExecuteNonQuery();
                    }
                    MessageBox.Show("Banco de Dados não foi criado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o banco de dados: {ex.Message}");

            }

        }

        public void Referencias()
        {
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";
            
            string ciar = @"IF OBJECT_ID ('Referencias', 'U') IS NULL CREATE TABLE[dbo].[Referencias] (
                            [codigo][varchar](4) NOT NULL,
                            [descricao] [varchar] (255) NULL
                            ) ON[PRIMARY]";

            string inserir = @"INSERT INTO Referencias(codigo, Descricao)
                                VALUES
                                (1001, 'Adiantamento de salário (Em Real)'),
                                (1002, 'Salário mensalista (Em dias)'),
                                (1003, 'Férias (Em Meses)'),
                                (1004, 'Décimo Terceiro'),
                                (1005, 'Adiantamento_13º (1/2)'),
                                (1006, 'Aviso previo (Em dias)'),
                                (1007, 'Insalubridade (Porcentagem)'),
                                (1008, 'FGTS (Porcentagem)'),
                                (1009, 'Vale transporte (Valor)'),
                                (1010, 'Vale alimentacao (Valor)'),
                                (1011, 'Adicional noturno (porcentagem)'),
                                (1012, 'Hora extra 50% (Em Horas)'),
                                (1013, 'Horaextra 100% (Em Horas)'),
                                (1014, 'Periculosidade (Porcentagem)'),
                                (1015, 'Premiacao (Valor)'),
                                (1016, 'Participação nos lucros (Valor)'),
                                (1017, 'Abono salarial'),
                                (1018, 'Antecipação salarial'),
                                (1019, 'Plano de saúde'),
                                (2001, 'IRRF'),
                                (2002, 'Desconto INSS'),
                                (2003, 'Desconto de ferias'),
                                (2004, 'Desconto sindical'),
                                (2005, 'Pensão alimenticia'),
                                (2006, 'Pagamento de faltas justificadas'),
                                (2007, 'Previdência')
                                (2008, 'Adiantamento de Salario');";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(ciar, connection))
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        using (SqlCommand cmd2 = new SqlCommand(inserir, connection))
                        {
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Tabela Referencias Criada com sucesso!");
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


    }
}

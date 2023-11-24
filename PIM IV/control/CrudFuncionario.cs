using PIM_IV.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static PIM_IV.control.CrudCargos;
using static PIM_IV.control.CrudEmpresas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PIM_IV.control
{
    internal class CrudFuncionario
    {
        public string Codigo { get; set; }
        public string Cpf { get; set; }
        public string DataAdimicao { get; set; }
        public string DataNascimento { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cod_empresa { get; set; }
        public string Cod_cargo { get; set; }
        public string Salario { get; set; }
        public string VTransporte { get; set; }
        public string PlanoSaude { get; set; }
        public string VRefeicao { get; set; }
        public string VAlimentacao { get; set; }
        public string AddPericulosidade { get; set; }
        public string AddNoturno { get; set; }
        public string Inss { get; set; }
        public string NDependentes { get; set; }
        public string Cod_banco { get; set; }
        public string NomeBanco { get; set; }
        public string AgenciaBanco { get; set; }
        public string NConta { get; set; }
        public string Nivel { get; set; }
        public string Cod_User { get; set; }
        public string Login { get; set; }
        public string NomeCargo { get; set; }
        public string SalarioHora { get; set; }
        public string CalculoInss { get; set; }

        public string SSS { get; set; }


        public bool CadastrarFuncionario()
        {
            if (VerificaFuncionarios())
            {
                // Gere o hash da senha usando BCrypt
                string senhaHash = BCrypt.Net.BCrypt.HashPassword(SSS);
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        //Primeiro Insert na tabela Usuários
                        string comandoUsuario = "INSERT INTO Usuarios (login, SenhaHash, Nivel) VALUES (@nome, @senhaHash, @Nivel)";
                        //Segundo Insert tabela funcionários
                        string comandoFuncionario = "INSERT into Funcionarios " +
                                 "(nome" +
                                 ",cpf " +
                                 ",rg " +
                                 ",data_nascimento " +
                                 ",rua " +
                                 ",cep " +
                                 ",numero " +
                                 ",estado " +
                                 ",cidade " +
                                 ",codigo_empresa " +
                                 ",codigo_cargo " +
                                 ",salario " +
                                 ",data_adimicao " +
                                 ",vale_transporte " +
                                 ",vale_alimentacao " +
                                 ",vale_refeicao " +
                                 ",PLANO_DE_SAUDE " +
                                 ",add_notuno " +
                                 ",add_perigo " +
                                 ",INSS " +
                                 ",n_dependentes " +
                                 ",cod_banco " +
                                 ",nome_banco " +
                                 ",agencia " +
                                 ",n_conta " +
                                 ",telefone " +
                                 ",codigo_usuario" +
                                 ",email )" +
                                 "values " +
                                 "(@Nome" +
                                 ",@Cpf " +
                                 ",@RG " +
                                 ",@Aniversasrio " +
                                 ",@Rua " +
                                 ",@Cep " +
                                 ",@Numero " +
                                 ",@Estado " +
                                 ",@Cidade " +
                                 ",@CodEmpresa " +
                                 ",@CodCargo " +
                                 ",@Salario " +
                                 ",@Adimicao " +
                                 ",@Transporte " +
                                 ",@Alimentacao " +
                                 ",@Refeicao " +
                                 ",@Saude " +
                                 ",@Notuno " +
                                 ",@Periculosidade " +
                                 ",@INSS " +
                                 ",@NDependentes " +
                                 ",@CodBanco " +
                                 ",@NomeBanco" +
                                 ",@Agencia " +
                                 ",@NumConta " +
                                 ",@Telefone " +
                                 ",@CodUser" +
                                 ",@Email )";

                        //primeiro comando tabela usuarios
                        using (SqlCommand comandoUser = new SqlCommand(comandoUsuario, connection, transaction))
                        {
                            comandoUser.Parameters.AddWithValue("@nome", Login);
                            comandoUser.Parameters.AddWithValue("@senhaHash", senhaHash);
                            comandoUser.Parameters.AddWithValue("@Nivel", Nivel);

                            comandoUser.ExecuteNonQuery();
                            
                        }
                        
                        //segundo comando insert na tabela funcionarios
                        using (SqlCommand cmd = new SqlCommand(comandoFuncionario, connection, transaction))
                        {
                           
                            cmd.Parameters.AddWithValue("@Nome", Nome);
                            cmd.Parameters.AddWithValue("@Cpf", Cpf);
                            cmd.Parameters.AddWithValue("@RG", RG);
                            cmd.Parameters.AddWithValue("@Rua", Rua);
                            cmd.Parameters.AddWithValue("@Cep", Cep);
                            cmd.Parameters.AddWithValue("@Numero", Convert.ToInt32(Numero));
                            cmd.Parameters.AddWithValue("@Cidade", Cidade);
                            cmd.Parameters.AddWithValue("@Estado", Estado);
                            cmd.Parameters.AddWithValue("@Telefone", Telefone);
                            cmd.Parameters.AddWithValue("@Email", Email);
                            cmd.Parameters.AddWithValue("@Aniversasrio", DataNascimento);
                            cmd.Parameters.AddWithValue("@CodEmpresa", Convert.ToInt32(Cod_empresa));
                            cmd.Parameters.AddWithValue("@CodCargo", Convert.ToInt32(Cod_cargo));
                            cmd.Parameters.AddWithValue("@Salario", Convert.ToDecimal(Salario));
                            cmd.Parameters.AddWithValue("@Adimicao", DataAdimicao);
                            cmd.Parameters.AddWithValue("@Transporte", Convert.ToDecimal(VTransporte));
                            cmd.Parameters.AddWithValue("@Alimentacao", Convert.ToDecimal(VAlimentacao));
                            cmd.Parameters.AddWithValue("@Refeicao", Convert.ToDecimal(VRefeicao));
                            cmd.Parameters.AddWithValue("@Saude", Convert.ToDecimal(PlanoSaude));
                            cmd.Parameters.AddWithValue("@Notuno", Convert.ToDecimal(AddNoturno));
                            cmd.Parameters.AddWithValue("@Periculosidade", Convert.ToDecimal(AddPericulosidade));
                            cmd.Parameters.AddWithValue("@INSS", Convert.ToDecimal(Inss));
                            cmd.Parameters.AddWithValue("@NDependentes", Convert.ToDecimal(NDependentes));
                            cmd.Parameters.AddWithValue("@CodBanco", Convert.ToInt32(Cod_banco));
                            cmd.Parameters.AddWithValue("@NomeBanco", NomeBanco);
                            cmd.Parameters.AddWithValue("@Agencia", Convert.ToInt32(AgenciaBanco));
                            cmd.Parameters.AddWithValue("@NumConta", Convert.ToInt32(NConta));
                            cmd.Parameters.AddWithValue("@CodUser", Convert.ToInt32(Cod_User));

                            

                            cmd.ExecuteNonQuery();
                            
                        }

                        transaction.Commit();
                        MessageBox.Show("Cadastro realizado com sucesso!");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Se ocorrer algum erro, reverte a transação
                        MessageBox.Show("Erro linha 195 crud: " + ex.Message);
                        transaction.Rollback();
                        return false;
                    }
                }
               
            }
            return true;
        }
             
        public bool VerificaFuncionarios()
        {
            string comando = "SELECT count(*) from Funcionarios where CPF = @Cpf;";
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        cmd.Parameters.AddWithValue("@Cpf", Cpf);
                        connection.Open();
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("O CPF informado já possui cadastro na base de dados, informe um CPF diferente!");
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
        public void AlterarFuncionario(string cod)//altera somente o funcionario
        {
            string comando = @"UPDATE FUNCIONARIOS SET 
                                 nome = @Nome
                                 ,cpf  =@Cpf
                                 ,rg  =@RG 
                                 ,data_nascimento =@Aniversasrio 
                                 ,rua =@Rua 
                                 ,cep =@Cep 
                                 ,numero =@Numero 
                                 ,estado =@Estado
                                 ,cidade =@Cidade 
                                 ,codigo_empresa =@CodEmpresa
                                 ,codigo_cargo =@CodCargo 
                                 ,salario =@Salario 
                                 ,data_adimicao =@Adimicao 
                                 ,vale_transporte =@Transporte
                                 ,vale_alimentacao =@Alimentacao 
                                 ,vale_refeicao =@Refeicao 
                                 ,PLANO_DE_SAUDE =@Saude 
                                 ,add_notuno =@Notuno 
                                 ,add_perigo =@Periculosidade 
                                 ,INSS =@INSS 
                                 ,n_dependentes =@NDependentes 
                                 ,cod_banco =@CodBanco 
                                 ,nome_banco =@NomeBanco
                                 ,agencia =@Agencia 
                                 ,n_conta=@NumConta 
                                 ,telefone =@Telefone 
                                 ,email =@Email 
                                 WHERE codigo_funcionario = @Cod;";
            /*
            UPDATE U
            SET 
            [login] = @Login,
            [SenhaHash] = @SenhaHash,
            [Nivel] = @Nivel
            FROM [HERMES].[dbo].[Usuarios] U
            INNER JOIN [HERMES].[dbo].[Funcionarios] F ON U.[cod_usuario] = F.[codigo_usuario]
            WHERE F.[codigo_funcionario] = @Cod;"*/

            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            //string senhaHash = BCrypt.Net.BCrypt.HashPassword(SSS);


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(comando, connection))
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@Nome", Nome);
                        cmd.Parameters.AddWithValue("@Cpf", Cpf);
                        cmd.Parameters.AddWithValue("@RG", RG);
                        cmd.Parameters.AddWithValue("@Rua", Rua);
                        cmd.Parameters.AddWithValue("@Cep", Cep);
                        cmd.Parameters.AddWithValue("@Numero", Convert.ToInt32(Numero));
                        cmd.Parameters.AddWithValue("@Cidade", Cidade);
                        cmd.Parameters.AddWithValue("@Estado", Estado);
                        cmd.Parameters.AddWithValue("@Telefone", Telefone);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Aniversasrio", DataNascimento);
                        cmd.Parameters.AddWithValue("@CodEmpresa", Convert.ToInt32(Cod_empresa));
                        cmd.Parameters.AddWithValue("@CodCargo", Convert.ToInt32(Cod_cargo));
                        cmd.Parameters.AddWithValue("@Salario", Convert.ToDecimal(Salario));
                        cmd.Parameters.AddWithValue("@Adimicao", DataAdimicao);
                        cmd.Parameters.AddWithValue("@Transporte", Convert.ToDecimal(VTransporte));
                        cmd.Parameters.AddWithValue("@Alimentacao", Convert.ToDecimal(VAlimentacao));
                        cmd.Parameters.AddWithValue("@Refeicao", Convert.ToDecimal(VRefeicao));
                        cmd.Parameters.AddWithValue("@Saude", Convert.ToDecimal(PlanoSaude));
                        cmd.Parameters.AddWithValue("@Notuno", Convert.ToDecimal(AddNoturno));
                        cmd.Parameters.AddWithValue("@Periculosidade", Convert.ToDecimal(AddPericulosidade));
                        cmd.Parameters.AddWithValue("@INSS", Convert.ToDecimal(Inss));
                        cmd.Parameters.AddWithValue("@NDependentes", Convert.ToDecimal(NDependentes));
                        cmd.Parameters.AddWithValue("@CodBanco", Convert.ToInt32(Cod_banco));
                        cmd.Parameters.AddWithValue("@NomeBanco", NomeBanco);
                        cmd.Parameters.AddWithValue("@Agencia", Convert.ToInt32(AgenciaBanco));
                        cmd.Parameters.AddWithValue("@NumConta", Convert.ToInt32(NConta));
                        //cmd.Parameters.AddWithValue("@Login",Login); 
                        //cmd.Parameters.AddWithValue("@Nivel",Nivel); 
                        //cmd.Parameters.AddWithValue("@SenhaHash", senhaHash);
                        cmd.Parameters.AddWithValue("@Cod", cod);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Alteração realizado com sucesso!");
                    }
                }
                //CriarUsuario(Cpf, Cpf, Nivel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }
        public void CriarUsuario(string nome, string senha, string nivel)
        {
            CreateDataBase init = new CreateDataBase();
            init.CriarNovoUsuario(nome, senha, Convert.ToInt32(nivel));

        }


        public void BuscarUser(string cpf)
        {
            if (cpf != null)
            {

                SqlParameter paramCpf = new SqlParameter();
                paramCpf.ParameterName = "@Cpf";
                paramCpf.Value = Cpf;

                string comando = "SELECT cod_usuario," +
                    " FROM Usuarios " +
                    " WHERE nome = @Cpf ";
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {

                            cmd.Parameters.AddWithValue("@Cpf", Cpf);
                            connection.Open();

                            SqlDataReader data = cmd.ExecuteReader();
                            if (data.Read())
                            {
                                Cod_User = Convert.ToString(data["cod_usuario"]);

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

        public void BuscarFuncionario(string cod)
        {
            if (cod != null)
            {
                string comando = @"
                                SELECT 
                                F.[codigo_funcionario],
                                F.[nome] AS [NomeFuncionario],
                                F.[cpf],
                                F.[rg],
                                F.[data_nascimento],
                                F.[rua],
                                F.[cep],
                                F.[numero],
                                F.[estado],
                                F.[cidade],
                                F.[codigo_empresa],
                                F.[codigo_cargo],
                                F.[salario],
                                F.[data_adimicao],
                                F.[vale_transporte],
                                F.[vale_alimentacao],
                                F.[vale_refeicao],
                                F.[PLANO_DE_SAUDE],
                                F.[add_notuno],
                                F.[add_perigo],
                                F.[INSS],
                                F.[n_dependentes],
                                F.[cod_banco],
                                F.[nome_banco],
                                F.[agencia],
                                F.[n_conta],
                                F.[telefone],
                                F.[email],
                                F.[codigo_usuario],
                                U.[login],
                                U.[Nivel],
	                            C.[nome] as [nome_cargo]
                            FROM [HERMES].[dbo].[Funcionarios] F
                            INNER JOIN [HERMES].[dbo].[Usuarios] U ON F.[codigo_usuario] = U.[cod_usuario]
                            INNER JOIN [HERMES].[dbo].[Cargos] C ON F.[codigo_cargo] = C.[codigo_cargo] 
                            where codigo_funcionario=@Cod;";

                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {

                            cmd.Parameters.AddWithValue("@Cod", cod);
                            connection.Open();

                            SqlDataReader data = cmd.ExecuteReader();
                            if (data.Read())
                            {
                                Codigo = Convert.ToString(data["codigo_funcionario"]);
                                Cpf = Convert.ToString(data["cpf"]);
                                DataAdimicao = Convert.ToString(data["data_adimicao"]);
                                DataNascimento = Convert.ToString(data["data_nascimento"]);
                                Nome = Convert.ToString(data["NomeFuncionario"]);
                                RG = Convert.ToString(data["rg"]);
                                Rua = Convert.ToString(data["rua"]);
                                Cep = Convert.ToString(data["cep"]);
                                Numero = Convert.ToString(data["numero"]);
                                Cidade = Convert.ToString(data["cidade"]);
                                Estado = Convert.ToString(data["estado"]);
                                Telefone = Convert.ToString(data["telefone"]);
                                Email = Convert.ToString(data["email"]);
                                Cod_empresa = Convert.ToString(data["codigo_empresa"]);
                                Cod_cargo = Convert.ToString(data["codigo_cargo"]);
                                Salario = Convert.ToString(data["salario"]);
                                VTransporte = Convert.ToString(data["vale_transporte"]);
                                PlanoSaude = Convert.ToString(data["PLANO_DE_SAUDE"]);
                                VRefeicao = Convert.ToString(data["vale_refeicao"]);
                                VAlimentacao = Convert.ToString(data["vale_alimentacao"]);
                                AddPericulosidade = Convert.ToString(data["add_perigo"]);
                                AddNoturno = Convert.ToString(data["add_notuno"]);
                                Inss = Convert.ToString(data["INSS"]);
                                NDependentes = Convert.ToString(data["n_dependentes"]);
                                Cod_banco = Convert.ToString(data["cod_banco"]);
                                NomeBanco = Convert.ToString(data["nome_banco"]);
                                AgenciaBanco = Convert.ToString(data["agencia"]);
                                NConta = Convert.ToString(data["n_conta"]);
                                Nivel = Convert.ToString(data["Nivel"]);
                                Cod_User = Convert.ToString(data["codigo_usuario"]);
                                Login = Convert.ToString(data["login"]);
                                NomeCargo = Convert.ToString(data["nome_cargo"]);


                                /*query
                                SELECT
                                Funcionarios.nome AS Funcionario_nome,
                                Empresas.Nome AS Empresa_nome,
                                Usuarios.nome AS Usuario_nome
                                FROM
                                Funcionarios
                                INNER JOIN
                                Empresas ON Funcionarios.codigo_empresa = Empresas.codigo_empresa
                                INNER JOIN
                                Usuarios ON Funcionarios.codigo_usuario = Usuarios.cod_usuario
                                WHERE
                                Funcionarios.cpf = 1;*/
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }

            }
        }
        public string BuscarFuncionarioByCPF(string cod)
        {
            if (cod != null)
            {
                string comando = "SELECT codigo_funcionario FROM Funcionarios WHERE cpf = @cpf";

                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand(comando, connection))
                        {

                            cmd.Parameters.AddWithValue("@cpf", cod);
                            connection.Open();

                            SqlDataReader data = cmd.ExecuteReader();
                            if (data.Read())
                            {
                                Codigo = Convert.ToString(data["codigo_funcionario"]);

                                return Codigo;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                    return null;
                }

            }
            return null;
        }

        public bool DeletarFuncionario(string cod, string user)
        {
            string mensagem = "O funcionário escolhido será excluido da base de dados permanentemente, como conseguência, o usuário correspondente a esse funcionário também será perdido, deseja continuar? ";
            if (cod != null)
            {
                string deleteFun = "DELETE FROM Funcionarios WHERE codigo_funcionario = @Cod ;";
                string deleteUser = "DELETE FROM Usuarios WHERE login = @Login;";
                PegaNome nomeServer = new PegaNome();
                string nomeServidor = nomeServer.Pegar();
                string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                var result = MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    using (SqlCommand cmd1 = new SqlCommand(deleteFun, connection, transaction))
                                    {
                                        cmd1.Parameters.AddWithValue("@Cod", cod);
                                        cmd1.ExecuteNonQuery();
                                    }
                                    using (SqlCommand cmd2 = new SqlCommand(deleteUser, connection, transaction))
                                    {
                                        cmd2.Parameters.AddWithValue("@Login", user);
                                        cmd2.ExecuteNonQuery();
                                    }
                                    transaction.Commit();//Confirma a execução das query
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();//em caso de erro recupera os dados excluidos
                                MessageBox.Show($"Erro:{ex.Message}");
                            }

                        }
                    }
                }
                catch (SqlException)//0x80131904
                {
                    MessageBox.Show("Não é possível excluir este funcionario, pois existem cargos associados a ela.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }

            }
            return false;
        }

        public class Codigos
        {
            public int CodFun { get; set; }
            public string CpfFun { get; set; }
        }
        public List<Codigos> GetListCpf(string empresa)
        {
            List<Codigos> codigos = new List<Codigos>();
            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = "SELECT codigo_funcionario, cpf FROM Funcionarios WHERE codigo_empresa = @empresa";
                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@empresa", empresa);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Codigos codigo = new Codigos
                            {
                                CodFun = Convert.ToInt32(reader["codigo_funcionario"]),
                                CpfFun = reader["cpf"].ToString()
                            };
                            codigos.Add(codigo);
                        }


                    }
                }
                return codigos;
            }
        }
        public class Func
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public string RG { get; set; }
            public string Cargo { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public string Salario { get; set; }
            public string Nivel { get; set; }
        }

        public List<Func> CarregarFuncionario()
        {
            List<Func> funcionarios = new List<Func>();

            string comando = @"
                                SELECT 
                                F.[codigo_funcionario],
                                F.[nome] AS [NomeFuncionario],
                                F.[cpf],
                                F.[rg],
                                F.[salario],
                                F.[telefone],
                                F.[email],
                                U.[Nivel],
	                            C.[nome] as [nome_cargo]
                            FROM [HERMES].[dbo].[Funcionarios] F
                            INNER JOIN [HERMES].[dbo].[Usuarios] U ON F.[codigo_usuario] = U.[cod_usuario]
                            INNER JOIN [HERMES].[dbo].[Cargos] C ON F.[codigo_cargo] = C.[codigo_cargo] ;";

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
                        Func func = new Func
                        {
                            Codigo = Convert.ToString(data["codigo_funcionario"]),
                            Cpf = Convert.ToString(data["cpf"]),
                            Nome = Convert.ToString(data["NomeFuncionario"]),
                            RG = Convert.ToString(data["rg"]),
                            Telefone = Convert.ToString(data["telefone"]),
                            Email = Convert.ToString(data["email"]),
                            Salario = Convert.ToString(data["salario"]),
                            Nivel = Convert.ToString(data["Nivel"]),
                            Cargo = Convert.ToString(data["nome_cargo"])
                        };
                        funcionarios.Add(func);
                    }
                }

            }
            return funcionarios;

        }

        public List<Func> CarregarFuncionario(string cpf)
        {
            List<Func> funcionarios = new List<Func>();

            string comando = @"
                                SELECT 
                                F.[codigo_funcionario],
                                F.[nome] AS [NomeFuncionario],
                                F.[cpf],
                                F.[rg],
                                F.[salario],
                                F.[telefone],
                                F.[email],
                                U.[Nivel],
	                            C.[nome] as [nome_cargo]
                            FROM [HERMES].[dbo].[Funcionarios] F
                            INNER JOIN [HERMES].[dbo].[Usuarios] U ON F.[codigo_usuario] = U.[cod_usuario]
                            INNER JOIN [HERMES].[dbo].[Cargos] C ON F.[codigo_cargo] = C.[codigo_cargo] 
                            where cpf =@CPF;";

            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(comando, connection))
                {

                    connection.Open();
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        Func func = new Func
                        {
                            Codigo = Convert.ToString(data["codigo_funcionario"]),
                            Cpf = Convert.ToString(data["cpf"]),
                            Nome = Convert.ToString(data["NomeFuncionario"]),
                            RG = Convert.ToString(data["rg"]),
                            Telefone = Convert.ToString(data["telefone"]),
                            Email = Convert.ToString(data["email"]),
                            Salario = Convert.ToString(data["salario"]),
                            Nivel = Convert.ToString(data["Nivel"]),
                            Cargo = Convert.ToString(data["nome_cargo"])
                        };
                        funcionarios.Add(func);
                    }
                }

            }
            return funcionarios;

        }

        public List<Func> CarregarFuncionarioEmpresa(string cod)
        {
            List<Func> funcionarios = new List<Func>();

            string comando = @"
                                SELECT 
                                F.[codigo_funcionario],
                                F.[nome] AS [NomeFuncionario],
                                F.[cpf],
                                F.[rg],
                                F.[salario],
                                F.[telefone],
                                F.[email],
                                U.[Nivel],
	                            C.[nome] as [nome_cargo]
                            FROM [HERMES].[dbo].[Funcionarios] F
                            INNER JOIN [HERMES].[dbo].[Usuarios] U ON F.[codigo_usuario] = U.[cod_usuario]
                            INNER JOIN [HERMES].[dbo].[Cargos] C ON F.[codigo_cargo] = C.[codigo_cargo] 
                            where F.codigo_empresa = @Cod";

            PegaNome nomeServer = new PegaNome();
            string nomeServidor = nomeServer.Pegar();
            string connectionString = "Data Source=" + nomeServidor + ";Initial Catalog=HERMES;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(comando, connection))
                {

                    connection.Open();
                    cmd.Parameters.AddWithValue("@Cod", cod);
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        Func func = new Func
                        {
                            Codigo = Convert.ToString(data["codigo_funcionario"]),
                            Cpf = Convert.ToString(data["cpf"]),
                            Nome = Convert.ToString(data["NomeFuncionario"]),
                            RG = Convert.ToString(data["rg"]),
                            Telefone = Convert.ToString(data["telefone"]),
                            Email = Convert.ToString(data["email"]),
                            Salario = Convert.ToString(data["salario"]),
                            Nivel = Convert.ToString(data["Nivel"]),
                            Cargo = Convert.ToString(data["nome_cargo"])
                        };
                        funcionarios.Add(func);
                    }
                }

            }
            return funcionarios;

        }


    }
}


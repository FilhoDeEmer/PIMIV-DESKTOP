using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_IV.control
{

    internal class CrudFolha
    {
        DateTime dataHoraAtual = DateTime.Now;
        public string CodFuncionario {  get; set; }
        public string CodEmpresa { get; set; }
        public string Salario { get; set; }
        public string ValorProventos { get; set; }
        public string ValorDescontos { get; set; }
        public string ValorLiquido { get; set; }
        public string FaixaIrrf { get; set; }
        public string FgtsMes { get; set; }
        public string Mensagem { get; set; }

        public void SalvarFolha()
        {
            string comando = @"INSERT into Holerite (COD_EMPRESA,COD_FUNCIONARIO,SALARIO,VALORPROVENTOS, VALORDESCONTOS, VALORLIQUIDO,FAIXAIRRF,FGTSMES,MENSAGEM ) values 
                                                    (@COD_EMPRESA,@COD_FUNCIONARIO,@SALARIO,@VALORPROVENTOS, @VALORDESCONTOS, @VALORLIQUIDO,@FAIXAIRRF,@FGTSMES,@MENSAGEM)";
            
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
                        cmd.Parameters.AddWithValue("@COD_EMPRESA", CodEmpresa);
                        cmd.Parameters.AddWithValue("@COD_FUNCIONARIO", CodFuncionario);
                        cmd.Parameters.AddWithValue("@SALARIO", Salario);
                        cmd.Parameters.AddWithValue("@VALORPROVENTOS", ValorProventos);
                        cmd.Parameters.AddWithValue("@VALORDESCONTOS", ValorDescontos);
                        cmd.Parameters.AddWithValue("@VALORLIQUIDO", ValorLiquido);
                        cmd.Parameters.AddWithValue("@FAIXAIRRF", FaixaIrrf);
                        cmd.Parameters.AddWithValue("@FGTSMES", FgtsMes);
                        cmd.Parameters.AddWithValue("@MENSAGEM", Mensagem);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Emitido com sucesso!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }
        public CrudFolha() 
        {


        }

        public void GerarImg(string nomeFun)
        {
            string diretorioDeSalvamento = "C:\\Users\\eme_s\\OneDrive\\Documentos\\GitHub\\PIMIV-DESKTOP\\Holerite";

            Form meuFormulario = new Form();
            meuFormulario.Text = "Meu Formulário";
            meuFormulario.Size = new Size(400, 200);

            // Adicionar controles ao formulário (TextBoxes, Labels, etc.)
            AdicionarControlesAoFormulario(meuFormulario);

            // Criar uma imagem com base no formulário
            Bitmap minhaImagem = new Bitmap(meuFormulario.Width, meuFormulario.Height);
            meuFormulario.DrawToBitmap(minhaImagem, new Rectangle(0, 0, meuFormulario.Width, meuFormulario.Height));

            // Salvar a imagem em um arquivo
            minhaImagem.Save(Path.Combine(diretorioDeSalvamento,  $"{nomeFun}{dataHoraAtual}.png"), System.Drawing.Imaging.ImageFormat.Png);

            Console.WriteLine("Imagem do formulário criada e salva com sucesso!");
        }
        static void AdicionarControlesAoFormulario(Form formulario)
        {
            // Adicione aqui os controles desejados ao formulário
            TextBox textBox1 = new TextBox();
            textBox1.Text = "Texto na TextBox1";
            formulario.Controls.Add(textBox1);

            TextBox textBox2 = new TextBox();
            textBox2.Text = "Texto na TextBox2";
            formulario.Controls.Add(textBox2);

            Label label1 = new Label();
            label1.Text = "Texto na Label1";
            formulario.Controls.Add(label1);

            Label label2 = new Label();
            label2.Text = "Texto na Label2";
            formulario.Controls.Add(label2);

            // Configurar a posição dos controles no formulário
            textBox1.Location = new Point(10, 10);
            textBox2.Location = new Point(10, 40);
            label1.Location = new Point(10, 70);
            label2.Location = new Point(10, 100);
        }


    }
}

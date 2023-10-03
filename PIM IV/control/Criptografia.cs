using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PIM_IV.control
{
    internal class Criptografia
    {
        public string RetornaMD5(String senha) //metodo para retonar uma hash 
        {
            using (MD5 md5Hash = MD5.Create())//cria uma instancia padrão md5 e fecha para economizar dados
            {
                return RetornaHash(md5Hash, senha);
            }
            
        }
        public bool ComparaMD5(string senhaEntrada, string senhaMd5)//senhaMD5 é um hash de senha guardada no banco de dados, ou seja, para usar esses metodos primeiro tenho que puxar esses dados do banco de dados 
        {
            string senha = RetornaMD5(senhaEntrada);
            if (ComparaSenha(senhaMd5,senha)) 
            {
                return true;
            }
            else { return false; }
        }
        private string RetornaHash(MD5 md5Hash, string input)// cria a hash md5
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));//obtem um away de bytes apartir da sting informada input
            StringBuilder stringBuilder = new StringBuilder();// constroi a string final

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("X2"));//transforma em hexadecimal em letra maiuscula

            }

            return stringBuilder.ToString();
        }

        private bool ComparaSenha(string input, string hash)//compara as senha digitada com a do banco de dados
        {
            StringComparer comparar = StringComparer.OrdinalIgnoreCase;//retorna ignorando o case sensitive
            if(comparar.Compare(input, hash) == 0)
            {
                return true;
            }
            else {return false;}

        }
    }
}

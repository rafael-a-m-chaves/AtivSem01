using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01.Controles
{
    public class Conexao
    {
        public static bool EscreverArquivoPedido(string conteudo)
        {
            try
            {
                
                string folder = Directory.GetCurrentDirectory();
                folder = Path.Combine(folder, "bancoDeDados");
                string arquivo = Path.Combine(folder, "pedido.txt");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                File.AppendAllText(arquivo, conteudo);


                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string LerPedidos()
        {
            string retorno = "";
            string folder = Directory.GetCurrentDirectory();
            folder = Path.Combine(folder, "bancoDeDados");
            string arquivo = Path.Combine(folder, "pedido.txt");

            if (File.Exists(arquivo))
            {
               retorno =  File.ReadAllText(arquivo);
            }

            return retorno;
        }

    }
}

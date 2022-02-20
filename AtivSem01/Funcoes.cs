using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01
{
    class Funcoes
    {
        public static int RecebeMatriz(int[,] matriz)
        {
            int soma = 0;
            try
            {
                foreach(var numero in matriz)
                {
                    soma += numero;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return soma;
        }

    }
}

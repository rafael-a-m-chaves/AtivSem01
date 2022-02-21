using AtivSem01.Model;
using System;
using System.Collections.Generic;

namespace AtivSem01.Controles
{
    public class ControleListNumeros
    {
        public static ListNumerosResponse RecebeValores()
        {
            List<decimal> retorno = new List<decimal>();
            byte valoresValidos = 4;

            Console.Clear();

            Console.WriteLine("Informe 4 valores, (sera atribuido 0 caso o valor digitado seja invalido)");
            for(byte i = 1; i <= 4; i++)
            {
                Console.WriteLine("informe o {0}° valor", i);
                try
                {
                    retorno.Add(Convert.ToDecimal(Console.ReadLine()));
                }
                catch
                {
                    retorno.Add(0.0M);
                    valoresValidos--;
                }
            }

            ListNumerosResponse response = new ListNumerosResponse();
            response.LIstaValores = retorno;
            response.ValoresValidos = valoresValidos;
            return response;
        }
    }
}

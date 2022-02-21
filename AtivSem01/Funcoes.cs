using AtivSem01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01
{
    class Funcoes
    {

        #region Metodo para Receber Matriz e retornar a somatoria de todos os valores 
        public static int RecebeMatriz(int[,] matriz) // metodo estatico para poder ser acessado sem nescessida de ser instanciado
        {
            int soma = 0; // inicializando a variavel que recebera a soma da matriz
            try
            {
                foreach(var numero in matriz) //laço de repetição para percorrer toda matriz
                {
                    soma += numero;
                }
            }
            catch (Exception ex)// existem algumas proteções no gerar matriz mas caso ainda passe alguma ela sera capturada aqui
            {
                Console.WriteLine(ex.Message); //exibe o erro para o usuario
                soma = 0;// alem de exibir o erro, o retorno é setado como 0
            }
            return soma;
        }
        #endregion 


        #region Metodo para Receber 4 valores e retornar o maior

        public static decimal RetornaMaiorValor(ListNumerosResponse listNumeros)
        {
            try //bloco para tratamento de erros que podem ainda nao ter sido tratados
            {
                return listNumeros.LIstaValores.Max(); //retorna o maior valor
            }
            catch
            {
                return 0.0M; //Caso exista algum erro retornara 0 em decimal padrao
            }
        }

        #endregion
    }
}

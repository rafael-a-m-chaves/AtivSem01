using AtivSem01.Controles;
using System;
using System.Runtime.InteropServices;

namespace AtivSem01
{
    class Program
    {
        // Codigo abaixo para controle das propiedade de posição e tamanho da janela Console

        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();

        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int HIDE = 0;

        private const int MAXIMIZE = 3;

        private const int MINIMIZE = 6;

        private const int RESTORE = 9;

        //Fim codigo para controle das propiedade de posição e tamanho da janela Console


        static void Main(string[] args)
        {
            /*
            3) No arquivo Funcoes.cs, inclua as seguintes Funções:

            3.2) Uma função que receba como parametro 4 valores numéricos e retorne o maior deles.

            Obs. Todas as funções devem ficar em blocos protegidos de tratamento de erro, onde caso ocorra, o valor da função deve retornar um valor vazio (0, '', etc...)

            4) No arquivo Cadastros.cs, monte a seguinte estrutura de classes:

            4.1) Uma Interface: IOperacoesBD, com os seguintes métodos sem retorno: Inserir, Alterar, Deletar, Pesquisar

            4.2) Uma Classe Abstrata: Cadastros, que implementa a Interface acima

            4.3) Inclua na Classe Abstrata uma propriedade protegida chamada: Conexao;

            4.4) Inclua duas Classes que não podem ser herdadas, que derivam da Classe Abstrata : Clientes e Pedidos.

            4.5) As Classes Clientes e Pedidos devem preencher a propriedade Conexão a partir de seus construtores

            4.6) O método Deletar deve sofrer sobrecarga nas duas Classes, executando o código da Classe Superior e incluindo algo novo

            4.7) O método Inserir deve sofrer sobrecarga na classe Pedidos, desconsiderando a implementação do método da classe Superior

            5) No projeto Console, instancie as classes de Funcoes, Clientes e Pedidos e execute alguns métodos.

            6) Publique seu projeto no GitHub, colocando-o em um repositório Publico*/

            
            //seção para abrir automaticamente o console em janela maximizada 
            
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            //fim de seção 

            var matrizResponse = ControleMatriz.GeraMatriz();

            var resultadoSomaMatriz = Funcoes.RecebeMatriz(matrizResponse.Matriz);

            Console.WriteLine(resultadoSomaMatriz);

            Console.ReadKey();
        }
    }
}

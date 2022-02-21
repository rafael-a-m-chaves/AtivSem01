using AtivSem01.Controles;
using System;
using System.IO;
using System.Net;
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
            //seção para abrir automaticamente o console em janela maximizada 
            
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            //fim de seção         

            Console.WriteLine(Conexao.EscreverArquivoPedido("0001;Rafael;Timóteo\n"));
            Console.WriteLine(Conexao.EscreverArquivoPedido("0001;Sara;Brasilha\n"));

            string lido = Conexao.LerPedidos();

            var separado = lido.Split('\n');

            Console.WriteLine(separado[0]);

            // var matrizResponse = ControleMatriz.GeraMatriz();

            // var resultadoSomaMatriz = Funcoes.RecebeMatriz(matrizResponse.Matriz);

            // Console.WriteLine(resultadoSomaMatriz);

            Console.ReadKey();
        }
    }
}

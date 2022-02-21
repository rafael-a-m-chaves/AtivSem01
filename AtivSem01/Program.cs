using AtivSem01.Controles;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

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
            ExibirMenu();
            try
            {
                int opcao = Convert.ToInt32(Console.ReadLine());

                if(opcao == 1)
                {
                    var retorno = ControleMatriz.GeraMatriz();
                    if (retorno.MatrizPreenchida)
                    {
                        Console.WriteLine("soma da matriz é: "+Funcoes.RecebeMatriz(retorno.Matriz));
                    }
                    else
                    {
                        Console.WriteLine("soma da matriz é: 0");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();
                    
                }
                else if (opcao == 2)
                {
                    var retorno =  ControleListNumeros.RecebeValores();
                    Console.WriteLine(Funcoes.RetornaMaiorValor(retorno));
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();
                }
                else if (opcao == 3)
                {
                    
                    
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();
                }
                else if(opcao == 4)
                {
                    Console.WriteLine("Fechando o sistema em 5 segundos");
                    Thread.Sleep(5000);

                }
                else
                {
                    OpcaoNaoReconhecida();
                }
            }
            catch
            {
                OpcaoNaoReconhecida();
            }
            
        }

        static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("Atividade Semana 01    " + DateTime.Now);

            Console.WriteLine("Selecione uma opção de 1 a 4 ");
            Console.WriteLine("1 Gerar Matriz | 2 Verificar qual o Maior Numero | 3 seção de cadastros | 4 Sair da aplicação");
        }

        static void OpcaoNaoReconhecida()
        {
            Console.WriteLine("Opção não reconhecida, voltando para o menu em 6 segundos....");
            Thread.Sleep(1000);
            Console.WriteLine("5 segundos....");
            Thread.Sleep(1000);
            Console.WriteLine("4 segundos....");
            Thread.Sleep(1000);
            Console.WriteLine("3 segundos....");
            Thread.Sleep(1000);
            Console.WriteLine("2 segundos....");
            Thread.Sleep(1000);
            Console.WriteLine("1 segundos....");
            Thread.Sleep(1000);
            ExibirMenu();
        }
    }
}

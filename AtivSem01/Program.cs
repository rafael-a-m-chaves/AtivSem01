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
                    OpcaoCadastros();

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

        static void OpcaoCadastros()
        {
            Console.Clear();

            Console.WriteLine("Selecione uma opção abaixo");
            Console.WriteLine("1 Area Clientes| 2 Area Pedidos");
            try
            {
                int opcao = Convert.ToInt32(Console.ReadLine());
                if(opcao == 1)
                {
                    OpcaoCliente();
                }
                else if(opcao == 2)
                {
                    OpcaoPedidos();
                }
                else
                {
                    Console.WriteLine("Nao foi possivel achar essa opção vou te retorna para o menu novamente");
                    Thread.Sleep(3000);
                    OpcaoCadastros();
                }
            }
            catch
            {
                Console.WriteLine("Nao foi possivel achar essa opção vou te retorna para o menu novamente");
                Thread.Sleep(3000);
                OpcaoCadastros();
            }
        }
        
        static void OpcaoCliente()
        {
            Console.Clear();

            Console.WriteLine("Area do cliente     " + DateTime.Now);
            Console.WriteLine("Selecione a opção abaixo");
            Console.WriteLine("1 Inserir| 2 Buscar | 3 Alterar | 4 Deletar");
            try
            {
                int opcao = Convert.ToInt32(Console.ReadLine());
                Clientes clientes = new Clientes();
                if (opcao == 1)
                {
                    clientes.Inserir();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();

                }
                else if (opcao == 2)
                {
                    clientes.Pesquisar();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("Informe o nome do cliente a ser alterado");
                    var nome = Console.ReadLine();
                    clientes.Alterar(nome);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("Informe o nome do cliente a ser Deletado");
                    var nome = Console.ReadLine();
                    clientes.Deletar("cliente",nome);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);

                }
                else
                {
                    Console.WriteLine("Nao foi possivel achar essa opção vou te retorna para o menu novamente");
                    Thread.Sleep(3000);
                    OpcaoCliente();
                }

            }
            catch
            {
                Console.WriteLine("Nao foi possivel achar essa opção vou te retorna para o menu novamente");
                Thread.Sleep(3000);
                OpcaoCliente();
            }
            
        }

        static void OpcaoPedidos()
        {
            Console.Clear();

            Console.WriteLine("Area de Pedidos     " + DateTime.Now);
            Console.WriteLine("Selecione a opção abaixo");
            Console.WriteLine("1 Inserir| 2 Buscar | 3 Alterar | 4 Deletar");
            try
            {
                int opcao = Convert.ToInt32(Console.ReadLine());
                Pedidos pedidos = new Pedidos();
                if (opcao == 1)
                {
                    Console.WriteLine("Digite o numero do pedido");
                    var numero = Console.ReadLine();
                    Console.WriteLine("Digite o nome do cliente");
                    var nome = Console.ReadLine();
                    var linha = numero + ";" + nome;
                    pedidos.Inserir("pedido", linha);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();

                }
                else if (opcao == 2)
                {
                    pedidos.Pesquisar();

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("Informe o nome do cliente a ser alterado");
                    var nome = Console.ReadLine();
                    pedidos.Alterar(nome);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);
                    ExibirMenu();
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("Informe o nome do cliente a ser Deletado");
                    var nome = Console.ReadLine();
                    pedidos.Deletar("cliente", nome);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Voltando ao menu principal em 15 segunos ......");
                    Thread.Sleep(15000);

                }
                else
                {
                    Console.WriteLine("Nao foi possivel achar essa opção vou te retorna para o menu novamente");
                    Thread.Sleep(3000);
                    OpcaoCliente();
                }

            }
            catch
            {
                Console.WriteLine("Nao foi possivel achar essa opção vou te retorna para o menu novamente");
                Thread.Sleep(3000);
                OpcaoCliente();
            }


        }
    }
}

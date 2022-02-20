using AtivSem01.Model;
using System;

namespace AtivSem01.Controles
{
    class ControleMatriz
    {
        #region Metodo para Gerar a matriz
        public static MatrizResponse GeraMatriz() //TODO melhorar retorno do metodo ObterQuantidadeLinhasEColulunas
        {
            MatrizResponse matrizResponse = ObterQuantidadeLinhasEColulunas("linhas"); //aqui chamo o metodo de obter a quantidade de linhas e colunas passando a string de controle

            if(matrizResponse.MatrizPreenchida == true) //Verifico se o valor informado foi valido e se pode continuar a execução normal
            {
                var segundaMatrizResponse = ObterQuantidadeLinhasEColulunas("colunas"); //aqui chamo o metodo de obter a quantidade de linhas e colunas passando a string de controle
                if (segundaMatrizResponse.MatrizPreenchida == true)
                {
                    matrizResponse.Coluna = segundaMatrizResponse.Coluna; // Passando o valor da coluna que estava no segundo objeto
                    var matriz = PreecherMatriz(matrizResponse); // metodo para obter todos os valore da matriz
                    //preenchendo o objeto para retorno
                    matrizResponse.Matriz = matriz;
                    matrizResponse.MatrizPreenchida = true;
                }
                else
                {
                    matrizResponse.MatrizPreenchida = false;
                }
            }

            return matrizResponse;
        }

        #endregion

        #region Obter Quantidade de Linhas ou Coluna

        private static MatrizResponse ObterQuantidadeLinhasEColulunas(string tipo) //Para reaproveitar o metodo, é esperado o valor de tipo sendo aceito 'linhas' ou 'colunas'
            //Acesso privado para que nenhuma outra classe chame ele.
        {
            bool repeticao = false;
            int valor = 0;
            int somatoriaErros = 0;
            MatrizResponse matrizResponse = new MatrizResponse();

            Console.Clear(); //limpando a tela

            Console.Write(("MATRIZ").PadLeft(84,'_'));//Pad é um metodo para gerear caracteres repetidos automaticamente, 
            Console.Write(("").PadRight(84, '_'));    //nesse casso sera gerado caracteres do lado direito e do lado esquerdo do texto
            
            Console.WriteLine("\r\n"); //Gera uma quebra de linha extra

            Console.WriteLine("Informe a quantidade de {0} da matriz",tipo);
            try
            {
                valor = Convert.ToInt32(Console.ReadLine());
                matrizResponse.MatrizPreenchida = true;
            }
            catch
            {
                repeticao = true;
                somatoriaErros++;

                while (repeticao)
                {
                    Console.WriteLine("O valor digitado não foi reconhecido como um numero inteiro, por favor digite " +
                                      "novamente ({0} tentativas restantes)", 3 - somatoriaErros);
                    try
                    {
                        valor = Convert.ToInt32(Console.ReadLine());
                        repeticao = false;
                        matrizResponse.MatrizPreenchida = true;
                    }
                    catch
                    {
                        if (somatoriaErros < 2) // para limitar as tentativas em 3 sendo que a primeira foi no try que gerou esse catch
                        {
                            repeticao = true;
                            somatoriaErros++;
                        }
                        else
                        {
                            repeticao = false;
                            valor = 0;
                            Console.WriteLine("Devido a suceção de erros nao foi possivel gerar uma matriz, você sera " +
                              "redirecionado para o menu principal");
                            matrizResponse.MatrizPreenchida = false;
                        }
                    }

                }

            }
            if (tipo == "colunas") matrizResponse.Coluna = valor; // para gerar o retorno no padrao que esta sendo utilizado faço a verificação de tipo e coloco o valor obtido na propiedade correta
            else matrizResponse.Linha = valor;
            return matrizResponse;
        }

        #endregion

        #region Obter os Valores para preencher a matriz

        private static int[,] PreecherMatriz(MatrizResponse matrizResponse) //TODO criar função especifica para limpar a tela e gerar o padrao inicial de matriz 
        {
            int quantidadeDeValores = matrizResponse.Coluna * matrizResponse.Linha; // Calculo para informar a quantidade de valores que espera-se se recebido
            int[,] matriz = new int[matrizResponse.Linha, matrizResponse.Coluna];

            Console.Clear(); //limpa a tela

            Console.Write(("MATRIZ").PadLeft(84, '_'));//Pad é um metodo para gerear caracteres repetidos automaticamente, 
            Console.Write(("").PadRight(84, '_'));    //nesse casso sera gerado caracteres do lado direito e do lado esquerdo do texto

            Console.WriteLine("\r\n"); //Gera uma quebra de linha extra

            Console.WriteLine("Sera nescessario informar {0} valores para preencher a matriz {1}X{2}", quantidadeDeValores,
                               matrizResponse.Linha, matrizResponse.Coluna);
            
            for(var linha = 0; linha < matrizResponse.Linha; linha++) // laço de repetição para percorrer todas linhas 
            {
                for(var coluna = 0; coluna < matrizResponse.Coluna; coluna++) // laço de repetição para percorrer todas Colunas 
                {
                    try //Bloco de tratamento para caso o usuario informe um valor invalido
                    {
                        Console.WriteLine("informe o valor da linha {0} coluna {1}", linha + 1, coluna + 1);
                        matriz[linha, coluna] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        bool repeticao = true;
                        while (repeticao) //laço de repetiçao para tratamento ate o usuario informar um valor valido
                        {
                            try // Bloco para verificar se o valor é valido e caso não seja permanecer no laço
                            {
                                Console.WriteLine("Valor informado não foi aceito");
                                Console.WriteLine("informe novamente o valor da linha {0} coluna {1}", linha + 1, coluna + 1);
                                matriz[linha, coluna] = Convert.ToInt32(Console.ReadLine());
                                repeticao = false;
                            }
                            catch
                            {
                                repeticao = true;
                            }
                        }
                    }
                }
            }

            return matriz;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01
{
    public abstract class Cadastros : IOperacoesBD
    {
        protected string[] Conexao { get; set; }

        public void Alterar(string nomeArquivo, string linhaASerAlterada, string novaLinha)
        {
            string folder = Directory.GetCurrentDirectory();
            folder = Path.Combine(folder, "bancoDeDados");
            string arquivo = Path.Combine(folder, nomeArquivo);

            if (File.Exists(arquivo))
            {
                var file = File.ReadAllText(arquivo);
                var fileArray = file.Split('\n');
                var controle = 0;

                foreach (var item in fileArray)
                {
                    if (item.Contains(linhaASerAlterada))
                    {
                        fileArray[controle].Remove(0);
                        fileArray[controle] = novaLinha;
                    }
                    controle++;
                }

                File.WriteAllLines(arquivo, fileArray);
            }
            else
            {
                Console.WriteLine("Ainda nao existe nenhum dado nessa tabela");
            }
        }

        public void Deletar(string nomeArquivo, string linha)
        {
            string folder = Directory.GetCurrentDirectory();
            folder = Path.Combine(folder, "bancoDeDados");
            string arquivo = Path.Combine(folder, nomeArquivo);

            if (File.Exists(arquivo))
            {
                var file = File.ReadAllText(arquivo);
                var fileArray = file.Split('\n');
                var controle = 0;

                foreach (var item in fileArray)
                {
                    if (item.Contains(linha))
                    {
                        fileArray[controle].Remove(0);
                    }
                    controle++;
                }

                File.WriteAllLines(arquivo, fileArray);
            }
            else
            {
                Console.WriteLine("Ainda nao existe nenhum dado nessa tabela");
            }
        }

        public void Inserir(string nomeArquivo, string linha)
        {

            try
            {

                string folder = Directory.GetCurrentDirectory();
                folder = Path.Combine(folder, "bancoDeDados");
                string arquivo = Path.Combine(folder, nomeArquivo);

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                File.AppendAllText(arquivo, linha);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Atualmente esta aplicação não tem autorizaçao de acesso aos arquivos");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void Pesquisar(string nomeArquivo, string pesquisa)
        {
            string folder = Directory.GetCurrentDirectory();
            folder = Path.Combine(folder, "bancoDeDados");
            string arquivo = Path.Combine(folder, nomeArquivo);

            if (File.Exists(arquivo))
            {
                var file = File.ReadAllText(arquivo);
                var fileArray = file.Split('\n');
                foreach(var item in fileArray)
                {
                    var itemSeparado = item.Split(';');
                    if (itemSeparado.Contains(pesquisa))
                    {
                        Console.WriteLine(itemSeparado);
                    }
                }

            }
            else
            {
                Console.WriteLine("Ainda nao existe nenhum dado nessa tabela");
            }
        }


    }
    public interface IOperacoesBD
    {
        public void Inserir(string nomeArquivo, string linha);
        public void Alterar(string nomeArquivo, string linhaASerAlterada, string novaLinha);
        public void Deletar(string nomeArquivo, string linha);
        public void Pesquisar(string nomeArquivo, string pesquisa);
    }

    sealed class Clientes : Cadastros
    {
        //As Classes Clientes e Pedidos devem preencher a propriedade Conexão a partir de seus construtores
    }

    sealed class Pedidos : Cadastros
    {
        //As Classes Clientes e Pedidos devem preencher a propriedade Conexão a partir de seus construtores
    }

    //4.6) O método Deletar deve sofrer sobrecarga nas duas Classes, executando o código da Classe Superior e incluindo algo novo

    //4.7) O método Inserir deve sofrer sobrecarga na classe Pedidos, desconsiderando a implementação do método da classe Superior
}





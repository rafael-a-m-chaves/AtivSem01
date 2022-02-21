using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtivSem01
{
    public abstract class Cadastros : IOperacoesBD
    {
        protected string Conexao { get; set; }

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
                var paraSaberSeFoiEncontrado = fileArray.Length;

                foreach (var item in fileArray)
                {
                    if (item.Contains(linhaASerAlterada))
                    {
                        fileArray[controle].Remove(0);
                        fileArray[controle] = novaLinha;
                        paraSaberSeFoiEncontrado++;
                    }
                    fileArray[controle] = fileArray[controle] + "\n";
                    controle++;
                    paraSaberSeFoiEncontrado--;
                }
                if(paraSaberSeFoiEncontrado <= 0)
                {
                    File.WriteAllLines(arquivo, fileArray);
                }
                else
                {
                    Console.WriteLine("Nao foi encontrado nenhum registro");
                }
            }
            else
            {
                Console.WriteLine("Ainda nao existe nenhum dado nessa tabela");
            }
        }

        public virtual void Deletar(string nomeArquivo, string linha)
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
                    fileArray[controle] = fileArray[controle] + "\n";
                    controle++;
                }

                File.WriteAllLines(arquivo, fileArray);
            }
            else
            {
                Console.WriteLine("Ainda nao existe nenhum dado nessa tabela");
            }
        }

        public virtual void Inserir(string nomeArquivo, string linha)
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
                int controle = 0;
                foreach(var item in fileArray)
                {
                    var itemSeparado = item.Split(';');
                    if (itemSeparado.Contains(pesquisa))
                    {
                        Console.WriteLine(itemSeparado);
                        controle++;
                    }
                }
                if(controle == 0)
                {
                    Console.WriteLine("Não foi encontrado nenhum registro");
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

    public sealed class Clientes : Cadastros
    {
        public void Inserir()
        {
            base.Conexao = "Conectando a instancia local";
            Console.WriteLine(base.Conexao);
            Console.WriteLine("Digite o nome do cliente");
            var nome = Console.ReadLine();
            Console.WriteLine("Digite o Endereço do Cliente");
            var endereco = Console.ReadLine();
            var linha = nome + ";"+ endereco;
            base.Inserir("cliente", linha);
        }

        public void Pesquisar()
        {
            base.Conexao = "Conectando a instancia local";
            Console.WriteLine(base.Conexao);
            Console.WriteLine("Digite o nome do cliente para pesquisar");
            var nome = Console.ReadLine();
            base.Inserir("cliente", nome);
        }
        public void Alterar(string linhaASerAlterada)
        {
            base.Conexao = "Conectando a instancia local";
            Console.WriteLine(base.Conexao);
            Console.WriteLine("Digite o  novo nome do cliente");
            var nome = Console.ReadLine();
            Console.WriteLine("Digite o novo Endereço do Cliente");
            var endereco = Console.ReadLine();
            var linha = nome + ";"+ endereco;
            base.Alterar("cliente", linhaASerAlterada, linha);
        }
        public override void Deletar(string nomeArquivo, string linha)
        {
            base.Conexao = "Conectando a instancia local";
            Console.WriteLine(base.Conexao);
            Console.WriteLine("lendo arquivo");
            Thread.Sleep(2000);
            Console.WriteLine("procurando por:   " + linha);
            base.Deletar(nomeArquivo, linha);
        }
    }

    public sealed class Pedidos : Cadastros
    {
        public override void Inserir(string nomeArquivo, string linha)
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Pesquisar()
        {
            base.Conexao = "Conectando a instancia local";
            Console.WriteLine(base.Conexao);
            Console.WriteLine("Digite o nome do cliente para pesquisar");
            var nome = Console.ReadLine();
            base.Inserir("pedido", nome);
        }
        public void Alterar(string linhaASerAlterada)
        {
            base.Conexao = "Conectando a instancia local";
            Console.WriteLine(base.Conexao);
            Console.WriteLine("Digite o  novo numero do pedido");
            var numero = Console.ReadLine();
            Console.WriteLine("Digite o novo nome do Cliente");
            var nome = Console.ReadLine();
            var linha = numero + ";"+ nome;
            base.Alterar("pedido", linhaASerAlterada, linha);
        }
        public override void Deletar(string nomeArquivo, string linha)
        {
            base.Conexao = "Conectando a instancia local";
            Console.WriteLine(base.Conexao);
            Console.WriteLine("lendo arquivo");
            Thread.Sleep(2000);
            Console.WriteLine("procurando por:   " + linha);
            base.Deletar( nomeArquivo,  linha);
        }
    }

}





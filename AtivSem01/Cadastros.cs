using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01
{
    public abstract class Cadastros : IOperacoesBD
    {
        protected string Conexao { get; set; }

        public void Alterar()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public void Pesquisar()
        {
            throw new NotImplementedException();
        }


    }
    public interface IOperacoesBD
    {
        public void Inserir();
        public void Alterar();
        public void Deletar();
        public void Pesquisar();
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

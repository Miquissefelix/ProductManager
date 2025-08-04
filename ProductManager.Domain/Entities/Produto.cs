using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public decimal Preco { get; set; }
        public int Quantidade {  get; set; }

        public Produto(string nome, decimal preco, int quantidade)
        {
            if (string.IsNullOrEmpty(nome))
            
                throw new ArgumentNullException("Nome do produto é obrigatório.");
            
            if (preco < 0)
                throw new ArgumentException("Preço não pode ser negativo.");

            if (quantidade < 0)
                throw new ArgumentException("Quantidade não pode ser negativa.");

            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }


        public void Atualizar(string nome, decimal preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}

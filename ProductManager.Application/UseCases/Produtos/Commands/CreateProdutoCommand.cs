using MediatR;
using ProductManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.UseCases.Produtos.Commands
{
    public class CreateProdutoCommand : IRequest<ProdutoDto>
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}

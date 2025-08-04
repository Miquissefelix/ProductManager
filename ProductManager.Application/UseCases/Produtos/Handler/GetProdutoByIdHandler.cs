using MediatR;
using ProductManager.Application.DTOs;
using ProductManager.Application.UseCases.Produtos.Queries;
using ProductManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.UseCases.Produtos.Handler
{

    public class GetProdutoByIdHandler : IRequestHandler<GetProdutoByIdQuery, ProdutoDto?>
    {
        private readonly IProdutoRepository _repository;

        public GetProdutoByIdHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoDto?> Handle(GetProdutoByIdQuery query,CancellationToken cancellationToken)
        {
            var produto = await _repository.ObterPorIdAsync(query.Id);

            if (produto == null)
                return null;

            return new ProdutoDto
            {
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
            };
        }
    }
}

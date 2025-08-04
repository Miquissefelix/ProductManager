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
    public class GetAllProdutosHandler : IRequestHandler<GetAllProdutosQuery, List<ProdutoDto>>
    {
        private readonly IProdutoRepository _repository;

        public GetAllProdutosHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProdutoDto>> Handle(GetAllProdutosQuery query,CancellationToken cancellationToken)
        {
            var produtos = await _repository.ObterTodosAsync();

            return produtos.Select(p => new ProdutoDto
            {
              
                //id=p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Quantidade = p.Quantidade
            }).ToList();
        }
    }
}

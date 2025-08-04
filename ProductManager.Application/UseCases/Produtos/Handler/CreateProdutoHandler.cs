using MediatR;
using ProductManager.Application.DTOs;
using ProductManager.Application.UseCases.Produtos.Commands;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.UseCases.Produtos.Handler
{
    public class CreateProdutoHandler : IRequestHandler<CreateProdutoCommand,ProdutoDto>
    {
        private readonly IProdutoRepository _repository;

        public CreateProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoDto>Handle(CreateProdutoCommand command,CancellationToken cancellationToken)
        {
            var produto = new Produto(command.Nome, command.Preco, command.Quantidade);
            await _repository.AdicionarAsync(produto);

            return new ProdutoDto
            {
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade=produto.Quantidade
            };
        }
    }
}

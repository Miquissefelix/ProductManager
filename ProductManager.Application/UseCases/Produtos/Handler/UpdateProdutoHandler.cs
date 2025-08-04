using MediatR;
using ProductManager.Application.DTOs;
//using ProductManager.Application.Interfaces;
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
    public class UpdateProdutoHandler : IRequestHandler<UpdateProdutoCommand,string>
    {
        private readonly IProdutoRepository _repository;

        public UpdateProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateProdutoCommand command,CancellationToken cancellationToken)
        {
            var produto = await _repository.ObterPorIdAsync(command.Id);

            if (produto == null)
                return "produto nao encotrado!";

            produto.Atualizar(command.Nome, command.Preco, command.Quantidade);
            await _repository.AtualizarAsync(produto);

            return "Produto atualizado com sucesso!";
        }
    }
}

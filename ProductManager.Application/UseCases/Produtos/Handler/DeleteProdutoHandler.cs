using MediatR;
using ProductManager.Application.UseCases.Produtos.Commands;
using ProductManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.UseCases.Produtos.Handler
{
    public class DeleteProdutoHandler : IRequestHandler<DeleteProdutoCommand,string>
    {
        private readonly IProdutoRepository _repository;

        public DeleteProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeleteProdutoCommand command,CancellationToken cancellationToken)
        {
            var produto = await _repository.ObterPorIdAsync(command.Id);
            if (produto == null) return "Produto não encontrado.";

            await _repository.RemoverAsync(command.Id);
            return "Produto deletado com sucesso.";
        }
    }
}

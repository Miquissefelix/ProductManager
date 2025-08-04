using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.UseCases.Produtos.Commands
{
    public class DeleteProdutoCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}

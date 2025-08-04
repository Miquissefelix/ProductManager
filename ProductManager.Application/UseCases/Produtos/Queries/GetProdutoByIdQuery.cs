using MediatR;
using ProductManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.UseCases.Produtos.Queries
{
    public class GetProdutoByIdQuery : IRequest<ProdutoDto?>
    {
        public GetProdutoByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        //public GetProdutoByIdQuery(Guid id)
        //{
        //    Id = id;
        //}
    }
}

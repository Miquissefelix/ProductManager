using MediatR;
using ProductManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.UseCases.Produtos.Queries
{
    public class GetAllProdutosQuery :IRequest<List<ProdutoDto>>
    {
    }
}

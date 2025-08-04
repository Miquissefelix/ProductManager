using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.DTOs;
//using ProductManager.Application.Interfaces;
using ProductManager.Application.UseCases.Produtos.Commands;
using ProductManager.Application.UseCases.Produtos.Queries;

namespace ProductManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        //private readonly IProdutoService _produtoService;
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ProdutoDto dto)
        {
            var command = new CreateProdutoCommand
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                Quantidade = dto.Quantidade
            };

            var produtoCriado = await _mediator.Send(command);
            return Ok(produtoCriado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosProdutos()
        {
            var produtos = await _mediator.Send(new GetAllProdutosQuery());
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>ObterPorId(Guid id)
        {
            var produto = await _mediator.Send(new GetProdutoByIdQuery(id));
            if (produto == null)
                return NotFound("produto nao encotrado");

            return Ok(produto);

        }

      

        [HttpPut("{id}")]
        public async Task<IActionResult>Atualizar(Guid id, [FromBody] ProdutoDto dto)
        {
            var command = new UpdateProdutoCommand
            {
                Id = id,
                Nome = dto.Nome,
                Preco = dto.Preco,
                Quantidade = dto.Quantidade
            };

           var resultado= await _mediator.Send(command);
            if (resultado == "produto nao encotrado!")
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var resultado = await _mediator.Send(new DeleteProdutoCommand { Id = id });

            if (resultado == "Produto não encontrado")
                return NotFound(resultado);

            return Ok(resultado);
        }


    }
}


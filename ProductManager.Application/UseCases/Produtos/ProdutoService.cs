//using ProductManager.Application.DTOs;
//using ProductManager.Application.Interfaces;
//using ProductManager.Domain.Entities;
//using ProductManager.Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ProductManager.Application.UseCases.Produtos
//{
//    public class ProdutoService : IProdutoService
//    {
//        private readonly IProdutoRepository _repository;

//        public ProdutoService(IProdutoRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<ProdutoDto> CriarAsync(ProdutoDto dto)
//        {
//            var produto = new Produto(dto.Nome, dto.Preco, dto.Quantidade);
//            await _repository.AdicionarAsync(produto);

//            return dto;
//        }

//        public async Task<IEnumerable<ProdutoDto>> ObterTodosAsync()
//        {
//            var produtos = await _repository.ObterTodosAsync();
//            return produtos.Select(p => new ProdutoDto
//            {
               
//                Nome = p.Nome,
//                Preco = p.Preco,
//                Quantidade = p.Quantidade
//            });
//        }

//        public async Task<ProdutoDto?> ObterPorIdAsync(Guid id)
//        {
//            var p = await _repository.ObterPorIdAsync(id);
//            if (p == null) return null;

//            return new ProdutoDto
//            {
//                Nome = p.Nome,
//                Preco = p.Preco,
//                Quantidade = p.Quantidade
//            };
//        }

//        public async Task AtualizarAsync(Guid id, ProdutoDto dto)
//        {
//            var produto = await _repository.ObterPorIdAsync(id);
//            if (produto is null)
//                throw new KeyNotFoundException("Produto não encontrado");

//            produto.Atualizar(dto.Nome, dto.Preco, dto.Quantidade);
//            await _repository.AtualizarAsync(produto);
//        }

//        public async Task RemoverAsync(Guid id)
//        {
//            await _repository.RemoverAsync(id);
//        }
//    }
//}

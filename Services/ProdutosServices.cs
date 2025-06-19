using System;
using System.Collections.Generic;
using System.Linq;
using APIVendas.BaseDados;
using APIVendas.BaseDados.Models;
using APIVendas.Services.DTOs;
using APIVendas.Services.Exceptions;
using APIVendas.Services.Validations;
using AutoMapper;

namespace APIVendas.Services
{
    public class ProdutosServices
    {
        private readonly ApiDbContext _dbcontext;
        private readonly IMapper _mapper;

        public ProdutosServices(ApiDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<ProdutoDTO> ObterTodos()
        {
            var produtos = _dbcontext.Produtos.ToList(); // Verifique se o DbSet chama "Categorias"
            return _mapper.Map<List<ProdutoDTO>>(produtos);
        }

        public ProdutoDTO ObterPorId(int id)
        {
            var produto = _dbcontext.Produtos.FirstOrDefault(c => c.Idproduto == id);
            if (produto == null)
                return null;

            return _mapper.Map<ProdutoDTO>(produto);
        }

        public List<ProdutoDTO> ObterPorCategoria(int idCategoria)
        {
            var produtos = _dbcontext.Produtos
                .Where(p => p.Idcategoria == idCategoria)
                .ToList();

            return _mapper.Map<List<ProdutoDTO>>(produtos);
        }

        public ProdutoDTO Criar(CriarProdutoDTO dto)
        {
            ProdutoValidation.ValidouCriarProduto(dto);

            // Usa o AutoMapper para converter o DTO para a entidade
            var novoProduto = _mapper.Map<Produto>(dto);

            _dbcontext.Produtos.Add(novoProduto);
            _dbcontext.SaveChanges();

            // Usa o AutoMapper para converter de volta para DTO de leitura
            return _mapper.Map<ProdutoDTO>(novoProduto);
        }

        public void Remover(int id)
        {
            var produto = _dbcontext.Produtos.FirstOrDefault(c => c.Idproduto == id);
            if (produto == null)
                throw new Exception($"Cliente com ID {id} não encontrado.");

            _dbcontext.Produtos.Remove(produto);
            _dbcontext.SaveChanges();
        }

        public ProdutoDTO Atualizar(CriarProdutoDTO dto, int id)
        {
            ProdutoValidation.ValidouCriarProduto(dto);

            var produto = _dbcontext.Produtos.FirstOrDefault(c => c.Idproduto == id);

            if (produto == null)
                throw new NotFoundException("Produto não encontrado");

            // Mapeia os dados do DTO para a entidade já existente
            _mapper.Map(dto, produto);

            _dbcontext.SaveChanges();

            return _mapper.Map<ProdutoDTO>(produto);
        }
    }
}
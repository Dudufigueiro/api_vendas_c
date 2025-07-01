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
    public class VendaProdutosServices
    {
        private readonly ApiDbContext _dbcontext;
        private readonly IMapper _mapper;

        public VendaProdutosServices(ApiDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<VendaProdutoDTO> GetVendaProdutos(int idVenda)
        {
            var venda = _dbcontext.Venda.Find(idVenda);
            if (venda == null)
                throw new NotFoundException("Venda não encontrada.");

            var vendaProdutos = _dbcontext.VendaProdutos.Where(e => e.Idvenda == idVenda).ToList();

            return _mapper.Map<List<VendaProdutoDTO>>(vendaProdutos);
        }

        public VendaProdutoDTO Criar(CriarVendaProdutoDTO dto, int idVenda)
        {
            VendaProdutoValidation.ValidouCriarVendaProduto(dto);

            var novaVendaProduto = _mapper.Map<VendaProduto>(dto);

            novaVendaProduto.Idvenda = idVenda;

            _dbcontext.VendaProdutos.Add(novaVendaProduto);
            _dbcontext.SaveChanges();

            return _mapper.Map<VendaProdutoDTO>(novaVendaProduto);
        }

        public void RemoverProdutoDaVenda(int idVenda, int idProduto)
        {
            var venda = _dbcontext.Venda.Find(idVenda);
            if (venda == null)
                throw new NotFoundException("Venda não encontrada.");

            var item = _dbcontext.VendaProdutos
                .FirstOrDefault(vp => vp.Idvenda == idVenda && vp.Idproduto == idProduto);

            if (item == null)
                throw new NotFoundException("Produto não encontrado nesta venda.");

            _dbcontext.VendaProdutos.Remove(item);
            _dbcontext.SaveChanges();
        }

    }
}

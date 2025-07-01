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
    public class VendasServices
    {
        private readonly ApiDbContext _dbcontext;
        private readonly IMapper _mapper;

        public VendasServices(ApiDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<VendaDTO> ObterTodos()
        {
            var vendas = _dbcontext.Venda.ToList();
            return _mapper.Map<List<VendaDTO>>(vendas);
        }

        public VendaDTO ObterPorId(int id)
        {
            var venda = _dbcontext.Venda.FirstOrDefault(c => c.Idvenda == id);
            if (venda == null)
                return null;

            return _mapper.Map<VendaDTO>(venda);
        }

        public VendaDTO Criar(CriarVendaDTO dto)
        {
            VendaValidation.ValidouCriarVenda(dto);

            var novaVenda = _mapper.Map<Venda>(dto);

            if (string.IsNullOrEmpty(novaVenda.Data) || novaVenda.Data.ToLower() == "string")
            {
                novaVenda.Data = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            }

            _dbcontext.Venda.Add(novaVenda);
            _dbcontext.SaveChanges();

            return _mapper.Map<VendaDTO>(novaVenda);
        }

        public void Remover(int id)
        {
            var venda = _dbcontext.Venda.FirstOrDefault(c => c.Idvenda == id);
            if (venda == null)
                throw new Exception($"Venda com ID {id} não encontrado.");

            _dbcontext.Venda.Remove(venda);
            _dbcontext.SaveChanges();
        }
    }
}

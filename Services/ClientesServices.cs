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
    public class ClientesServices
    {
        private readonly ApiDbContext _dbcontext;
        private readonly IMapper _mapper;

        public ClientesServices(ApiDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<ClienteDTO> ObterTodos()
        {
            var clientes = _dbcontext.Clientes.ToList();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public ClienteDTO ObterPorId(int id)
        {
            var cliente = _dbcontext.Clientes.FirstOrDefault(c => c.Idcliente == id);
            if (cliente == null)
                return null;

            return _mapper.Map<ClienteDTO>(cliente);
        }

        public void Remover(int id)
        {
            var cliente = _dbcontext.Clientes.FirstOrDefault(c => c.Idcliente == id);
            if (cliente == null)
                throw new Exception($"Cliente com ID {id} não encontrado.");

            _dbcontext.Clientes.Remove(cliente);
            _dbcontext.SaveChanges();
        }
    }
}

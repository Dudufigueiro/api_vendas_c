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
    public class FuncionariosServices
    {
        private readonly ApiDbContext _dbcontext;
        private readonly IMapper _mapper;

        public FuncionariosServices(ApiDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<FuncionarioDTO> ObterTodos()
        {
            var funcionarios = _dbcontext.Funcionarios.ToList();
            return _mapper.Map<List<FuncionarioDTO>>(funcionarios);
        }

        public FuncionarioDTO ObterPorId(int id)
        {
            var funcionario = _dbcontext.Funcionarios.FirstOrDefault(c => c.Idfuncionario == id);
            if (funcionario == null)
                return null;

            return _mapper.Map<FuncionarioDTO>(funcionario);
        }

        public void Remover(int id)
        {
            var funcionario = _dbcontext.Funcionarios.FirstOrDefault(c => c.Idfuncionario == id);
            if (funcionario == null)
                throw new Exception($"Cliente com ID {id} não encontrado.");

            _dbcontext.Funcionarios.Remove(funcionario);
            _dbcontext.SaveChanges();
        }
    }
}

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

        public FuncionarioDTO Criar(CriarFuncionarioDTO dto)
        {
            FuncionarioValidation.ValidouCriarFuncionario(dto);

            var novoFuncionario = _mapper.Map<Funcionarios>(dto);

            novoFuncionario.Datacadastro = DateOnly.FromDateTime(DateTime.Now);

            _dbcontext.Funcionarios.Add(novoFuncionario);
            _dbcontext.SaveChanges();

            return _mapper.Map<FuncionarioDTO>(novoFuncionario);
        }

        public void Remover(int id)
        {
            var funcionario = _dbcontext.Funcionarios.FirstOrDefault(c => c.Idfuncionario == id);
            if (funcionario == null)
                throw new Exception($"Funcionario com o ID {id} não encontrado.");

            _dbcontext.Funcionarios.Remove(funcionario);
            _dbcontext.SaveChanges();
        }

        public FuncionarioDTO Atualizar(CriarFuncionarioDTO dto, int id)
        {
            FuncionarioValidation.ValidouCriarFuncionario(dto);

            var funcionario = _dbcontext.Funcionarios.FirstOrDefault(c => c.Idfuncionario == id);

            if (funcionario == null)
                throw new NotFoundException("Funcionario não encontrado");

            _mapper.Map(dto, funcionario);

            _dbcontext.SaveChanges();

            return _mapper.Map<FuncionarioDTO>(funcionario);
        }
    }
}

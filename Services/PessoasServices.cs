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
    public class PessoasServices
    {
        private readonly ApiDbContext _dbcontext;
        private readonly IMapper _mapper;

        public PessoasServices(ApiDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<PessoaDTO> ObterTodos()
        {
            var pessoas = _dbcontext.Pessoas.ToList();
            return _mapper.Map<List<PessoaDTO>>(pessoas);
        }

        public PessoaDTO ObterPorId(int id)
        {
            var pessoa = _dbcontext.Pessoas.FirstOrDefault(c => c.Idpessoa == id);
            if (pessoa == null)
                return null;

            return _mapper.Map<PessoaDTO>(pessoa);
        }

        public PessoaDTO Criar(CriarPessoaDTO dto)
        {
            PessoaValidation.ValidouCriarPessoa(dto);

            var novaPessoa = _mapper.Map<Pessoa>(dto);

            _dbcontext.Pessoas.Add(novaPessoa);
            _dbcontext.SaveChanges();

            return _mapper.Map<PessoaDTO>(novaPessoa);
        }

        public void Remover(int id)
        {
            var pessoa = _dbcontext.Pessoas.FirstOrDefault(c => c.Idpessoa == id);
            if (pessoa == null)
                throw new Exception($"Pessoa com ID {id} não encontrado.");

            _dbcontext.Pessoas.Remove(pessoa);
            _dbcontext.SaveChanges();
        }

        public PessoaDTO Atualizar(CriarPessoaDTO dto, int id)
        {
            PessoaValidation.ValidouCriarPessoa(dto);

            var pessoa = _dbcontext.Pessoas.FirstOrDefault(c => c.Idpessoa == id);

            if (pessoa == null)
                throw new NotFoundException("Pessoa não encontrada");

            _mapper.Map(dto, pessoa);

            _dbcontext.SaveChanges();

            return _mapper.Map<PessoaDTO>(pessoa);
        }
    }
}

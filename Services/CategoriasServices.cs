﻿using System;
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
    public class CategoriasService
    {
        private readonly ApiDbContext _dbcontext;
        private readonly IMapper _mapper;

        public CategoriasService(ApiDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<CategoriaDTO> ObterTodos()
        {
            var categorias = _dbcontext.Categoria.ToList();
            return _mapper.Map<List<CategoriaDTO>>(categorias);
        }

        public CategoriaDTO Criar(CriarCategoriaDTO dto)
        {
            CategoriaValidation.ValidouCriarCategoria(dto);

            var novaCategoria = _mapper.Map<Categoria>(dto);

            _dbcontext.Categoria.Add(novaCategoria);
            _dbcontext.SaveChanges();

            return _mapper.Map<CategoriaDTO>(novaCategoria);
        }

        public void Remover(int id)
        {
            var categoria = _dbcontext.Categoria.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
                throw new Exception($"Categoria com o ID {id} não encontrada.");

            _dbcontext.Categoria.Remove(categoria);
            _dbcontext.SaveChanges();
        }

        public CategoriaDTO Atualizar(CriarCategoriaDTO dto, int id)
        {
            CategoriaValidation.ValidouCriarCategoria(dto);

            var categoria = _dbcontext.Categoria.FirstOrDefault(c => c.Id == id);

            if (categoria == null)
                throw new NotFoundException("Categoria não encontrada");

            _mapper.Map(dto, categoria);

            _dbcontext.SaveChanges();

            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public CategoriaDTO ObterPorId(int id)
        {
            var categoria = _dbcontext.Categoria.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
                return null;

            return _mapper.Map<CategoriaDTO>(categoria);
        }

    }
}

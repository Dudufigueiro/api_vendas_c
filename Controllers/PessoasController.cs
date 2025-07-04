﻿using Microsoft.AspNetCore.Mvc;
using APIVendas.Services;
using APIVendas.Services.DTOs;
using AutoMapper;
using APIVendas.BaseDados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using APIVendas.Services.Exceptions;
using Microsoft.AspNetCore.Http;


namespace APIVendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json")]
    public class PessoasController : ControllerBase
    {
        private readonly PessoasServices _pessoasServices;
        private readonly IMapper _mapper;

        public PessoasController(PessoasServices pessoasServices, IMapper mapper)
        {
            _pessoasServices = pessoasServices;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<PessoaDTO>> ObterTodos()
        {
            var pessoa = _pessoasServices.ObterTodos();
            return Ok(pessoa);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PessoaDTO> GetById(int id)
        {
            var pessoa = _pessoasServices.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound($"Pessoa com o ID {id} não encontrado.");
            }

            return Ok(pessoa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PessoaDTO> Criar([FromBody] CriarPessoaDTO dto)
        {
            try
            {
                var pessoaCriada = _pessoasServices.Criar(dto);
                return CreatedAtAction(nameof(ObterTodos), new { id = pessoaCriada.Idpessoa }, pessoaCriada);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Remover(int id)
        {
            try
            {
                _pessoasServices.Remover(id);
                return NoContent(); // 204 - sucesso, sem conteúdo
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PessoaDTO> Atualizar(int id, [FromBody] CriarPessoaDTO body)
        {
            try
            {
                var Response = _pessoasServices.Atualizar(body, id);
                return Ok(Response); //200
            }
            catch (NotFoundException C)
            {
                return NotFound(C.Message); //404
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message); //400
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")] // get que busca pelo id
        public ActionResult<PessoaDTO> GetById(int id)
        {
            var pessoa = _pessoasServices.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound($"Categoria com ID {id} não encontrado."); // se não encontrar o cliente pelo id especificado, retorna erro
            }

            return Ok(pessoa);
        }
    }
}

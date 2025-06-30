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
    public class FuncionariosController : ControllerBase
    {
        private readonly FuncionariosServices _funcionariosServices;
        private readonly IMapper _mapper;

        public FuncionariosController(FuncionariosServices funcionariosServices, IMapper mapper)
        {
            _funcionariosServices = funcionariosServices;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<FuncionarioDTO>> ObterTodos()
        {
            var funcionario = _funcionariosServices.ObterTodos();
            return Ok(funcionario);
        }

        [HttpGet("{id}")] // get que busca pelo id
        public ActionResult<FuncionarioDTO> GetById(int id)
        {
            var funcionario = _funcionariosServices.ObterPorId(id);
            if (funcionario == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado."); // se não encontrar o cliente pelo id especificado, retorna erro
            }

            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                _funcionariosServices.Remover(id);
                return NoContent(); // 204 - sucesso, sem conteúdo
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}

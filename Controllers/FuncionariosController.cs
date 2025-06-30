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

        [HttpPost]
        public ActionResult<FuncionarioDTO> Criar([FromBody] CriarFuncionarioDTO dto)
        {
            try
            {
                var funcionarioCriado = _funcionariosServices.Criar(dto);
                return CreatedAtAction(nameof(ObterTodos), new { id = funcionarioCriado.Idfuncionario }, funcionarioCriado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
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

        [HttpPut("{id}")]
        public ActionResult<FuncionarioDTO> Atualizar(int id, [FromBody] CriarFuncionarioDTO body)
        {
            try
            {
                var Response = _funcionariosServices.Atualizar(body, id);
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
            catch (System.Exception E)
            {
                return BadRequest(E.Message); //500
            }
        }
    }
}

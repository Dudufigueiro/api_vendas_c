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
    public class ClientesController : ControllerBase
    {
        private readonly ClientesServices _clientesServices;
        private readonly IMapper _mapper;

        public ClientesController(ClientesServices clientesServices, IMapper mapper)
        {
            _clientesServices = clientesServices;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ClienteDTO>> ObterTodos()
        {
            var cliente = _clientesServices.ObterTodos();
            return Ok(cliente);
        }

        [HttpGet("{id}")] // get que busca pelo id
        public ActionResult<ClienteDTO> GetById(int id)
        {
            var cliente = _clientesServices.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado."); // se não encontrar o cliente pelo id especificado, retorna erro
            }

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<ClienteDTO> Criar([FromBody] CriarClienteDTO dto)
        {
            try
            {
                var clienteCriado = _clientesServices.Criar(dto);
                return CreatedAtAction(nameof(ObterTodos), new { id = clienteCriado.Idcliente }, clienteCriado);
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
                _clientesServices.Remover(id);
                return NoContent(); // 204 - sucesso, sem conteúdo
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ClienteDTO> Atualizar(int id, [FromBody] CriarClienteDTO body)
        {
            try
            {
                var Response = _clientesServices.Atualizar(body, id);
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

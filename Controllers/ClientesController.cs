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
    }
}

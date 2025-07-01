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
    public class VendasController : ControllerBase
    {
        private readonly VendasServices _vendasServices;
        private readonly IMapper _mapper;

        public VendasController(VendasServices vendasServices, IMapper mapper)
        {
            _vendasServices = vendasServices;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<VendaDTO>> ObterTodos()
        {
            var venda = _vendasServices.ObterTodos();
            return Ok(venda);
        }

        [HttpGet("{id}")] // get que busca pelo id
        public ActionResult<VendaDTO> GetById(int id)
        {
            var venda = _vendasServices.ObterPorId(id);
            if (venda == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado."); // se não encontrar o cliente pelo id especificado, retorna erro
            }

            return Ok(venda);
        }

        [HttpPost]
        public ActionResult<VendaDTO> Criar([FromBody] CriarVendaDTO dto)
        {
            try
            {
                var vendaCriada = _vendasServices.Criar(dto);
                return CreatedAtAction(nameof(ObterTodos), new { id = vendaCriada.Idvenda }, vendaCriada);
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
                _vendasServices.Remover(id);
                return NoContent(); // 204 - sucesso, sem conteúdo
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<VendaDTO> Atualizar(int id, [FromBody] CriarVendaDTO body)
        {
            try
            {
                var Response = _vendasServices.Atualizar(body, id);
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

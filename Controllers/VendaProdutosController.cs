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
    [Route("api/vendas/{id}/[controller]")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json")]
    public class VendaProdutosController : ControllerBase
    {
        private readonly VendaProdutosServices _vendaProdutosServices;
        private readonly IMapper _mapper;

        public VendaProdutosController(VendaProdutosServices vendaProdutosServices, IMapper mapper)
        {
            _vendaProdutosServices = vendaProdutosServices;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<VendaProdutoDTO>> GetProdutosDaVenda(int id)
        {
            var produtos = _vendaProdutosServices.GetVendaProdutos(id);
            return Ok(produtos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VendaProdutoDTO> Criar(int id, [FromBody] CriarVendaProdutoDTO dto)
        {
            try
            {
                var vendaProdutoCriado = _vendaProdutosServices.Criar(dto, id);
                return Ok(vendaProdutoCriado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{idProduto}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoverProduto(int id, int idProduto)
        {
            try
            {
                _vendaProdutosServices.RemoverProdutoDaVenda(id, idProduto);
                return NoContent(); // 204
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }

        [HttpPut("{idProduto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VendaProdutoDTO> Atualizar(int id, int idProduto, [FromBody] CriarVendaProdutoDTO dto)
        {
            try
            {
                var atualizado = _vendaProdutosServices.Atualizar(id, idProduto, dto);
                return Ok(atualizado);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

    }
}

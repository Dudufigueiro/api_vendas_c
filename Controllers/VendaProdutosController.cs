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

        [HttpDelete("{idProduto}")]

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
    }
}

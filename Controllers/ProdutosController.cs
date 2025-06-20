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
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutosServices _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(ProdutosServices produtoServices, IMapper mapper)
        {
            _produtoService = produtoServices;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<CategoriaDTO>> ObterTodos()
        {
            var categorias = _produtoService.ObterTodos();
            return Ok(categorias);
        }

        [HttpGet("{id}")] // get que busca pelo id
        public ActionResult<ProdutoDTO> GetById(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            if (produto == null)
            {
                return NotFound($"Categoria com ID {id} não encontrado."); // se não encontrar o cliente pelo id especificado, retorna erro
            }

            return Ok(produto);
        }

        [HttpGet("categoria/{idcategoria}")]
        public ActionResult<List<ProdutoDTO>> GetPorCategoria(int idcategoria)
        {
            var produtos = _produtoService.ObterPorCategoria(idcategoria);

            if (produtos == null || produtos.Count == 0)
                return NotFound("Nenhum produto encontrado para essa categoria.");

            return Ok(produtos);
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Criar([FromBody] CriarProdutoDTO dto)
        {
            try
            {
                var produtoCriado = _produtoService.Criar(dto);
                return CreatedAtAction(nameof(ObterTodos), new { id = produtoCriado.Idproduto }, produtoCriado);
            }
            catch (System.Exception ex)
            {
                // Aqui você pode melhorar para retornar mensagens mais detalhadas se desejar
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                _produtoService.Remover(id);
                return NoContent(); // 204 - sucesso, sem conteúdo
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ProdutoDTO> Atualizar(int id, [FromBody] CriarProdutoDTO body)
        {
            try
            {
                var Response = _produtoService.Atualizar(body, id);
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
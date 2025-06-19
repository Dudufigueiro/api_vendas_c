using Microsoft.AspNetCore.Mvc;
using APIVendas.Services;
using APIVendas.Services.DTOs;
using AutoMapper;
using APIVendas.BaseDados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using APIVendas.Services.Exceptions;

namespace APIVendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriasService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriasController(CategoriasService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<CategoriaDTO>> ObterTodos()
        {
            var categorias = _categoriaService.ObterTodos();
            return Ok(categorias);
        }

        [HttpGet("{id}")] // get que busca pelo id
        public ActionResult<CategoriaDTO> GetById(int id)
        {
            var categoria = _categoriaService.ObterPorId(id);
            if (categoria == null)
            {
                return NotFound($"Categoria com ID {id} não encontrado."); // se não encontrar o cliente pelo id especificado, retorna erro
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<CategoriaDTO> Criar([FromBody] CriarCategoriaDTO dto)
        {
            try
            {
                var categoriaCriada = _categoriaService.Criar(dto);
                return CreatedAtAction(nameof(ObterTodos), new { id = categoriaCriada.Id }, categoriaCriada);
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
                _categoriaService.Remover(id);
                return NoContent(); // 204 - sucesso, sem conteúdo
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<CategoriaDTO> Atualizar(int id, [FromBody] CriarCategoriaDTO body)
        {
            try
            {
                var Response = _categoriaService.Atualizar(body, id);
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

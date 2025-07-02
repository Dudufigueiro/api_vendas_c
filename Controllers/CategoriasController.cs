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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CategoriaDTO>> ObterTodos()
        {
            var categorias = _categoriaService.ObterTodos();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CategoriaDTO> GetById(int id)
        {
            var categoria = _categoriaService.ObterPorId(id);
            if (categoria == null)
            {
                return NotFound($"Categoria com ID {id} não encontrado.");
            }

            return Ok(categoria);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CategoriaDTO> Criar([FromBody] CriarCategoriaDTO dto)
        {
            try
            {
                var categoriaCriada = _categoriaService.Criar(dto);
                return CreatedAtAction(nameof(ObterTodos), new { id = categoriaCriada.Id }, categoriaCriada);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Remover(int id)
        {
            try
            {
                _categoriaService.Remover(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        }
    }

}

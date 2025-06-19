using APIVendas.Services.DTOs;
using APIVendas.Services.Exceptions;
using System.Linq;

namespace APIVendas.Services.Validations
{
    public class CategoriaValidation
    {
        public static void ValidouCriarCategoria(
            CriarCategoriaDTO criarCategoriaDTO)
        {
            if (string.IsNullOrEmpty(criarCategoriaDTO.Nome))
                throw new BadRequestException("Nome é obrigatorio");

            if (criarCategoriaDTO.Codcategoria <= 0)
                throw new BadRequestException("Código da categoria é obrigatório e deve ser maior que zero");

        }
    }
}

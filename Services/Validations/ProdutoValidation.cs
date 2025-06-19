using APIVendas.Services.DTOs;
using APIVendas.Services.Exceptions;
using System.Linq;

namespace APIVendas.Services.Validations
{
    public class ProdutoValidation
    {
        public static void ValidouCriarProduto(
            CriarProdutoDTO criarProdutoDTO)
        {
            if (string.IsNullOrEmpty(criarProdutoDTO.Nome))
                throw new BadRequestException("Nome é obrigatorio");

            if (criarProdutoDTO.Idcategoria <= 0)
                throw new BadRequestException("Código da categoria é obrigatório e deve ser maior que zero");

        }
    }
}
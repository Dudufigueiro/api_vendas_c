using APIVendas.Services.DTOs;
using APIVendas.Services.Exceptions;
using System.Linq;

namespace APIVendas.Services.Validations
{
    public class VendaProdutoValidation
    {
        public static void ValidouCriarVendaProduto(
            CriarVendaProdutoDTO criarVendaProdutoDTO)
        {
            if (criarVendaProdutoDTO.Quantidade <= 0)
                throw new BadRequestException("Informe a quantidade do item");

            if (criarVendaProdutoDTO.Valor <= 0)
                throw new BadRequestException("Informe a valor do item");

            if (criarVendaProdutoDTO.Idproduto <= 0)
                throw new BadRequestException("Informe a id do item");

        }
    }
}

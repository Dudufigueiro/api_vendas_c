using APIVendas.Services.DTOs;
using APIVendas.Services.Exceptions;
using System.Linq;

namespace APIVendas.Services.Validations
{
    public class VendaValidation
    {
        public static void ValidouCriarVenda(
            CriarVendaDTO criarVendaDTO)
        {
            if (criarVendaDTO.Idfuncionario <= 0)
                throw new BadRequestException("Obrigatório informar o id do funcionário");

            if (criarVendaDTO.Idcliente <= 0)
                throw new BadRequestException("Obrigatório informar o id do cliente");
        }
    }
}

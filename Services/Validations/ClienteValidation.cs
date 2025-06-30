using APIVendas.Services.DTOs;
using APIVendas.Services.Exceptions;
using System.Linq;

namespace APIVendas.Services.Validations
{
    public class ClienteValidation
    {
        public static void ValidouCriarCliente(
            CriarClienteDTO criarClienteDTO)
        {
            if (criarClienteDTO.Codcliente <= 0)
                throw new BadRequestException("Obrigatório informar o código do cliente");

            if (criarClienteDTO.Idpessoa <= 0)
                throw new BadRequestException("Obrigatório informar o id da pessoa");
        }
    }
}
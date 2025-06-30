using APIVendas.Services.DTOs;
using APIVendas.Services.Exceptions;
using System.Linq;

namespace APIVendas.Services.Validations
{
    public class FuncionarioValidation
    {
        public static void ValidouCriarFuncionario(
            CriarFuncionarioDTO criarFuncionarioDTO)
        {
            if (criarFuncionarioDTO.Salario <= 0)
                throw new BadRequestException("Obrigatório informar o salário do funcionário");

            if (string.IsNullOrEmpty(criarFuncionarioDTO.Cargo) || criarFuncionarioDTO.Cargo.Trim().ToLower() == "string")
                throw new BadRequestException("Obrigatório informar o cargo do funcionário");

            if (criarFuncionarioDTO.Idpessoa <= 0)
                throw new BadRequestException("Obrigatório informar o id da pessoa");

            if (criarFuncionarioDTO.Codfuncionario <= 0)
                throw new BadRequestException("Obrigatório inserir o código do funcionário");
        }
    }
}

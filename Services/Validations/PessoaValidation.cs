using APIVendas.Services.DTOs;
using APIVendas.Services.Exceptions;
using System.Linq;

namespace APIVendas.Services.Validations
{
    public class PessoaValidation
    {
        public static void ValidouCriarPessoa(
            CriarPessoaDTO criarPessoaDTO)
        {
            if (string.IsNullOrEmpty(criarPessoaDTO.Nome) || criarPessoaDTO.Nome.Trim().ToLower() == "string")
                throw new BadRequestException("Nome é obrigatório");

            if (string.IsNullOrEmpty(criarPessoaDTO.Email))
                throw new BadRequestException("Email é obrigatório");

            if (string.IsNullOrEmpty(criarPessoaDTO.Datanasc))
                throw new BadRequestException("Data de Nascimento é obrigatória");

            if (string.IsNullOrEmpty(criarPessoaDTO.Telefone))
                throw new BadRequestException("Telefone é obrigatório");

            if (criarPessoaDTO.Codpessoa <= 0)
                throw new BadRequestException("Obrigatório informar o código da pessoa");

        }
    }
}

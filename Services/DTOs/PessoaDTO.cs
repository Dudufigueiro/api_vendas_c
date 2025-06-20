using System;

namespace APIVendas.Services.DTOs
{
    public class PessoaDTO
    {
        public int Idpessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Datanasc { get; set; }
        public string Telefone { get; set; }
        public int Codpessoa { get; set; }
    }
}

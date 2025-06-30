using System;

namespace APIVendas.Services.DTOs
{
    public class ClienteDTO
    {
        public int Idcliente { get; set; }
        public DateOnly Datacadastro { get; set; }
        public int Codcliente { get; set; }
        public int Idpessoa { get; set; }
    }

    public class CriarClienteDTO
    {
        public int Codcliente { get; set; }
        public int Idpessoa { get; set; }
    }
}

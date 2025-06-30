using System;

namespace APIVendas.Services.DTOs
{
    public class FuncionarioDTO
    {
        public int Idfuncionario { get; set; }
        public double? Salario { get; set; }
        public string Cargo { get; set; }
        public int Idpessoa { get; set; }
        public DateOnly Datacadastro { get; set; }
        public int Codfuncionario { get; set; }
    }
}

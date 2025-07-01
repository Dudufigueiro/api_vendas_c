using System;
using System.Collections.Generic;

namespace APIVendas.Services.DTOs
{
    public class VendaDTO
    {
        public int Idvenda { get; set; }

        public string Data { get; set; }

        public int Idfuncionario { get; set; }

        public double Valor { get; set; }

        public int Idcliente { get; set; }
    }

    public class CriarVendaDTO
    {
        public string Data { get; set; }

        public int Idfuncionario { get; set; }

        public double Valor { get; set; }

        public int Idcliente { get; set; }
    }
}

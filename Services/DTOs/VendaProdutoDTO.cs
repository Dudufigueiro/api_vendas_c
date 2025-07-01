using System;
using APIVendas.BaseDados.Models;

namespace APIVendas.Services.DTOs
{
    public class VendaProdutoDTO
    {
        public int Idproduto { get; set; }

        public int Quantidade { get; set; }

        public double Valor { get; set; }

        public int Idvenda { get; set; }

        public Produto IdprodutoNavigation { get; set; }
        public Venda IdvendaNavigation { get; set; }
    }
}

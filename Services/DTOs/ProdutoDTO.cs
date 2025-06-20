using System;

namespace APIVendas.Services.DTOs
{
    public class CriarProdutoDTO
    {
        public int Codproduto { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Qntestoque { get; set; }
        public int Idcategoria { get; set; }
    }
    public class ProdutoDTO
    {
        public int Idproduto { get; set; }
        public int Codproduto { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Qntestoque {  get; set; }
        public int Idcategoria { get; set; }
    }
}
using System;

namespace APIVendas.Services.DTOs
{
    public class CriarCategoriaDTO
    {
        public string Nome { get; set; }
        public int Codcategoria { get; set; }

    }
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codcategoria { get; set; }
    }
}
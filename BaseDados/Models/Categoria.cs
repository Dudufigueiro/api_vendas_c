using System;
using System.Collections.Generic;

namespace APIVendas.BaseDados.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public int? Codcategoria { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; }

}

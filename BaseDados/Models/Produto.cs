using System;
using System.Collections.Generic;

namespace APIVendas.BaseDados.Models;

public partial class Produto
{
    public int Idproduto { get; set; }

    public int? Codproduto { get; set; }

    public string Nome { get; set; }

    public double? Preco { get; set; }

    public int? Qntestoque { get; set; }

    public int? Idcategoria { get; set; }

    public virtual Categoria IdcategoriaNavigation { get; set; }
}

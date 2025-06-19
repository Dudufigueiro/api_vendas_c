using System;
using System.Collections.Generic;

namespace APIVendas.BaseDados.Models;

public partial class VendaProduto
{
    public int? Idproduto { get; set; }

    public int? Quantidade { get; set; }

    public double? Valor { get; set; }

    public int? Idvenda { get; set; }

    public virtual Produto IdprodutoNavigation { get; set; }

    public virtual Venda IdvendaNavigation { get; set; }
}

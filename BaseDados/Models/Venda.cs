using System;
using System.Collections.Generic;

namespace APIVendas.BaseDados.Models;

public partial class Venda
{
    public int Idvenda { get; set; }

    public string Data { get; set; }

    public int? Idfuncionario { get; set; }

    public double? Valor { get; set; }

    public int? Idcliente { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; }

    public virtual Funcionarios IdfuncionarioNavigation { get; set; }
}

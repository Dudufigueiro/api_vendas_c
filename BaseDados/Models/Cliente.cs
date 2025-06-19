using System;
using System.Collections.Generic;

namespace APIVendas.BaseDados.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public int? Idpessoa { get; set; }

    public DateOnly? Datacadastro { get; set; }

    public int? Codcliente { get; set; }

    public virtual Pessoa IdpessoaNavigation { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}

using System;
using System.Collections.Generic;

namespace APIVendas.BaseDados.Models;

public partial class Pessoa
{
    public int Idpessoa { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Datanasc { get; set; }

    public string Telefone { get; set; }

    public int? Codpessoa { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Funcionarios> Funcionarios { get; set; } = new List<Funcionarios>();
}

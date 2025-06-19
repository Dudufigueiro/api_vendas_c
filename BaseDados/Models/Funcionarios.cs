using System;
using System.Collections.Generic;

namespace APIVendas.BaseDados.Models;

public partial class Funcionarios
{
    public int Idfuncionario { get; set; }

    public double? Salario { get; set; }

    public string Cargo { get; set; }

    public int? Idpessoa { get; set; }

    public DateOnly? Datacadastro { get; set; }

    public int? Codfuncionario { get; set; }

    public virtual Pessoa IdpessoaNavigation { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}

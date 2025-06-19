using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIVendas.BaseDados.Models;

public partial class ApiDbContext : DbContext
{
    public ApiDbContext()
    {
    }

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Funcionarios> Funcionarios { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<VendaProduto> VendaProdutos { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ApiDB;Username=postgres;Password=masterkey");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.Property(e => e.Id).HasColumnName("idcategoria");
            entity.Property(e => e.Codcategoria).HasColumnName("codcategoria");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Codcliente).HasColumnName("codcliente");
            entity.Property(e => e.Datacadastro).HasColumnName("datacadastro");
            entity.Property(e => e.Idpessoa).HasColumnName("idpessoa");

            entity.HasOne(d => d.IdpessoaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idpessoa)
                .HasConstraintName("cliente_idpessoa_fkey");
        });

        modelBuilder.Entity<Funcionarios>(entity =>
        {
            entity.HasKey(e => e.Idfuncionario).HasName("funcionarios_pkey");

            entity.ToTable("funcionarios");

            entity.Property(e => e.Idfuncionario).HasColumnName("idfuncionario");
            entity.Property(e => e.Cargo)
                .HasMaxLength(30)
                .HasColumnName("cargo");
            entity.Property(e => e.Codfuncionario).HasColumnName("codfuncionario");
            entity.Property(e => e.Datacadastro).HasColumnName("datacadastro");
            entity.Property(e => e.Idpessoa).HasColumnName("idpessoa");
            entity.Property(e => e.Salario).HasColumnName("salario");

            entity.HasOne(d => d.IdpessoaNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.Idpessoa)
                .HasConstraintName("funcionarios_idpessoa_fkey");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Idpessoa).HasName("pessoa_pkey");

            entity.ToTable("pessoa");

            entity.Property(e => e.Idpessoa).HasColumnName("idpessoa");
            entity.Property(e => e.Codpessoa).HasColumnName("codpessoa");
            entity.Property(e => e.Datanasc)
                .HasMaxLength(30)
                .HasColumnName("datanasc");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(30)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Idproduto).HasName("produto_pkey");

            entity.ToTable("produto");

            entity.Property(e => e.Idproduto).HasColumnName("idproduto");
            entity.Property(e => e.Codproduto).HasColumnName("codproduto");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .HasColumnName("nome");
            entity.Property(e => e.Preco).HasColumnName("preco");
            entity.Property(e => e.Qntestoque).HasColumnName("qntestoque");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.Idcategoria)
                .HasConstraintName("produto_idcategoria_fkey");
        });

        modelBuilder.Entity<VendaProduto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("venda_produto");

            entity.Property(e => e.Idproduto).HasColumnName("idproduto");
            entity.Property(e => e.Idvenda).HasColumnName("idvenda");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdprodutoNavigation).WithMany()
                .HasForeignKey(d => d.Idproduto)
                .HasConstraintName("venda_produto_idproduto_fkey");

            entity.HasOne(d => d.IdvendaNavigation).WithMany()
                .HasForeignKey(d => d.Idvenda)
                .HasConstraintName("venda_produto_idvenda_fkey");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.Idvenda).HasName("venda_pkey");

            entity.ToTable("venda");

            entity.Property(e => e.Idvenda).HasColumnName("idvenda");
            entity.Property(e => e.Data)
                .HasMaxLength(30)
                .HasColumnName("data");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idfuncionario).HasColumnName("idfuncionario");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("venda_idcliente_fkey");

            entity.HasOne(d => d.IdfuncionarioNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.Idfuncionario)
                .HasConstraintName("venda_idfuncionario_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}

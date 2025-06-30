using APIVendas.BaseDados.Models;
using APIVendas.Services.DTOs;
using AutoMapper;

namespace APIVendas.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<CriarCategoriaDTO, Categoria>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();

            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<CriarProdutoDTO, Produto>().ReverseMap();

            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<CriarPessoaDTO, Pessoa>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<CriarClienteDTO, Cliente>().ReverseMap();

            CreateMap<Funcionarios, FuncionarioDTO>().ReverseMap();
            CreateMap<CriarFuncionarioDTO, Funcionarios>().ReverseMap();
        }
    }
}

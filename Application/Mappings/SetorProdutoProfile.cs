using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.SetoresDeProdutos.Adicionar;
using Application.DTOs.Produtos.SetoresDeProdutos.Atualizar;
using Application.DTOs.Produtos.SetoresDeProdutos.Excluir;
using Domain.Commands.Produtos.SetoresProdutos.Adicionar;
using Domain.Commands.Produtos.SetoresProdutos.Atualizar;
using Domain.Commands.Produtos.SetoresProdutos.Excluir;
using Application.DTOs.Produtos.SetoresDeProdutos;

namespace Application.Mappings
{
    internal class SetorProdutoProfileProfile : Profile
    {
        public SetorProdutoProfileProfile()
        {
            CreateMap<AdicionarSetorProdutoCommand, AdicionarSetorProdutoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarSetorProdutoDto, AdicionarSetorProdutoCommand>();
            CreateMap<SetorProdutoDto, AdicionarSetorProdutoCommand>();                

            CreateMap<AtualizarSetorProdutoCommand, AtualizarSetorProdutoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarSetorProdutoDto, AtualizarSetorProdutoCommand>();
            CreateMap<SetorProdutoDto, AtualizarSetorProdutoCommand>();             

            CreateMap<FilterBulkBase, ExcluirSetorProdutoCommand>();
            CreateMap<ExcluirSetorProdutoCommand, ExcluirSetorProdutoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

using Application.DTOs.Pessoas.Filtro;
using Application.DTOs.Produto.Adicionar;
using Application.DTOs.Produto.Excluir;
using Application.DTOs.Produtos;
using Application.DTOs.Produtos.Adicionar;
using Application.DTOs.Produtos.Atualizar;
using AutoMapper;
using Domain.Commands.Pessoas;
using Domain.Commands.Produtos;
using Domain.Commands.Produtos.Adicionar;
using Domain.Commands.Produtos.Atualizar;
using Domain.Commands.Produtos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<AdicionarProdutoCommand, AdicionarProdutoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src))
                .ReverseMap();

            CreateMap<AdicionarProdutoDto, AdicionarProdutoCommand>();
            CreateMap<ProdutoDto, AdicionarProdutoCommand>();

            CreateMap<PrecosTributacoesDto, PrecosTributacoesCommand>();
            CreateMap<ComposicaoDto, ComposicaoCommand>();
            CreateMap<RelacionaProdutoFornecedorDto, RelacionaProdutoFornecedorCommand>().ReverseMap();
            


            CreateMap<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterCommand>();
            //CreateMap<AdicionarSetorProdutoDto, AdicionarSetorProdutoCommand>();
            //CreateMap<AdicionarTipoProdutoDto, AdicionarTipoProdutoCommand>();


            CreateMap<AtualizarProdutoCommand, AtualizarProdutoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarProdutoDto, AtualizarProdutoCommand>();
            CreateMap<ProdutoDto, AtualizarProdutoCommand>();

            CreateMap<FilterBulkBase, ExcluirProdutoCommand>();
            CreateMap<ExcluirProdutoCommand, ExcluirProdutoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

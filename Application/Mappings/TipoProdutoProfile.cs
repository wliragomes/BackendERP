using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.TiposProdutos.Adicionar;
using Application.DTOs.Produtos.TiposProdutos.Atualizar;
using Application.DTOs.Produtos.TiposProdutos.Excluir;
using Domain.Commands.Produtos.TiposProdutos.Adicionar;
using Domain.Commands.Produtos.TiposProdutos.Atualizar;
using Domain.Commands.Produtos.TiposProdutos.Excluir;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class TipoProdutoProfile : Profile
    {
        public TipoProdutoProfile()
        {
            CreateMap<AdicionarTipoProdutoCommand, AdicionarTipoProdutoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarTipoProdutoDto, AdicionarTipoProdutoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarTipoProdutoCommand>();


            CreateMap<AtualizarTipoProdutoCommand, AtualizarTipoProdutoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarTipoProdutoDto, AtualizarTipoProdutoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarTipoProdutoCommand>();

            CreateMap<FilterBulkBase, ExcluirTipoProdutoCommand>();
            CreateMap<ExcluirTipoProdutoCommand, ExcluirTipoProdutoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

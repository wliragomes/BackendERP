using Application.DTOs.Produtos.CodigosImportacoes.Adicionar;
using Application.DTOs.Produtos.CodigosImportacoes.Atualizar;
using Application.DTOs.Produtos.CodigosImportacoes.Excluir;
using AutoMapper;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.CodigosImportacoes.Adicionar;
using Domain.Commands.Produtos.CodigosImportacoes.Atualizar;
using Domain.Commands.Produtos.CodigosImportacoes.Excluir;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class CodigoImportacaoProfile : Profile
    {
        public CodigoImportacaoProfile()
        {
            CreateMap<AdicionarCodigoImportacaoCommand, AdicionarCodigoImportacaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCodigoImportacaoDto, AdicionarCodigoImportacaoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarCodigoImportacaoCommand>();


            CreateMap<AtualizarCodigoImportacaoCommand, AtualizarCodigoImportacaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCodigoImportacaoDto, AtualizarCodigoImportacaoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarCodigoImportacaoCommand>();

            CreateMap<FilterBulkBase, ExcluirCodigoImportacaoCommand>();
            CreateMap<ExcluirCodigoImportacaoCommand, ExcluirCodigoImportacaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
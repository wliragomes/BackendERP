using Application.DTOs.Faturas;
using Application.DTOs.Faturas.Adicionar;
using Application.DTOs.Faturas.Aturalizar;
using Application.DTOs.Faturas.Excluir;
using AutoMapper;
using Domain.Commands.Faturas;
using Domain.Commands.Faturas.Adicionar;
using Domain.Commands.Faturas.Atualizar;
using Domain.Commands.Faturas.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class FaturaProfile : Profile
    {
        public FaturaProfile()
        {

            CreateMap<AdicionarFaturaCommand, AdicionarFaturaRequestDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarFaturaDto, AdicionarFaturaCommand>();
            CreateMap<FaturaDto, AdicionarFaturaCommand>();

            CreateMap<FaturaProdutosDto, FaturaProdutosCommand>();
            CreateMap<FaturaTotaisDto, FaturaTotaisCommand>();
            CreateMap<FaturaPagamentoDto, FaturaPagamentoCommand>();
            CreateMap<FaturaPagamentoParcelasDto, FaturaPagamentoParcelasCommand>();
            CreateMap<FaturaTransporteDto, FaturaTransporteCommand>();

            CreateMap<AtualizarFaturaCommand, AtualizarFaturaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarFaturaDto, AtualizarFaturaCommand>();
            CreateMap<FaturaDto, AtualizarFaturaCommand>();

            CreateMap<FilterBulkBase, ExcluirFaturaCommand>();
            CreateMap<ExcluirFaturaCommand, ExcluirFaturaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();            
        }
    }
}
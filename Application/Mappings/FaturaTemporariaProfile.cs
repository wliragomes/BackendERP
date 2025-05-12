using Application.DTOs.FaturaTemporarias;
using Application.DTOs.FaturaTemporarias.Adicionar;
using Application.DTOs.FaturaTemporarias.Excluir;
using AutoMapper;
using Domain.Commands.FaturaTemporarias.Adicionar;
using Domain.Commands.FaturaTemporarias.Excluir;
using Domain.Commands.OrdensFabricacoes;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class FaturaTemporariaProfile : Profile
    {
        public FaturaTemporariaProfile()
        {
            CreateMap<AdicionarFaturaTemporariaCommand, AdicionarFaturaTemporariaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarFaturaTemporariaDto, AdicionarFaturaTemporariaCommand>();
            CreateMap<FaturaTemporariaDto, AdicionarFaturaTemporariaCommand>();

            CreateMap<FaturaTemporariaItemDto, FaturaTemporariaItemCommand>();

            CreateMap<FilterBulkBase, ExcluirFaturaTemporariaCommand>();
            CreateMap<ExcluirFaturaTemporariaCommand, ExcluirFaturaTemporariaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
using Application.DTOs.FaturaParametros;
using Application.DTOs.FaturaParametros.Adicionar;
using Application.DTOs.FaturaParametros.Atualizar;
using Application.DTOs.FaturaParametros.Excluir;
using AutoMapper;
using Domain.Commands.FaturaParametros.Adicionar;
using Domain.Commands.FaturaParametros.Atualizar;
using Domain.Commands.FaturaParametros.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class FaturaParametroProfile : Profile
    {
        public FaturaParametroProfile()
        {
            CreateMap<AdicionarFaturaParametroCommand, AdicionarFaturaParametroRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarFaturaParametroDto, AdicionarFaturaParametroCommand>();
            CreateMap<FaturaParametroDto, AdicionarFaturaParametroCommand>();


            CreateMap<AtualizarFaturaParametroCommand, AtualizarFaturaParametroRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarFaturaParametroDto, AtualizarFaturaParametroCommand>();
            CreateMap<FaturaParametroDto, AtualizarFaturaParametroCommand>();

            CreateMap<FilterBulkBase, ExcluirFaturaParametroCommand>();
            CreateMap<ExcluirFaturaParametroCommand, ExcluirFaturaParametroDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
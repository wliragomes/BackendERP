using Application.DTOs.Funcionalidades;
using Application.DTOs.NormasAbnts.Adicionar;
using Application.DTOs.NormasAbnts.Atualizar;
using Application.DTOs.NormasAbnts.Excluir;
using AutoMapper;
using Domain.Commands.NormasAbnts.Atualizar;
using Domain.Commands.NormasAbnts.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class NormaAbntProfile : Profile
    {
        public NormaAbntProfile()
        {
            CreateMap<AdicionarNormaAbntCommand, AdicionarNormaAbntRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarNormaAbntDto, AdicionarNormaAbntCommand>();
            CreateMap<NormaAbntDto, AdicionarNormaAbntCommand>();

            CreateMap<AtualizarNormaAbntCommand, AtualizarNormaAbntRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarNormaAbntDto, AtualizarNormaAbntCommand>();
            CreateMap<NormaAbntDto, AtualizarNormaAbntCommand>();

            CreateMap<FilterBulkBase, ExcluirNormaAbntCommand>();
            CreateMap<ExcluirNormaAbntCommand, ExcluirNormaAbntDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
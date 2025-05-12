using Application.DTOs.Estados.Adicionar;
using Application.DTOs.Estados.Atualizar;
using Application.DTOs.Estados.Excluir;
using Application.DTOs.Estados;
using AutoMapper;
using Domain.Commands.Estados.Adicionar;
using Domain.Commands.Estados.Atualizar;
using Domain.Commands.Estados.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class EstadoProfile : Profile
    {
        public EstadoProfile()
        {
            CreateMap<AdicionarEstadoCommand, AdicionarEstadoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarEstadoDto, AdicionarEstadoCommand>();
            CreateMap<EstadoDto, AdicionarEstadoCommand>();


            CreateMap<AtualizarEstadoCommand, AtualizarEstadoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarEstadoDto, AtualizarEstadoCommand>();
            CreateMap<EstadoDto, AtualizarEstadoCommand>();

            CreateMap<FilterBulkBase, ExcluirEstadoCommand>();
            CreateMap<ExcluirEstadoCommand, ExcluirEstadoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
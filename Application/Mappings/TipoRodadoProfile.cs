using Application.DTOs.TiposRodados;
using Application.DTOs.TiposRodados.Adicionar;
using Application.DTOs.TiposRodados.Atualizar;
using Application.DTOs.TiposRodados.Excluir;
using AutoMapper;
using Domain.Commands.TiposRodados.Adicionar;
using Domain.Commands.TiposRodados.Atualizar;
using Domain.Commands.TiposRodados.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class TipoRodadoProfile : Profile
    {
        public TipoRodadoProfile()
        {
            CreateMap<AdicionarTipoRodadoCommand, AdicionarTipoRodadoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarTipoRodadoDto, AdicionarTipoRodadoCommand>();
            CreateMap<TipoRodadoDto, AdicionarTipoRodadoCommand>();


            CreateMap<AtualizarTipoRodadoCommand, AtualizarTipoRodadoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarTipoRodadoDto, AtualizarTipoRodadoCommand>();
            CreateMap<TipoRodadoDto, AtualizarTipoRodadoCommand>();

            CreateMap<FilterBulkBase, ExcluirTipoRodadoCommand>();
            CreateMap<ExcluirTipoRodadoCommand, ExcluirTipoRodadoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
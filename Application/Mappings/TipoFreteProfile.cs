using Application.DTOs.TiposFretes;
using Application.DTOs.TiposFretes.Adicionar;
using Application.DTOs.TiposFretes.Atualizar;
using Application.DTOs.TiposFretes.Excluir;
using AutoMapper;
using Domain.Commands.TipoFretes.Adicionar;
using Domain.Commands.TipoFretes.Atualizar;
using Domain.Commands.TipoFretes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class TipoFreteProfile : Profile
    {
        public TipoFreteProfile()
        {
            CreateMap<AdicionarTipoFreteCommand, AdicionarTipoFreteRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarTipoFreteDto, AdicionarTipoFreteCommand>();
            CreateMap<TipoFreteDto, AdicionarTipoFreteCommand>();


            CreateMap<AtualizarTipoFreteCommand, AtualizarTipoFreteRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarTipoFreteDto, AtualizarTipoFreteCommand>();
            CreateMap<TipoFreteDto, AtualizarTipoFreteCommand>();

            CreateMap<FilterBulkBase, ExcluirTipoFreteCommand>();
            CreateMap<ExcluirTipoFreteCommand, ExcluirTipoFreteDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
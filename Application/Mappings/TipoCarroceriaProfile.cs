using Application.DTOs.TiposCarrocerias;
using Application.DTOs.TiposCarrocerias.Adicionar;
using Application.DTOs.TiposCarrocerias.Atualizar;
using Application.DTOs.TiposCarrocerias.Excluir;
using AutoMapper;
using Domain.Commands.TiposCarrocerias.Adicionar;
using Domain.Commands.TiposCarrocerias.Atualizar;
using Domain.Commands.TiposCarrocerias.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class TipoCarroceriaProfile : Profile
    {
        public TipoCarroceriaProfile()
        {
            CreateMap<AdicionarTipoCarroceriaCommand, AdicionarTipoCarroceriaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarTipoCarroceriaDto, AdicionarTipoCarroceriaCommand>();
            CreateMap<TipoCarroceriaDto, AdicionarTipoCarroceriaCommand>();


            CreateMap<AtualizarTipoCarroceriaCommand, AtualizarTipoCarroceriaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarTipoCarroceriaDto, AtualizarTipoCarroceriaCommand>();
            CreateMap<TipoCarroceriaDto, AtualizarTipoCarroceriaCommand>();

            CreateMap<FilterBulkBase, ExcluirTipoCarroceriaCommand>();
            CreateMap<ExcluirTipoCarroceriaCommand, ExcluirTipoCarroceriaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
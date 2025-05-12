using Application.DTOs.Pessoas.TipoConsumidores;
using Application.DTOs.Pessoas.TipoConsumidores.Atualizar;
using AutoMapper;
using Domain.Commands.Pessoas.TipoConsumidores.Atualizar;

namespace Application.Mappings
{
    internal class TipoConsumidorProfile : Profile
    {
        public TipoConsumidorProfile()
        {
            CreateMap<AtualizarTipoConsumidorCommand, AtualizarTipoConsumidorRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarTipoConsumidorDto, AtualizarTipoConsumidorCommand>();
            CreateMap<TipoConsumidorDto, AtualizarTipoConsumidorCommand>();
        }
    }
}

using Application.DTOs.PlanejamentoProducaos.Atualizar;
using AutoMapper;
using Application.DTOs.PlanejamentoProducoes;
using Domain.Commands.PlanejamentoProducaos.Atualizar;

namespace Application.Mappings
{
    internal class PlanejamentoProducaoProfile : Profile
    {
        public PlanejamentoProducaoProfile()
        {
            CreateMap<AtualizarPlanejamentoProducaoCommand, AtualizarPlanejamentoProducaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarPlanejamentoProducaoDto, AtualizarPlanejamentoProducaoCommand>();
            CreateMap<PlanejamentoProducaoDto, AtualizarPlanejamentoProducaoCommand>();           
        }
    }
}
using Application.DTOs.Pessoas;
using Application.DTOs.Pessoas.Origens.Adicionar;
using Application.DTOs.Pessoas.Origens.Atualizar;
using Application.DTOs.Pessoas.Origens.Excluir;
using AutoMapper;
using Domain.Commands.Origens.Adicionar;
using Domain.Commands.Origens.Atualizar;
using Domain.Commands.Origens.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class OrigemProfile : Profile
    {
        public OrigemProfile()
        {
            CreateMap<AdicionarOrigemCommand, AdicionarOrigemRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarOrigemDto, AdicionarOrigemCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarOrigemCommand>();


            CreateMap<AtualizarOrigemCommand, AtualizarOrigemRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarOrigemDto, AtualizarOrigemCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarOrigemCommand>();

            CreateMap<FilterBulkBase, ExcluirOrigemCommand>();
            CreateMap<ExcluirOrigemCommand, ExcluirOrigemDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
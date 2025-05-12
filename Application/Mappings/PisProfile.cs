using Application.DTOs.Impostos.Piss;
using Application.DTOs.Impostos.Piss.Adicionar;
using Application.DTOs.Impostos.Piss.Atualizar;
using Application.DTOs.Impostos.Piss.Excluir;
using AutoMapper;
using Domain.Commands.Impostos.Piss.Adicionar;
using Domain.Commands.Impostos.Piss.Atualizar;
using Domain.Commands.Impostos.Piss.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class PisProfile : Profile
    {
        public PisProfile()
        {
            CreateMap<AdicionarPisCommand, AdicionarPisRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarPisDto, AdicionarPisCommand>();
            CreateMap<PisDto, AdicionarPisCommand>();


            CreateMap<AtualizarPisCommand, AtualizarPisRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarPisDto, AtualizarPisCommand>();
            CreateMap<PisDto, AtualizarPisCommand>();

            CreateMap<FilterBulkBase, ExcluirPisCommand>();
            CreateMap<ExcluirPisCommand, ExcluirPisDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

using Application.DTOs.Moedas;
using Application.DTOs.Moedas.Adicionar;
using Application.DTOs.Moedas.Atualizar;
using Application.DTOs.Moedas.Excluir;
using AutoMapper;
using Domain.Commands.Moedas.Adicionar;
using Domain.Commands.Moedas.Atualizar;
using Domain.Commands.Moedas.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class MoedaProfile : Profile
    {
        public MoedaProfile()
        {
            CreateMap<AdicionarMoedaCommand, AdicionarMoedaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarMoedaDto, AdicionarMoedaCommand>();
            CreateMap<MoedaDto, AdicionarMoedaCommand>();


            CreateMap<AtualizarMoedaCommand, AtualizarMoedaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarMoedaDto, AtualizarMoedaCommand>();
            CreateMap<MoedaDto, AtualizarMoedaCommand>();

            CreateMap<FilterBulkBase, ExcluirMoedaCommand>();
            CreateMap<ExcluirMoedaCommand, ExcluirMoedaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
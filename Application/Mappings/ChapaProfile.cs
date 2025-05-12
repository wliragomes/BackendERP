using Application.DTOs.Chapas;
using Application.DTOs.Chapas.Adicionar;
using Application.DTOs.Chapas.Atualizar;
using Application.DTOs.Chapas.Excluir;
using AutoMapper;
using Domain.Commands.Chapas.Adicionar;
using Domain.Commands.Chapas.Atualizar;
using Domain.Commands.Chapas.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ChapaProfile : Profile
    {
        public ChapaProfile()
        {
            CreateMap<AdicionarChapaCommand, AdicionarChapaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarChapaDto, AdicionarChapaCommand>();
            CreateMap<ChapaDto, AdicionarChapaCommand>();


            CreateMap<AtualizarChapaCommand, AtualizarChapaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarChapaDto, AtualizarChapaCommand>();
            CreateMap<ChapaDto, AtualizarChapaCommand>();

            CreateMap<FilterBulkBase, ExcluirChapaCommand>();
            CreateMap<ExcluirChapaCommand, ExcluirChapaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
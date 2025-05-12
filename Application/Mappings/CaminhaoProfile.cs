using Application.DTOs.Caminhoes;
using Application.DTOs.Caminhoes.Adicionar;
using Application.DTOs.Caminhoes.Atualizar;
using Application.DTOs.Caminhoes.Excluir;
using AutoMapper;
using Domain.Commands.Caminhoes.Adicionar;
using Domain.Commands.Caminhoes.Atualizar;
using Domain.Commands.Caminhoes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CaminhaoProfile : Profile
    {
        public CaminhaoProfile()
        {
            CreateMap<AdicionarCaminhaoCommand, AdicionarCaminhaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCaminhaoDto, AdicionarCaminhaoCommand>();
            CreateMap<CaminhaoDto, AdicionarCaminhaoCommand>();


            CreateMap<AtualizarCaminhaoCommand, AtualizarCaminhaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCaminhaoDto, AtualizarCaminhaoCommand>();
            CreateMap<CaminhaoDto, AtualizarCaminhaoCommand>();

            CreateMap<FilterBulkBase, ExcluirCaminhaoCommand>();
            CreateMap<ExcluirCaminhaoCommand, ExcluirCaminhaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
using Application.DTOs.Cfops.Adicionar;
using Application.DTOs.Cfops.Atualizar;
using Application.DTOs.Cfops.Excluir;
using Application.DTOs.Faturas;
using AutoMapper;
using Domain.Commands.Cfops.Adicionar;
using Domain.Commands.Cfops.Atualizar;
using Domain.Commands.Cfops.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CfopProfile : Profile
    {
        public CfopProfile()
        {
            CreateMap<AdicionarCfopCommand, AdicionarCfopRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCfopDto, AdicionarCfopCommand>();
            CreateMap<CfopDto, AdicionarCfopCommand>();


            CreateMap<AtualizarCfopCommand, AtualizarCfopRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCfopDto, AtualizarCfopCommand>();
            CreateMap<CfopDto, AtualizarCfopCommand>();

            CreateMap<FilterBulkBase, ExcluirCfopCommand>();
            CreateMap<ExcluirCfopCommand, ExcluirCfopDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
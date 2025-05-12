using Application.DTOs.Impostos.CstIpis;
using Application.DTOs.Impostos.CstIpis.Adicionar;
using Application.DTOs.Impostos.CstIpis.Atualizar;
using Application.DTOs.Impostos.CstIpis.Excluir;
using AutoMapper;
using Domain.Commands.Impostos.CstIpis.Adicionar;
using Domain.Commands.Impostos.CstIpis.Atualizar;
using Domain.Commands.Impostos.CstIpis.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CstIpiProfile : Profile
    {
        public CstIpiProfile()
        {
            CreateMap<AdicionarCstIpiCommand, AdicionarCstIpiRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCstIpiDto, AdicionarCstIpiCommand>();
            CreateMap<CstIpiDto, AdicionarCstIpiCommand>();


            CreateMap<AtualizarCstIpiCommand, AtualizarCstIpiRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCstIpiDto, AtualizarCstIpiCommand>();
            CreateMap<CstIpiDto, AtualizarCstIpiCommand>();

            CreateMap<FilterBulkBase, ExcluirCstIpiCommand>();
            CreateMap<ExcluirCstIpiCommand, ExcluirCstIpiDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
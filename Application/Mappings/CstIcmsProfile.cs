using Application.DTOs.Impostos.CstIcmss;
using Application.DTOs.Impostos.CstIcmss.Adicionar;
using Application.DTOs.Impostos.CstIcmss.Atualizar;
using Application.DTOs.Impostos.CstIcmss.Excluir;
using AutoMapper;
using Domain.Commands.Impostos.CstIcmss.Adicionar;
using Domain.Commands.Impostos.CstIcmss.Atualizar;
using Domain.Commands.Impostos.CstIcmss.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CstIcmsProfile : Profile
    {
        public CstIcmsProfile()
        {
            CreateMap<AdicionarCstIcmsCommand, AdicionarCstIcmsRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCstIcmsDto, AdicionarCstIcmsCommand>();
            CreateMap<CstIcmsDto, AdicionarCstIcmsCommand>();


            CreateMap<AtualizarCST_ICMSCommand, AtualizarCstIcmsRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCstIcmsDto, AtualizarCST_ICMSCommand>();
            CreateMap<CstIcmsDto, AtualizarCST_ICMSCommand>();

            CreateMap<FilterBulkBase, ExcluirCstIcmsCommand>();
            CreateMap<ExcluirCstIcmsCommand, ExcluirCST_ICMSDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

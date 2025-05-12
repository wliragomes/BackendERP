using Application.DTOs.Impostos.CstIcmsOrigemMateriais;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Adicionar;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Atualizar;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Excluir;
using Application.DTOs.Impostos.Piss.Atualizar;
using AutoMapper;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Adicionar;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Atualizar;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CstIcmsOrigemMateriaiaProfile : Profile
    {
        public CstIcmsOrigemMateriaiaProfile()
        {
            CreateMap<AdicionarIcstIcmsOrigemMaterialCommand, AdicionarCstIcmsOrigemMaterialRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCstIcmsOrigemMaterialDto, AdicionarIcstIcmsOrigemMaterialCommand>();
            CreateMap<CstIcmsOrigemMaterialDto, AdicionarIcstIcmsOrigemMaterialCommand>();


            CreateMap<AtualizarIcstIcmsOrigemMaterialCommand, AtualizarCstIcmsOrigemMaterialRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCstIcmsOrigemMaterialDto, AtualizarIcstIcmsOrigemMaterialCommand>();
            CreateMap<CstIcmsOrigemMaterialDto, AtualizarIcstIcmsOrigemMaterialCommand>();

            CreateMap<FilterBulkBase, ExcluirIcstIcmsOrigemMaterialCommand>();
            CreateMap<ExcluirIcstIcmsOrigemMaterialCommand, ExcluirCstIcmsOrigemMaterialDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
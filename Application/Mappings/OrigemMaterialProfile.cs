using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.OrigemMateriais.Adicionar;
using Application.DTOs.Produtos.OrigemMateriais.Atualizar;
using Application.DTOs.Produtos.OrigemMateriais.Excluir;
using Domain.Commands.Produtos.OrigemMateriais.Excluir;
using Domain.Commands.Produtos.Grupos.Atualizar;
using Domain.Commands.Produtos.OrigemMateriais.Adicionar;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class OrigemMaterialProfile : Profile
    {
        public OrigemMaterialProfile()
        {
            CreateMap<AdicionarOrigemMaterialCommand, AdicionarOrigemMaterialRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarOrigemMaterialDto, AdicionarOrigemMaterialCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarOrigemMaterialCommand>();


            CreateMap<AtualizarOrigemMaterialCommand, AtualizarOrigemMaterialRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarOrigemMaterialDto, AtualizarOrigemMaterialCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarOrigemMaterialCommand>();

            CreateMap<FilterBulkBase, ExcluirOrigemMaterialCommand>();
            CreateMap<ExcluirOrigemMaterialCommand, ExcluirOrigemMaterialDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

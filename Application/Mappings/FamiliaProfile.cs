using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.Familias.Adicionar;
using Application.DTOs.Produtos.Familias.Atualizar;
using Application.DTOs.Produtos.Familias.Excluir;
using Domain.Commands.Produtos.Familias.Adicionar;
using Domain.Commands.Produtos.Familias.Atualizar;
using Domain.Commands.Produtos.Familias.Excluir;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class FamiliaProfile : Profile
    {
        public FamiliaProfile()
        {
            CreateMap<AdicionarFamiliaCommand, AdicionarFamiliaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarFamiliaDto, AdicionarFamiliaCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarFamiliaCommand>();


            CreateMap<AtualizarFamiliaCommand, AtualizarFamiliaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarFamiliaDto, AtualizarFamiliaCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarFamiliaCommand>();

            CreateMap<FilterBulkBase, ExcluirFamiliaCommand>();
            CreateMap<ExcluirFamiliaCommand, ExcluirFamiliaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

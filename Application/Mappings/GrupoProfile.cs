using Application.DTOs.Produtos.Grupos.Adicionar;
using Application.DTOs.Produtos.Grupos.Atualizar;
using Application.DTOs.Produtos.Grupos.Excluir;
using AutoMapper;
using Domain.Commands.Produtos.Grupos.Adicionar;
using Domain.Commands.Produtos.Grupos.Atualizar;
using Domain.Commands.Produtos.Grupos.Excluir;
using SharedKernel.SharedObjects;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class GrupoProfile : Profile
    {
        public GrupoProfile()
        {
            CreateMap<AdicionarGrupoCommand, AdicionarGrupoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarGrupoDto, AdicionarGrupoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarGrupoCommand>();


            CreateMap<AtualizarGrupoCommand, AtualizarGrupoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarGrupoDto, AtualizarGrupoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarGrupoCommand>();

            CreateMap<FilterBulkBase, ExcluirGrupoCommand>();
            CreateMap<ExcluirGrupoCommand, ExcluirGrupoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

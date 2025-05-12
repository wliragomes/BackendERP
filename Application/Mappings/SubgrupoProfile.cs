using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.Subgrupos.Adicionar;
using Application.DTOs.Produtos.Subgrupos.Atualizar;
using Application.DTOs.Produtos.Subgrupos.Excluir;
using Domain.Commands.Produtos.Subgrupos.Adicionar;
using Domain.Commands.Produtos.Subgrupos.Atualizar;
using Domain.Commands.Produtos.Subgrupos.Excluir;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class SubgrupoProfile : Profile
    {
        public SubgrupoProfile()
        {
            CreateMap<AdicionarSubgrupoCommand, AdicionarSubgrupoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarSubgrupoDto, AdicionarSubgrupoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarSubgrupoCommand>();


            CreateMap<AtualizarSubgrupoCommand, AtualizarSubgrupoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarSubgrupoDto, AtualizarSubgrupoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarSubgrupoCommand>();

            CreateMap<FilterBulkBase, ExcluirSubgrupoCommand>();
            CreateMap<ExcluirSubgrupoCommand, ExcluirSubgrupoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

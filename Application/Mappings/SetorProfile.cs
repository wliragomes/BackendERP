using Application.DTOs.Produtos.Setores.Adicionar;
using Application.DTOs.Produtos.Setores.Atualizar;
using Application.DTOs.Produtos.Setores.Excluir;
using AutoMapper;
using Domain.Commands.Produtos.Setores.Adicionar;
using Domain.Commands.Produtos.Setores.Atualizar;
using Domain.Commands.Produtos.Setores.Excluir;
using SharedKernel.SharedObjects;
using Application.DTOs.Pessoas;
using Application.DTOs.Produtos.CodigosImportacoes.Adicionar;

namespace Application.Mappings
{
    internal class SetorProfile : Profile
    {
        public SetorProfile()
        {
            CreateMap<AdicionarSetorCommand, AdicionarSetorRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarSetorDto, AdicionarSetorCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarSetorCommand>();


            CreateMap<AtualizarSetorCommand, AtualizarSetorRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarSetorDto, AtualizarSetorCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarSetorCommand>();

            CreateMap<FilterBulkBase, ExcluirSetorCommand>();
            CreateMap<ExcluirSetorCommand, ExcluirSetorDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
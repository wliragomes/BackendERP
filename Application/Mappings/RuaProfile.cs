using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.Ruas.Adicionar;
using Application.DTOs.Produtos.Ruas.Atualizar;
using Application.DTOs.Produtos.Ruas.Excluir;
using Domain.Commands.Produtos.Ruas.Adicionar;
using Domain.Commands.Produtos.Ruas.Atualizar;
using Domain.Commands.Produtos.Ruas.Excluir;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class RuaProfile : Profile
    {
        public RuaProfile()
        {
            CreateMap<AdicionarRuaCommand, AdicionarRuaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarRuaDto, AdicionarRuaCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarRuaCommand>();


            CreateMap<AtualizarRuaCommand, AtualizarRuaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarRuaDto, AtualizarRuaCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarRuaCommand>();

            CreateMap<FilterBulkBase, ExcluirRuaCommand>();
            CreateMap<ExcluirRuaCommand, ExcluirRuaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
using Application.DTOs.MovimentosEstoque.Adicionar;
using Application.DTOs.MovimentosEstoque.Atualizar;
using Application.DTOs.MovimentosEstoque.Excluir;
using Application.DTOs.Pessoas;
using AutoMapper;
using Domain.Commands.MovimentosEstoque.Adicionar;
using Domain.Commands.MovimentosEstoque.Atualizar;
using Domain.Commands.MovimentosEstoque.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class MovimentoEstoqueProfile : Profile
    {
        public MovimentoEstoqueProfile()
        {
            CreateMap<AdicionarMovimentoEstoqueCommand, AdicionarMovimentoEstoqueRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarMovimentoEstoqueDto, AdicionarMovimentoEstoqueCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarMovimentoEstoqueCommand>();


            CreateMap<AtualizarMovimentoEstoqueCommand, AtualizarMovimentoEstoqueRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarMovimentoEstoqueDto, AtualizarMovimentoEstoqueCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarMovimentoEstoqueCommand>();

            CreateMap<FilterBulkBase, ExcluirMovimentoEstoqueCommand>();
            CreateMap<ExcluirMovimentoEstoqueCommand, ExcluirMovimentoEstoqueDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
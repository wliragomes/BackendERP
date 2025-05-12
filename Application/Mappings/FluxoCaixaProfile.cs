using Application.DTOs.FluxoCaixas;
using Application.DTOs.FluxoCaixas.Adicionar;
using Application.DTOs.FluxoCaixas.Atualizar;
using Application.DTOs.FluxoCaixas.Excluir;
using AutoMapper;
using Domain.Commands.FluxoCaixas.Adicionar;
using Domain.Commands.FluxoCaixas.Atualizar;
using Domain.Commands.FluxoCaixas.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class FluxoCaixaProfile : Profile
    {
        public FluxoCaixaProfile()
        {
            CreateMap<AdicionarFluxoCaixaCommand, AdicionarFluxoCaixaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarFluxoCaixaDto, AdicionarFluxoCaixaCommand>();
            CreateMap<FluxoCaixaDto, AdicionarFluxoCaixaCommand>();


            CreateMap<AtualizarFluxoCaixaCommand, AtualizarFluxoCaixaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarFluxoCaixaDto, AtualizarFluxoCaixaCommand>();
            CreateMap<FluxoCaixaDto, AtualizarFluxoCaixaCommand>();

            CreateMap<FilterBulkBase, ExcluirFluxoCaixaCommand>();
            CreateMap<ExcluirFluxoCaixaCommand, ExcluirFluxoCaixaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
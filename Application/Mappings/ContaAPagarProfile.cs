using AutoMapper;
using SharedKernel.SharedObjects;
using Domain.Commands.ContasAPagar.Adicionar;
using Application.DTOs.ContasAPagar.Adicionar;
using Application.DTOs.ContasAPagar;
using Application.DTOs.ContasAPagar.Atualizar;
using Domain.Commands.ContasAPagar.Atualizar;
using Domain.Commands.ContasAPagar.Excluir;
using Application.DTOs.ContasAPagar.Excluir;
using Domain.Commands.ContasAPagar;

public class ContaAPagarProfile : Profile
{
    public ContaAPagarProfile()
    {
        CreateMap<AdicionarContaAPagarCommand, AdicionarContaAPagarRequestDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
        CreateMap<AdicionarContaAPagarDto, AdicionarContaAPagarCommand>();
        CreateMap<ContaAPagarDto, AdicionarContaAPagarCommand>();

        CreateMap<PagarCentroCustoDespesaDto, PagarCentroCustoDespesaCommand>();
        CreateMap<ContaPagarLoteDto, ContaPagarLoteCommand>();

        CreateMap<AtualizarContaAPagarCommand, AtualizarContaAPagarRequestDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
        CreateMap<AtualizarContaAPagarDto, AtualizarContaAPagarCommand>();
        CreateMap<ContaAPagarDto, AtualizarContaAPagarCommand>();

        CreateMap<FilterBulkBase, ExcluirContaAPagarCommand>();
        CreateMap<ExcluirContaAPagarCommand, ExcluirContaAPagarDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
    }
}
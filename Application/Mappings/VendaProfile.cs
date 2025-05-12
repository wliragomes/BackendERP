using Application.DTOs.Venda.Adicionar;
using Application.DTOs.Venda.Atualizar;
using Application.DTOs.Venda.Excluir;
using Application.DTOs.Vendas.Adicionar;
using Application.DTOs.Vendas;
using AutoMapper;
using Domain.Commands.Vendas.Adicionar;
using Domain.Commands.Vendas.Atualizar;
using Domain.Commands.Vendas.Excluir;
using SharedKernel.SharedObjects;
using Domain.Commands.Vendas;
using Application.DTOs.Faturas;
using Domain.Commands.Faturas;

public class VendaProfile : Profile
{
    public VendaProfile()
    {        
        CreateMap<AdicionarVendaCommand, AdicionarVendaRequestDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
        CreateMap<AdicionarVendaDto, AdicionarVendaCommand>();
        CreateMap<VendaDto, AdicionarVendaCommand>();

        CreateMap<VendaOrdemDto, VendaOrdemCommand>();
        CreateMap<EnderecoVendaOrdemDto, EnderecoVendaOrdemCommand>();

        CreateMap<VendaTransporteDto, VendaTransporteCommand>();

        CreateMap<VendaRecebimentoTipoDto, VendaRecebimentoTipoCommand>();
        CreateMap<VendaRecebimentoParcelaDto, VendaRecebimentoParcelaCommand>().ReverseMap();

        CreateMap<FaturaProdutosDto, FaturaProdutosCommand>();
        CreateMap<VendaRecebimentoParcelaDto, VendaRecebimentoParcelaCommand>().ReverseMap();

        CreateMap<AtualizarVendaCommand, AtualizarVendaRequestDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
        CreateMap<AtualizarVendaDto, AtualizarVendaCommand>();
        CreateMap<VendaDto, AtualizarVendaCommand>();
        
        CreateMap<FilterBulkBase, ExcluirVendaCommand>();
        CreateMap<ExcluirVendaCommand, ExcluirVendaDto>()
            .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();        
    }
}
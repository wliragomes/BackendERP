using Application.DTOs.ContasAPagarPago;
using Application.DTOs.ContasAPagarPago.Adicionar;
using Application.DTOs.ContasAPagarPago.Atualizar;
using Application.DTOs.ContasAPagarPago.Excluir;
using AutoMapper;
using Domain.Commands.ContasAPagarPago.Adicionar;
using Domain.Commands.ContasAPagarPago.Atualizar;
using Domain.Commands.ContasAPagarPago.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ContaAPagarPagoProfile : Profile
    {
        public ContaAPagarPagoProfile()
        {
            CreateMap<AdicionarContaAPagarPagoCommand, AdicionarContaAPagarPagoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarContaAPagarPagoDto, AdicionarContaAPagarPagoCommand>();
            CreateMap<ContaAPagarPagoDto, AdicionarContaAPagarPagoCommand>();


            CreateMap<AtualizarContaAPagarPagoCommand, AtualizarContaAPagarPagoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarContaAPagarPagoDto, AtualizarContaAPagarPagoCommand>();
            CreateMap<ContaAPagarPagoDto, AtualizarContaAPagarPagoCommand>();

            CreateMap<FilterBulkBase, ExcluirContaAPagarPagoCommand>();
            CreateMap<ExcluirContaAPagarPagoCommand, ExcluirContaAPagarPagoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
using Application.DTOs.Pessoas;
using Application.DTOs.Pessoas.SegmentoClientes.Adicionar;
using Application.DTOs.Pessoas.SegmentoClientes.Atualizar;
using Application.DTOs.Pessoas.SegmentoClientes.Excluir;
using AutoMapper;
using Domain.Commands.SegmentoClientes.Adicionar;
using Domain.Commands.SegmentoClientes.Atualizar;
using Domain.Commands.SegmentoClientes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class SegmentoClienteProfile : Profile
    {
        public SegmentoClienteProfile()
        {
            CreateMap<AdicionarSegmentoClienteCommand, AdicionarSegmentoClienteRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarSegmentoClienteDto, AdicionarSegmentoClienteCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarSegmentoClienteCommand>();


            CreateMap<AtualizarSegmentoClienteCommand, AtualizarSegmentoClienteRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarSegmentoClienteDto, AtualizarSegmentoClienteCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarSegmentoClienteCommand>();

            CreateMap<FilterBulkBase, ExcluirSegmentoClienteCommand>();
            CreateMap<ExcluirSegmentoClienteCommand, ExcluirSegmentoClienteDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
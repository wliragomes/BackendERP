using Application.DTOs.Acabamentos;
using Application.DTOs.Acabamentos.Adicionar;
using Application.DTOs.Acabamentos.Atualizar;
using Application.DTOs.Acabamentos.Excluir;
using Application.DTOs.Acabamentos.Filtro;
using AutoMapper;
using Domain.Commands.Acabamentos.Adicionar;
using Domain.Commands.Acabamentos.Atualizar;
using Domain.Commands.Acabamentos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class AcabamentoProfile : Profile
    {
        public AcabamentoProfile()
        {
            CreateMap<AdicionarAcabamentoCommand, AdicionarAcabamentoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarAcabamentoDto, AdicionarAcabamentoCommand>();
            CreateMap<AcabamentoDto, AdicionarAcabamentoCommand>();


            CreateMap<AtualizarAcabamentoCommand, AtualizarAcabamentoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarAcabamentoDto, AtualizarAcabamentoCommand>();
            CreateMap<AcabamentoDto, AtualizarAcabamentoCommand>();

            CreateMap<FilterBulkBase, ExcluirAcabamentoCommand>();
            CreateMap<ExcluirAcabamentoCommand, ExcluirAcabamentoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
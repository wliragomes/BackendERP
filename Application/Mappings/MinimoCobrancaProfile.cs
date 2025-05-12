using Application.DTOs.MinimoCobrancas;
using Application.DTOs.MinimoCobrancas.Adicionar;
using Application.DTOs.MinimoCobrancas.Atualizar;
using Application.DTOs.MinimoCobrancas.Excluir;
using AutoMapper;
using Domain.Commands.MinimoCobrancas;
using Domain.Commands.MinimoCobrancas.Adicionar;
using Domain.Commands.MinimoCobrancas.Atualizar;
using Domain.Commands.MinimoCobrancas.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class MinimoCobrancaProfile : Profile
    {
        public MinimoCobrancaProfile()
        {
            CreateMap<AdicionarMinimoCobrancaCommand, AdicionarMinimoCobrancaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarMinimoCobrancaDto, AdicionarMinimoCobrancaCommand>();
            CreateMap<MinimoCobrancaDto, AdicionarMinimoCobrancaCommand>();

            CreateMap<MinimoCobrancaItemDto, MinimoCobrancaItemCommand>();


            CreateMap<AtualizarMinimoCobrancaCommand, AtualizarMinimoCobrancaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarMinimoCobrancaDto, AtualizarMinimoCobrancaCommand>();
            CreateMap<MinimoCobrancaDto, AtualizarMinimoCobrancaCommand>();

            CreateMap<FilterBulkBase, ExcluirMinimoCobrancaCommand>();
            CreateMap<ExcluirMinimoCobrancaCommand, ExcluirMinimoCobrancaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
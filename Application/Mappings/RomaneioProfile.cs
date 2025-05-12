using Application.DTOs.Romaneios;
using Application.DTOs.Romaneios.Adicionar;
using Application.DTOs.Romaneios.Atualizar;
using Application.DTOs.Romaneios.Excluir;
using AutoMapper;
using Domain.Commands.OrdensFabricacoes.Adicionar;
using Domain.Commands.Romaneios;
using Domain.Commands.Romaneios.Atualizar;
using Domain.Commands.Romaneios.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class RomaneioProfile : Profile
    {
        public RomaneioProfile()
        {
            CreateMap<AdicionarRomaneioCommand, AdicionarRomaneioRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarRomaneioDto, AdicionarRomaneioCommand>();
            CreateMap<RomaneioDto, AdicionarRomaneioCommand>();

            CreateMap<RomaneioItemDto, RomaneioItemCommand>();

            CreateMap<AtualizarRomaneioCommand, AtualizarRomaneioRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarRomaneioDto, AtualizarRomaneioCommand>();
            CreateMap<RomaneioDto, AtualizarRomaneioCommand>();

            CreateMap<FilterBulkBase, ExcluirRomaneioCommand>();
            CreateMap<ExcluirRomaneioCommand, ExcluirRomaneioDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
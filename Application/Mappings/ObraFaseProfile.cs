using Application.DTOs.ObraFases;
using Application.DTOs.ObraFases.Adicionar;
using Application.DTOs.ObraFases.Atualizar;
using Application.DTOs.ObraFases.Excluir;
using AutoMapper;
using Domain.Commands.ObraFases.Adicionar;
using Domain.Commands.ObraFases.Atualizar;
using Domain.Commands.ObraFases.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ObraFaseProfile : Profile
    {
        public ObraFaseProfile()
        {
            CreateMap<AdicionarObraFaseCommand, AdicionarObraFaseRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarObraFaseDto, AdicionarObraFaseCommand>();
            CreateMap<ObraFaseDto, AdicionarObraFaseCommand>();


            CreateMap<AtualizarObraFaseCommand, AtualizarObraFaseRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarObraFaseDto, AtualizarObraFaseCommand>();
            CreateMap<ObraFaseDto, AtualizarObraFaseCommand>();

            CreateMap<FilterBulkBase, ExcluirObraFaseCommand>();
            CreateMap<ExcluirObraFaseCommand, ExcluirObraFaseDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
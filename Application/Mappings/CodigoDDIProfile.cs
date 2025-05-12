using Application.DTOs.CodigoDDIs;
using Application.DTOs.CodigoDDIs.Adicionar;
using Application.DTOs.CodigoDDIs.Atualizar;
using Application.DTOs.CodigoDDIs.Excluir;
using AutoMapper;
using Domain.Commands.CodigoDDIs.Adicionar;
using Domain.Commands.CodigoDDIs.Atualizar;
using Domain.Commands.CodigoDDIs.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CodigoDDIProfile : Profile
    {
        public CodigoDDIProfile()
        {
            CreateMap<AdicionarCodigoDDICommand, AdicionarCodigoDDIRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCodigoDDIDto, AdicionarCodigoDDICommand>();
            CreateMap<CodigoDDIDto, AdicionarCodigoDDICommand>();


            CreateMap<AtualizarCodigoDDICommand, AtualizarCodigoDDIRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCodigoDDIDto, AtualizarCodigoDDICommand>();
            CreateMap<CodigoDDIDto, AtualizarCodigoDDICommand>();

            CreateMap<FilterBulkBase, ExcluirCodigoDDICommand>();
            CreateMap<ExcluirCodigoDDICommand, ExcluirCodigoDDIDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
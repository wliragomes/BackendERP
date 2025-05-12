using Application.DTOs.ObrasPadrao;
using Application.DTOs.ObrasPadrao.Adicionar;
using Application.DTOs.ObrasPadrao.Atualizar;
using Application.DTOs.ObrasPadrao.Excluir;
using AutoMapper;
using Domain.Commands.ObrasPadrao.Adicionar;
using Domain.Commands.ObrasPadrao.Atualizar;
using Domain.Commands.ObrasPadrao.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ObraPadraoProfile : Profile
    {
        public ObraPadraoProfile()
        {
            CreateMap<AdicionarObraPadraoCommand, AdicionarObraPadraoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarObraPadraoDto, AdicionarObraPadraoCommand>();
            CreateMap<ObraPadraoDto, AdicionarObraPadraoCommand>();


            CreateMap<AtualizarObraPadraoCommand, AtualizarObraPadraoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarObraPadraoDto, AtualizarObraPadraoCommand>();
            CreateMap<ObraPadraoDto, AtualizarObraPadraoCommand>();

            CreateMap<FilterBulkBase, ExcluirObraPadraoCommand>();
            CreateMap<ExcluirObraPadraoCommand, ExcluirObraPadraoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
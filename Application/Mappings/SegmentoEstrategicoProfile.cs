using Application.DTOs.Pessoas;
using Application.DTOs.Pessoas.SegmentoEstrategicos.Adicionar;
using Application.DTOs.Pessoas.SegmentoEstrategicos.Atualizar;
using Application.DTOs.Pessoas.SegmentoEstrategicos.Excluir;
using AutoMapper;
using Domain.Commands.SegmentoEstrategicos.Adicionar;
using Domain.Commands.SegmentoEstrategicos.Atualizar;
using Domain.Commands.SegmentoEstrategicos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class SegmentoEstrategicoProfile : Profile
    {
        public SegmentoEstrategicoProfile()
        {
            CreateMap<AdicionarSegmentoEstrategicoCommand, AdicionarSegmentoEstrategicoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarSegmentoEstrategicoDto, AdicionarSegmentoEstrategicoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarSegmentoEstrategicoCommand>();


            CreateMap<AtualizarSegmentoEstrategicoCommand, AtualizarSegmentoEstrategicoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarSegmentoEstrategicoDto, AtualizarSegmentoEstrategicoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarSegmentoEstrategicoCommand>();

            CreateMap<FilterBulkBase, ExcluirSegmentoEstrategicoCommand>();
            CreateMap<ExcluirSegmentoEstrategicoCommand, ExcluirSegmentoEstrategicoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
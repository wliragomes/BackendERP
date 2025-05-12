using Application.DTOs.Feriados;
using Application.DTOs.Feriados.Adicionar;
using Application.DTOs.Feriados.Atualizar;
using Application.DTOs.Feriados.Excluir;
using AutoMapper;
using Domain.Commands.Feriados.Adicionar;
using Domain.Commands.Feriados.Atualizar;
using Domain.Commands.Feriados.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class FeriadoProfile : Profile
    {
        public FeriadoProfile()
        {
            CreateMap<AdicionarFeriadoCommand, AdicionarFeriadoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarFeriadoDto, AdicionarFeriadoCommand>();
            CreateMap<FeriadoDto, AdicionarFeriadoCommand>();


            CreateMap<AtualizarFeriadoCommand, AtualizarFeriadoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarFeriadoDto, AtualizarFeriadoCommand>();
            CreateMap<FeriadoDto, AtualizarFeriadoCommand>();

            CreateMap<FilterBulkBase, ExcluirFeriadoCommand>();
            CreateMap<ExcluirFeriadoCommand, ExcluirFeriadoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

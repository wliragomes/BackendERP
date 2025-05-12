using Application.DTOs.CepsBloqueados;
using Application.DTOs.CepsBloqueados.Adicionar;
using Application.DTOs.CepsBloqueados.Atualizar;
using Application.DTOs.CepsBloqueados.Excluir;
using AutoMapper;
using Domain.Commands.CepsBloqueados.Adicionar;
using Domain.Commands.CepsBloqueados.Atualizar;
using Domain.Commands.CepsBloqueados.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CepBloqueadoProfile : Profile
    {
        public CepBloqueadoProfile()
        {
            CreateMap<AdicionarCepBloqueadoCommand, AdicionarCepBloqueadoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCepBloqueadoDto, AdicionarCepBloqueadoCommand>();
            CreateMap<CepBloqueadoDto, AdicionarCepBloqueadoCommand>();


            CreateMap<AtualizarCepBloqueadoCommand, AtualizarCepBloqueadoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCepBloqueadoDto, AtualizarCepBloqueadoCommand>();
            CreateMap<CepBloqueadoDto, AtualizarCepBloqueadoCommand>();

            CreateMap<FilterBulkBase, ExcluirCepBloqueadoCommand>();
            CreateMap<ExcluirCepBloqueadoCommand, ExcluirCepBloqueadoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
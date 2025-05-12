using Application.DTOs.Operacoes;
using Application.DTOs.Operacoes.Adicionar;
using Application.DTOs.Operacoes.Atualizar;
using Application.DTOs.Operacoes.Excluir;
using AutoMapper;
using Domain.Commands.Operacoes.Adicionar;
using Domain.Commands.Operacoes.Atualizar;
using Domain.Commands.Operacoes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class OperacaoProfile : Profile
    {
        public OperacaoProfile()
        {
            CreateMap<AdicionarOperacaoCommand, AdicionarOperacaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarOperacaoDto, AdicionarOperacaoCommand>();
            CreateMap<OperacaoDto, AdicionarOperacaoCommand>();


            CreateMap<AtualizarOperacaoCommand, AtualizarOperacaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarOperacaoDto, AtualizarOperacaoCommand>();
            CreateMap<OperacaoDto, AtualizarOperacaoCommand>();

            CreateMap<FilterBulkBase, ExcluirOperacaoCommand>();
            CreateMap<ExcluirOperacaoCommand, ExcluirOperacaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
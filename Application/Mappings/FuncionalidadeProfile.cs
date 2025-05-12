using Application.DTOs.Funcionalidades;
using Application.DTOs.Funcionalidades.Adicionar;
using Application.DTOs.Funcionalidades.Atualizar;
using Application.DTOs.Funcionalidades.Excluir;
using AutoMapper;
using Domain.Commands.Funcionalidades.Adicionar;
using Domain.Commands.Funcionalidades.Atualizar;
using Domain.Commands.Funcionalidades.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class FuncionalidadeProfile : Profile
    {
        public FuncionalidadeProfile()
        {
            CreateMap<AdicionarFuncionalidadeCommand, AdicionarFuncionalidadeRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarFuncionalidadeDto, AdicionarFuncionalidadeCommand>();
            CreateMap<FuncionalidadeDto, AdicionarFuncionalidadeCommand>();

            CreateMap<AtualizarFuncionalidadeCommand, AtualizarFuncionalidadeRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarFuncionalidadeDto, AtualizarFuncionalidadeCommand>();
            CreateMap<FuncionalidadeDto, AtualizarFuncionalidadeCommand>();

            CreateMap<FilterBulkBase, ExcluirFuncionalidadeCommand>();
            CreateMap<ExcluirFuncionalidadeCommand, ExcluirFuncionalidadeDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
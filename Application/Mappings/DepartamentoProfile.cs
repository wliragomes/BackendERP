using Application.DTOs.Pessoas;
using Application.DTOs.Pessoas.Departamentos.Adicionar;
using Application.DTOs.Pessoas.Departamentos.Atualizar;
using Application.DTOs.Pessoas.Departamentos.Excluir;
using AutoMapper;
using Domain.Commands.Departamentos.Adicionar;
using Domain.Commands.Departamentos.Atualizar;
using Domain.Commands.Departamentos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class DepartamentoProfile : Profile
    {
        public DepartamentoProfile()
        {
            CreateMap<AdicionarDepartamentoCommand, AdicionarDepartamentoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarDepartamentoDto, AdicionarDepartamentoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarDepartamentoCommand>();


            CreateMap<AtualizarDepartamentoCommand, AtualizarDepartamentoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarDepartamentoDto, AtualizarDepartamentoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarDepartamentoCommand>();

            CreateMap<FilterBulkBase, ExcluirDepartamentoCommand>();
            CreateMap<ExcluirDepartamentoCommand, ExcluirDepartamentoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
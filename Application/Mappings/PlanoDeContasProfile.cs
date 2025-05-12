using Application.DTOs.PlanosDeContas;
using Application.DTOs.PlanosDeContas.Adicionar;
using Application.DTOs.PlanosDeContas.Atualizar;
using Application.DTOs.PlanosDeContas.Excluir;
using AutoMapper;
using Domain.Commands.PlanosDeContas.Adicionar;
using Domain.Commands.PlanosDeContas.Atualizar;
using Domain.Commands.PlanosDeContas.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class PlanoDeContasProfile : Profile
    {
        public PlanoDeContasProfile()
        {
            CreateMap<AdicionarPlanoDeContasCommand, AdicionarPlanoDeContasRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarPlanoDeContasDto, AdicionarPlanoDeContasCommand>();
            CreateMap<PlanoDeContasDto, AdicionarPlanoDeContasCommand>();


            CreateMap<AtualizarPlanoDeContasCommand, AtualizarPlanoDeContasRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarPlanoDeContasDto, AtualizarPlanoDeContasCommand>();
            CreateMap<PlanoDeContasDto, AtualizarPlanoDeContasCommand>();

            CreateMap<FilterBulkBase, ExcluirPlanoDeContasCommand>();
            CreateMap<ExcluirPlanoDeContasCommand, ExcluirPlanoDeContasDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
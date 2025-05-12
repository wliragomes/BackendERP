using Application.DTOs.ContasAReceber;
using Application.DTOs.ContasAReceber.Adicionar;
using Application.DTOs.ContasAReceber.Atualizar;
using Application.DTOs.ContasAReceber.Excluir;
using AutoMapper;
using Domain.Commands.ContasAReceber.Adicionar;
using Domain.Commands.ContasAReceber.Atualizar;
using Domain.Commands.ContasAReceber.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ContaAReceberProfile : Profile
    {
        public ContaAReceberProfile()
        {
            CreateMap<AdicionarContaAReceberCommand, AdicionarContaAReceberRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarContaAReceberDto, AdicionarContaAReceberCommand>();
            CreateMap<ContaAReceberDto, AdicionarContaAReceberCommand>();


            CreateMap<AtualizarContaAReceberCommand, AtualizarContaAReceberRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarContaAReceberDto, AtualizarContaAReceberCommand>();
            CreateMap<ContaAReceberDto, AtualizarContaAReceberCommand>();

            CreateMap<FilterBulkBase, ExcluirContaAReceberCommand>();
            CreateMap<ExcluirContaAReceberCommand, ExcluirContaAReceberDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
using Application.DTOs.Cidades;
using Application.DTOs.Cidades.Adicionar;
using Application.DTOs.Cidades.Atualizar;
using Application.DTOs.Cidades.Excluir;
using AutoMapper;
using Domain.Commands.Cidades.Adicionar;
using Domain.Commands.Cidades.Atualizar;
using Domain.Commands.Cidades.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<AdicionarCidadeCommand, AdicionarCidadeRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCidadeDto, AdicionarCidadeCommand>();
            CreateMap<CidadeDto, AdicionarCidadeCommand>();


            CreateMap<AtualizarCidadeCommand, AtualizarCidadeRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCidadeDto, AtualizarCidadeCommand>();
            CreateMap<CidadeDto, AtualizarCidadeCommand>();

            CreateMap<FilterBulkBase, ExcluirCidadeCommand>();
            CreateMap<ExcluirCidadeCommand, ExcluirCidadeDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
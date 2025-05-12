using Application.DTOs.Pessoas;
using Application.DTOs.Pessoas.Regioes.Adicionar;
using Application.DTOs.Pessoas.Regioes.Atualizar;
using Application.DTOs.Pessoas.Regioes.Excluir;
using AutoMapper;
using Domain.Commands.Regioes.Adicionar;
using Domain.Commands.Regioes.Atualizar;
using Domain.Commands.Regioes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class RegiaoProfile : Profile
    {
        public RegiaoProfile()
        {
            CreateMap<AdicionarRegiaoCommand, AdicionarRegiaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarRegiaoDto, AdicionarRegiaoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarRegiaoCommand>();


            CreateMap<AtualizarRegiaoCommand, AtualizarRegiaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarRegiaoDto, AtualizarRegiaoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarRegiaoCommand>();

            CreateMap<FilterBulkBase, ExcluirRegiaoCommand>();
            CreateMap<ExcluirRegiaoCommand, ExcluirRegiaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
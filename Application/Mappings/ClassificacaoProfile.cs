using Application.DTOs.Classificacoes;
using Application.DTOs.Classificacoes.Adicionar;
using Application.DTOs.Classificacoes.Atualizar;
using Application.DTOs.Classificacoes.Excluir;
using AutoMapper;
using Domain.Commands.Classificacoes.Adicionar;
using Domain.Commands.Classificacoes.Atualizar;
using Domain.Commands.Classificacoes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ClassificacaoProfile : Profile
    {
        public ClassificacaoProfile()
        {
            CreateMap<AdicionarClassificacaoCommand, AdicionarClassificacaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarClassificacaoDto, AdicionarClassificacaoCommand>();
            CreateMap<ClassificacaoDto, AdicionarClassificacaoCommand>();


            CreateMap<AtualizarClassificacaoCommand, AtualizarClassificacaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarClassificacaoDto, AtualizarClassificacaoCommand>();
            CreateMap<ClassificacaoDto, AtualizarClassificacaoCommand>();

            CreateMap<FilterBulkBase, ExcluirClassificacaoCommand>();
            CreateMap<ExcluirClassificacaoCommand, ExcluirClassificacaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
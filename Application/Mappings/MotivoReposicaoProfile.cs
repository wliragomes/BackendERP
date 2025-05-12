using Application.DTOs.MotivoReposições;
using Application.DTOs.MotivoReposições.Adicionar;
using Application.DTOs.MotivoReposições.Atualizar;
using Application.DTOs.MotivoReposições.Excluir;
using AutoMapper;
using Domain.Commands.MotivoReposições.Adicionar;
using Domain.Commands.MotivoReposições.Atualizar;
using Domain.Commands.MotivoReposições.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class MotivoReposicaoProfile : Profile
    {
        public MotivoReposicaoProfile()
        {
            CreateMap<AdicionarMotivoReposicaoCommand, AdicionarMotivoReposicaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarMotivoReposicaoDto, AdicionarMotivoReposicaoCommand>();
            CreateMap<MotivoReposicaoDto, AdicionarMotivoReposicaoCommand>();


            CreateMap<AtualizarMotivoReposicaoCommand, AtualizarMotivoReposicaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarMotivoReposicaoDto, AtualizarMotivoReposicaoCommand>();
            CreateMap<MotivoReposicaoDto, AtualizarMotivoReposicaoCommand>();

            CreateMap<FilterBulkBase, ExcluirMotivoReposicaoCommand>();
            CreateMap<ExcluirMotivoReposicaoCommand, ExcluirMotivoReposicaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
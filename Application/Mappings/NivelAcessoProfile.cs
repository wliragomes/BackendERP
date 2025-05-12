using Application.DTOs.NiveisAcessos;
using Application.DTOs.NiveisAcessos.Adicionar;
using Application.DTOs.NiveisAcessos.Atualizar;
using Application.DTOs.NiveisAcessos.Excluir;
using AutoMapper;
using Domain.Commands.NiveisAcessos.Adicionar;
using Domain.Commands.NiveisAcessos.Atualizar;
using Domain.Commands.NiveisAcessos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class NivelAcessoProfile : Profile
    {
        public NivelAcessoProfile()
        {
            CreateMap<AdicionarNivelAcessoCommand, AdicionarNivelAcessoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarNivelAcessoDto, AdicionarNivelAcessoCommand>();
            CreateMap<NivelAcessoDto, AdicionarNivelAcessoCommand>();

            CreateMap<AtualizarNivelAcessoCommand, AtualizarNivelAcessoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarNivelAcessoDto, AtualizarNivelAcessoCommand>();
            CreateMap<NivelAcessoDto, AtualizarNivelAcessoCommand>();

            CreateMap<FilterBulkBase, ExcluirNivelAcessoCommand>();
            CreateMap<ExcluirNivelAcessoCommand, ExcluirNivelAcessoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
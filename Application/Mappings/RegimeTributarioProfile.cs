using Application.DTOs.RegimeTributarios;
using Application.DTOs.RegimeTributarios.Adicionar;
using Application.DTOs.RegimeTributarios.Atualizar;
using Application.DTOs.RegimeTributarios.Excluir;
using AutoMapper;
using Domain.Commands.RegimeTributarios.Adicionar;
using Domain.Commands.RegimeTributarios.Atualizar;
using Domain.Commands.RegimeTributarios.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class RegimeTributarioProfile : Profile
    {
        public RegimeTributarioProfile()
        {
            CreateMap<AdicionarRegimeTributarioCommand, AdicionarRegimeTributarioRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarRegimeTributarioDto, AdicionarRegimeTributarioCommand>();
            CreateMap<RegimeTributarioDto, AdicionarRegimeTributarioCommand>();


            CreateMap<AtualizarRegimeTributarioCommand, AtualizarRegimeTributarioRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarRegimeTributarioDto, AtualizarRegimeTributarioCommand>();
            CreateMap<RegimeTributarioDto, AtualizarRegimeTributarioCommand>();

            CreateMap<FilterBulkBase, ExcluirRegimeTributarioCommand>();
            CreateMap<ExcluirRegimeTributarioCommand, ExcluirRegimeTributarioDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
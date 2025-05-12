using Application.DTOs.Paises;
using Application.DTOs.Paises.Adicionar;
using Application.DTOs.Paises.Atualizar;
using Application.DTOs.Paises.Excluir;
using AutoMapper;
using Domain.Commands.Paises.Adicionar;
using Domain.Commands.Paises.Atualizar;
using Domain.Commands.Paises.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<AdicionarPaisCommand, AdicionarPaisRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarPaisDto, AdicionarPaisCommand>();
            CreateMap<PaisDto, AdicionarPaisCommand>();


            CreateMap<AtualizarPaisCommand, AtualizarPaisRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarPaisDto, AtualizarPaisCommand>();
            CreateMap<PaisDto, AtualizarPaisCommand>();

            CreateMap<FilterBulkBase, ExcluirPaisCommand>();
            CreateMap<ExcluirPaisCommand, ExcluirPaisDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
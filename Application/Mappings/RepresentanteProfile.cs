using Application.DTOs.Representantes;
using Application.DTOs.Representantes.Adicionar;
using Application.DTOs.Representantes.Atualizar;
using Application.DTOs.Representantes.Excluir;
using AutoMapper;
using Domain.Commands.Representantes.Adicionar;
using Domain.Commands.Representantes.Atualizar;
using Domain.Commands.Representantes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class RepresentanteProfile : Profile
    {
        public RepresentanteProfile()
        {
            CreateMap<AdicionarRepresentanteCommand, AdicionarRepresentanteRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarRepresentanteDto, AdicionarRepresentanteCommand>();
            CreateMap<RepresentanteDto, AdicionarRepresentanteCommand>();


            CreateMap<AtualizarRepresentanteCommand, AtualizarRepresentanteRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarRepresentanteDto, AtualizarRepresentanteCommand>();
            CreateMap<RepresentanteDto, AtualizarRepresentanteCommand>();

            CreateMap<FilterBulkBase, ExcluirRepresentanteCommand>();
            CreateMap<ExcluirRepresentanteCommand, ExcluirRepresentanteDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
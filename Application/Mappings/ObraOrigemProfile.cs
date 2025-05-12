using Application.DTOs.ObraOrigens;
using Application.DTOs.ObraOrigens.Adicionar;
using Application.DTOs.ObraOrigens.Atualizar;
using Application.DTOs.ObraOrigens.Excluir;
using AutoMapper;
using Domain.Commands.ObraOrigems.Adicionar;
using Domain.Commands.ObraOrigems.Atualizar;
using Domain.Commands.ObraOrigems.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ObraOrigemProfile : Profile
    {
        public ObraOrigemProfile()
        {
            CreateMap<AdicionarObraOrigemCommand, AdicionarObraOrigemRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarObraOrigemDto, AdicionarObraOrigemCommand>();
            CreateMap<ObraOrigemDto, AdicionarObraOrigemCommand>();


            CreateMap<AtualizarObraOrigemCommand, AtualizarObraOrigemRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarObraOrigemDto, AtualizarObraOrigemCommand>();
            CreateMap<ObraOrigemDto, AtualizarObraOrigemCommand>();

            CreateMap<FilterBulkBase, ExcluirObraOrigemCommand>();
            CreateMap<ExcluirObraOrigemCommand, ExcluirObraOrigemDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
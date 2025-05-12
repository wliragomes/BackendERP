using Application.DTOs.ObrasProjetos;
using Application.DTOs.ObrasProjetos.Adicionar;
using Application.DTOs.ObrasProjetos.Atualizar;
using Application.DTOs.ObrasProjetos.Excluir;
using AutoMapper;
using Domain.Commands.ObrasProjetos.Adicionar;
using Domain.Commands.ObrasProjetos.Atualizar;
using Domain.Commands.ObrasProjetos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ObraProjetoProfile : Profile
    {
        public ObraProjetoProfile()
        {
            CreateMap<AdicionarObraProjetoCommand, AdicionarObraProjetoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarObraProjetoDto, AdicionarObraProjetoCommand>();
            CreateMap<ObraProjetoDto, AdicionarObraProjetoCommand>();


            CreateMap<AtualizarObraProjetoCommand, AtualizarObraProjetoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarObraProjetoDto, AtualizarObraProjetoCommand>();
            CreateMap<ObraProjetoDto, AtualizarObraProjetoCommand>();

            CreateMap<FilterBulkBase, ExcluirObraProjetoCommand>();
            CreateMap<ExcluirObraProjetoCommand, ExcluirObraProjetoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
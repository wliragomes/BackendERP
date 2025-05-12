using Application.DTOs.Modalidades;
using Application.DTOs.Modalidades.Adicionar;
using Application.DTOs.Modalidades.Atualizar;
using Application.DTOs.Modalidades.Excluir;
using AutoMapper;
using Domain.Commands.Modalidades.Adicionar;
using Domain.Commands.Modalidades.Atualizar;
using Domain.Commands.Modalidades.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ModalidadeProfile : Profile
    {
        public ModalidadeProfile()
        {
            CreateMap<AdicionarModalidadeCommand, AdicionarModalidadeRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarModalidadeDto, AdicionarModalidadeCommand>();
            CreateMap<ModalidadeDto, AdicionarModalidadeCommand>();


            CreateMap<AtualizarModalidadeCommand, AtualizarModalidadeRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarModalidadeDto, AtualizarModalidadeCommand>();
            CreateMap<ModalidadeDto, AtualizarModalidadeCommand>();

            CreateMap<FilterBulkBase, ExcluirModalidadeCommand>();
            CreateMap<ExcluirModalidadeCommand, ExcluirModalidadeDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
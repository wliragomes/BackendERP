using Application.DTOs.Projetos;
using Application.DTOs.Projetos.Adicionar;
using Application.DTOs.Projetos.Atualizar;
using Application.DTOs.Projetos.Excluir;
using AutoMapper;
using Domain.Commands.Projetos.Adicionar;
using Domain.Commands.Projetos.Atualizar;
using Domain.Commands.Projetos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<AdicionarProjetoCommand, AdicionarProjetoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarProjetoDto, AdicionarProjetoCommand>();
            CreateMap<ProjetoDto, AdicionarProjetoCommand>();


            CreateMap<AtualizarProjetoCommand, AtualizarProjetoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarProjetoDto, AtualizarProjetoCommand>();
            CreateMap<ProjetoDto, AtualizarProjetoCommand>();

            CreateMap<FilterBulkBase, ExcluirProjetoCommand>();
            CreateMap<ExcluirProjetoCommand, ExcluirProjetoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
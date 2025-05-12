using Application.DTOs.FusoHorarios;
using Application.DTOs.FusoHorarios.Adicionar;
using Application.DTOs.FusoHorarios.Atualizar;
using Application.DTOs.FusoHorarios.Excluir;
using AutoMapper;
using Domain.Commands.FusoHorarios.Adicionar;
using Domain.Commands.FusoHorarios.Atualizar;
using Domain.Commands.FusoHorarios.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class FusoHorarioProfile : Profile
    {
        public FusoHorarioProfile()
        {
            CreateMap<AdicionarFusoHorarioCommand, AdicionarFusoHorarioRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarFusoHorarioDto, AdicionarFusoHorarioCommand>();
            CreateMap<FusoHorarioDto, AdicionarFusoHorarioCommand>();


            CreateMap<AtualizarFusoHorarioCommand, AtualizarFusoHorarioRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarFusoHorarioDto, AtualizarFusoHorarioCommand>();
            CreateMap<FusoHorarioDto, AtualizarFusoHorarioCommand>();

            CreateMap<FilterBulkBase, ExcluirFusoHorarioCommand>();
            CreateMap<ExcluirFusoHorarioCommand, ExcluirFusoHorarioDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
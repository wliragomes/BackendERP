using Application.DTOs.MotivoCancelamentos;
using Application.DTOs.MotivoCancelamentos.Adicionar;
using Application.DTOs.MotivoCancelamentos.Atualizar;
using Application.DTOs.MotivoCancelamentos.Excluir;
using AutoMapper;
using Domain.Commands.MotivoCancelamentos.Adicionar;
using Domain.Commands.MotivoCancelamentos.Atualizar;
using Domain.Commands.MotivoCancelamentos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class MotivoCancelamentoProfile : Profile
    {
        public MotivoCancelamentoProfile()
        {
            CreateMap<AdicionarMotivoCancelamentoCommand, AdicionarMotivoCancelamentoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarMotivoCancelamentoDto, AdicionarMotivoCancelamentoCommand>();
            CreateMap<MotivoCancelamentoDto, AdicionarMotivoCancelamentoCommand>();


            CreateMap<AtualizarMotivoCancelamentoCommand, AtualizarMotivoCancelamentoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarMotivoCancelamentoDto, AtualizarMotivoCancelamentoCommand>();
            CreateMap<MotivoCancelamentoDto, AtualizarMotivoCancelamentoCommand>();

            CreateMap<FilterBulkBase, ExcluirMotivoCancelamentoCommand>();
            CreateMap<ExcluirMotivoCancelamentoCommand, ExcluirMotivoCancelamentoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
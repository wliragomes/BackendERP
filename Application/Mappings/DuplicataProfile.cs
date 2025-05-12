using Application.DTOs.Duplicatas;
using Application.DTOs.Duplicatas.Adicionar;
using Application.DTOs.Duplicatas.Atualizar;
using Application.DTOs.Duplicatas.Excluir;
using AutoMapper;
using Domain.Commands.ContasAPagar.Excluir;
using Domain.Commands.Duplicatas;
using Domain.Commands.Duplicatas.Adicionar;
using Domain.Commands.Duplicatas.Atualizar;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class DuplicataProfile : Profile
    {
        public DuplicataProfile()
        {
            CreateMap<AdicionarDuplicataCommand, AdicionarDuplicataRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarDuplicataDto, AdicionarDuplicataCommand>();
            CreateMap<DuplicataDto, AdicionarDuplicataCommand>();

            CreateMap<AtualizarDuplicataCommand, AtualizarDuplicataRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarDuplicataDto, AtualizarDuplicataCommand>();
            CreateMap<DuplicataDto, AtualizarDuplicataCommand>();

            CreateMap<FilterBulkBase, ExcluirDuplicataCommand>();
            CreateMap<ExcluirDuplicataCommand, ExcluirDuplicataDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
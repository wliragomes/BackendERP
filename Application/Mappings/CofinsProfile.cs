using AutoMapper;
using Domain.Commands.Impostos.Piss.Excluir;
using SharedKernel.SharedObjects;
using Application.DTOs.Impostos.Cofinss.Adicionar;
using Application.DTOs.Impostos.Cofinss;
using Application.DTOs.Impostos.Cofinss.Atualizar;
using Application.DTOs.Impostos.Coffinss.Excluir;
using Domain.Commands.Impostos.Cofinss.Adicionar;
using Domain.Commands.Impostos.Cofinss.Atualizar;
using Domain.Commands.Impostos.Cofinss.Excluir;

namespace Application.Mappings
{
    internal class CofinsProfile : Profile
    {
        public CofinsProfile()
        {
            CreateMap<AdicionarCofinsCommand, AdicionarCofinsRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCofinsDto, AdicionarCofinsCommand>();
            CreateMap<CofinsDto, AdicionarCofinsCommand>();


            CreateMap<AtualizarCofinsCommand, AtualizarCofinsRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCofinsDto, AtualizarCofinsCommand>();
            CreateMap<CofinsDto, AtualizarCofinsCommand>();

            CreateMap<FilterBulkBase, ExcluirCofinsCommand>();
            CreateMap<ExcluirCofinsCommand, ExcluirCofinsDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.Ncms.Adicionar;
using Application.DTOs.Produtos.Ncms;
using Application.DTOs.Produtos.Ncms.Atualizar;
using Application.DTOs.Produtos.Ncms.Excluir;
using Domain.Commands.Produtos.Ncms.Adicionar;
using Domain.Commands.Produtos.Ncms.Atualizar;
using Domain.Commands.Produtos.Ncms.Excluir;

namespace Application.Mappings
{
    internal class NcmProfile : Profile
    {
        public NcmProfile()
        {
            CreateMap<AdicionarNcmCommand, AdicionarNcmRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarNcmDto, AdicionarNcmCommand>();
            CreateMap<NcmDto, AdicionarNcmCommand>();


            CreateMap<AtualizarNcmCommand, AtualizarNcmRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarNcmDto, AtualizarNcmCommand>();
            CreateMap<NcmDto, AtualizarNcmCommand>();

            CreateMap<FilterBulkBase, ExcluirNcmCommand>();
            CreateMap<ExcluirNcmCommand, ExcluirNcmDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

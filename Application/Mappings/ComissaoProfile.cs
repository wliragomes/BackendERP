using Application.DTOs.Comissoes;
using Application.DTOs.Comissoes.Adicionar;
using Application.DTOs.Comissoes.Atualizar;
using Application.DTOs.Comissoes.Excluir;
using AutoMapper;
using Domain.Commands.Comissoes.Adicionar;
using Domain.Commands.Comissoes.Atualizar;
using Domain.Commands.Comissoes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ComissaoProfile : Profile
    {
        public ComissaoProfile()
        {
            CreateMap<AdicionarComissaoCommand, AdicionarComissaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarComissaoDto, AdicionarComissaoCommand>();
            CreateMap<ComissaoDto, AdicionarComissaoCommand>();


            CreateMap<AtualizarComissaoCommand, AtualizarComissaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarComissaoDto, AtualizarComissaoCommand>();
            CreateMap<ComissaoDto, AtualizarComissaoCommand>();

            CreateMap<FilterBulkBase, ExcluirComissaoCommand>();
            CreateMap<ExcluirComissaoCommand, ExcluirComissaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
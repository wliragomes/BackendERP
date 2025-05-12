using AutoMapper;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.Ncms.Atualizar;
using Application.DTOs.Produtos.UnidadesMedidas.Adicionar;
using Application.DTOs.Produtos.UnidadesMedidas.Atualizar;
using Application.DTOs.Produtos.UnidadesMedidas.Excluir;
using Domain.Commands.Produtos.UnidadesMedidas.Adicionar;
using Domain.Commands.Produtos.UnidadesMedidas.Atualizar;
using Domain.Commands.Produtos.UnidadesMedidas.Excluir;
using Application.DTOs.Produtos.UnidadesMedidas;
using Application.DTOs.Produtos.Familias.Adicionar;

namespace Application.Mappings
{
    internal class UnidadeMedidaProfile : Profile
    {
        public UnidadeMedidaProfile()
        {
            CreateMap<AdicionarUnidadeMedidaCommand, AdicionarUnidadeMedidaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarUnidadeMedidaDto, AdicionarUnidadeMedidaCommand>();
            CreateMap<UnidadeMedidaDto, AdicionarUnidadeMedidaCommand>();


            CreateMap<AtualizarUnidadeMedidaCommand, AtualizarUnidadeMedidaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarUnidadeMedidaDto, AtualizarUnidadeMedidaCommand>();
            CreateMap<UnidadeMedidaDto, AtualizarNcmCommand>();

            CreateMap<FilterBulkBase, ExcluirUnidadeMedidaCommand>();
            CreateMap<ExcluirUnidadeMedidaCommand, ExcluirUnidadeMedidaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

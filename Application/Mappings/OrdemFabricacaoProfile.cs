using Application.DTOs.OrdensFabricacoes;
using Application.DTOs.OrdensFabricacoes.Adicionar;
using Application.DTOs.OrdensFabricacoes.Atualizar;
using Application.DTOs.OrdensFabricacoes.Excluir;
using AutoMapper;
using Domain.Commands.OrdensFabricacoes;
using Domain.Commands.OrdensFabricacoes.Adicionar;
using Domain.Commands.OrdensFabricacoes.Atualizar;
using Domain.Commands.OrdensFabricacoes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class OrdemFabricacaoProfile : Profile
    {
        public OrdemFabricacaoProfile()
        {
            CreateMap<AdicionarOrdemFabricacaoCommand, AdicionarOrdemFabricacaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarOrdemFabricacaoDto, AdicionarOrdemFabricacaoCommand>();
            CreateMap<OrdemFabricacaoDto, AdicionarOrdemFabricacaoCommand>();

            CreateMap<AdicionarOrdemFabricacaoTemporariaCommand, AdicionarOrdemFabricacaoTemporariaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarOrdemFabricacaoTemporariaDto, AdicionarOrdemFabricacaoTemporariaCommand>();
            CreateMap<OrdemFabricacaoTemporariaDto, AdicionarOrdemFabricacaoTemporariaCommand>();

            CreateMap<OrdemFabricacaoArquivoDto, OrdemFabricacaoArquivoCommand>();
            CreateMap<OrdemFabricacaoItemDto, OrdemFabricacaoItemCommand>();
            CreateMap<OrdemFabricacaoItemTemporariaDto, OrdemFabricacaoItemTemporariaCommand>();

            CreateMap<AtualizarOrdemFabricacaoCommand, AtualizarOrdemFabricacaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarOrdemFabricacaoDto, AtualizarOrdemFabricacaoCommand>();
            CreateMap<OrdemFabricacaoDto, AtualizarOrdemFabricacaoCommand>();

            CreateMap<FilterBulkBase, ExcluirOrdemFabricacaoCommand>();
            CreateMap<ExcluirOrdemFabricacaoCommand, ExcluirOrdemFabricacaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.TiposPrecos.Adicionar;
using Application.DTOs.Produtos.TiposPrecos.Atualizar;
using Application.DTOs.Produtos.TiposPrecos.Excluir;
using Domain.Commands.Produtos.TiposPrecos.Adicionar;
using Domain.Commands.Produtos.TiposPrecos.Atualizar;
using Domain.Commands.Produtos.TiposPrecos.Excluir;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class TipoPrecoProfile : Profile
    {
        public TipoPrecoProfile()
        {
            CreateMap<AdicionarTipoPrecoCommand, AdicionarTipoPrecoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarTipoPrecoDto, AdicionarTipoPrecoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarTipoPrecoCommand>();


            CreateMap<AtualizarTipoPrecoCommand, AtualizarTipoPrecoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarTipoPrecoDto, AtualizarTipoPrecoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarTipoPrecoCommand>();

            CreateMap<FilterBulkBase, ExcluirTipoPrecoCommand>();
            CreateMap<ExcluirTipoPrecoCommand, ExcluirTipoPrecoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

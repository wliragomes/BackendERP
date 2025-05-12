using AutoMapper;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.Prateleiras.Adicionar;
using Application.DTOs.Produtos.Prateleiras.Atualizar;
using Application.DTOs.Produtos.Prateleiras.Excluir;
using Domain.Commands.Produtos.Prateleiras.Adicionar;
using Domain.Commands.Produtos.Prateleiras.Atualizar;
using Domain.Commands.Produtos.Prateleiras.Excluir;
using Application.DTOs.Pessoas;

namespace Application.Mappings
{
    internal class PrateleiraProfile : Profile
    {
        public PrateleiraProfile()
        {
            CreateMap<AdicionarPrateleiraCommand, AdicionarPrateleiraRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarPrateleiraDto, AdicionarPrateleiraCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarPrateleiraCommand>();


            CreateMap<AtualizarPrateleiraCommand, AtualizarPrateleiraRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarPrateleiraDto, AtualizarPrateleiraCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarPrateleiraCommand>();

            CreateMap<FilterBulkBase, ExcluirPrateleiraCommand>();
            CreateMap<ExcluirPrateleiraCommand, ExcluirPrateleiraDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}

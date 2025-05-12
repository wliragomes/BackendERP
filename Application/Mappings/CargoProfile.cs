using Application.DTOs.Pessoas;
using Application.DTOs.Pessoas.Cargos.Adicionar;
using Application.DTOs.Pessoas.Cargos.Atualizar;
using Application.DTOs.Pessoas.Cargos.Excluir;
using AutoMapper;
using Domain.Commands.Cargos.Adicionar;
using Domain.Commands.Cargos.Atualizar;
using Domain.Commands.Cargos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<AdicionarCargoCommand, AdicionarCargoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCargoDto, AdicionarCargoCommand>();
            CreateMap<PadraoDescricaoDto, AdicionarCargoCommand>();


            CreateMap<AtualizarCargoCommand, AtualizarCargoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCargoDto, AtualizarCargoCommand>();
            CreateMap<PadraoDescricaoDto, AtualizarCargoCommand>();

            CreateMap<FilterBulkBase, ExcluirCargoCommand>();
            CreateMap<ExcluirCargoCommand, ExcluirCargoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
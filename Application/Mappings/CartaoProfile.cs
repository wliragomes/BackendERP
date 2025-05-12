using Application.DTOs.Cartoes;
using Application.DTOs.Cartoes.Adicionar;
using Application.DTOs.Cartoes.Atualizar;
using Application.DTOs.Cartoes.Excluir;
using AutoMapper;
using Domain.Commands.Cartoes.Adicionar;
using Domain.Commands.Cartoes.Atualizar;
using Domain.Commands.Cartoes.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class CartaoProfile : Profile
    {
        public CartaoProfile()
        {
            CreateMap<AdicionarCartaoCommand, AdicionarCartaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarCartaoDto, AdicionarCartaoCommand>();
            CreateMap<CartaoDto, AdicionarCartaoCommand>();


            CreateMap<AtualizarCartaoCommand, AtualizarCartaoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarCartaoDto, AtualizarCartaoCommand>();
            CreateMap<CartaoDto, AtualizarCartaoCommand>();

            CreateMap<FilterBulkBase, ExcluirCartaoCommand>();
            CreateMap<ExcluirCartaoCommand, ExcluirCartaoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
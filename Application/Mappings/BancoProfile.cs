using Application.DTOs.Bancos;
using Application.DTOs.Bancos.Adicionar;
using Application.DTOs.Bancos.Atualizar;
using Application.DTOs.Bancos.Excluir;
using AutoMapper;
using Domain.Commands.Bancos.Adicionar;
using Domain.Commands.Bancos.Atualizar;
using Domain.Commands.Bancos.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class BancoProfile : Profile
    {
        public BancoProfile()
        {
            CreateMap<AdicionarBancoCommand, AdicionarBancoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarBancoDto, AdicionarBancoCommand>();
            CreateMap<BancoDto, AdicionarBancoCommand>();


            CreateMap<AtualizarBancoCommand, AtualizarBancoRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarBancoDto, AtualizarBancoCommand>();
            CreateMap<BancoDto, AtualizarBancoCommand>();

            CreateMap<FilterBulkBase, ExcluirBancoCommand>();
            CreateMap<ExcluirBancoCommand, ExcluirBancoDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
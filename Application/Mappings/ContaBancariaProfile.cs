using Application.DTOs.ContasBancarias;
using Application.DTOs.ContasBancarias.Adicionar;
using Application.DTOs.ContasBancarias.Atualizar;
using Application.DTOs.ContasBancarias.Excluir;
using AutoMapper;
using Domain.Commands.ContasBancarias.Adicionar;
using Domain.Commands.ContasBancarias.Atualizar;
using Domain.Commands.ContasBancarias.Excluir;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class ContaBancariaProfile : Profile
    {
        public ContaBancariaProfile()
        {
            CreateMap<AdicionarContaBancariaCommand, AdicionarContaBancariaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarContaBancariaDto, AdicionarContaBancariaCommand>();
            CreateMap<ContaBancariaDto, AdicionarContaBancariaCommand>();


            CreateMap<AtualizarContaBancariaCommand, AtualizarContaBancariaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarContaBancariaDto, AtualizarContaBancariaCommand>();
            CreateMap<ContaBancariaDto, AtualizarContaBancariaCommand>();

            CreateMap<FilterBulkBase, ExcluirContaBancariaCommand>();
            CreateMap<ExcluirContaBancariaCommand, ExcluirContaBancariaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
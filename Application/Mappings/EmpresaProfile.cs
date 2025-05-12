using Application.DTOs.Empresas;
using Application.DTOs.Empresas.Adicionar;
using Application.DTOs.Empresas.Atualizar;
using Application.DTOs.Empresas.Excluir;
using Application.DTOs.Pessoas;
using AutoMapper;
using Domain.Commands.Empresas;
using Domain.Commands.Empresas.Adicionar;
using Domain.Commands.Empresas.Atualizar;
using Domain.Commands.Empresas.Excluir;
using Domain.Commands.Pessoas;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<AdicionarEmpresaCommand, AdicionarEmpresaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarEmpresaDto, AdicionarEmpresaCommand>();
            CreateMap<EmpresaDto, AdicionarEmpresaCommand>();

            CreateMap<SocioDto, SocioCommand>();
            CreateMap<EmailDto, EmailCommand>();
            CreateMap<TelefoneDto, TelefoneCommand>();
            CreateMap<EnderecoDto, EnderecoCommand>();
            CreateMap<ParametroFaturaDto, ParametroFaturaCommand>();

            CreateMap<AtualizarEmpresaCommand, AtualizarEmpresaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarEmpresaDto, AtualizarEmpresaCommand>();
            CreateMap<EmpresaDto, AtualizarEmpresaCommand>();

            CreateMap<FilterBulkBase, ExcluirEmpresaCommand>();
            CreateMap<ExcluirEmpresaCommand, ExcluirEmpresaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
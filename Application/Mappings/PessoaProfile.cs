using Application.DTOs.Funcionalidades;
using Application.DTOs.Pessoas;
using Application.DTOs.Pessoas.Adicionar;
using Application.DTOs.Pessoas.Atualizar;
using Application.DTOs.Pessoas.Excluir;
using Application.DTOs.Pessoas.Filtro;
using Application.DTOs.Pessoas.ValidarCpfsCnpjs;
using AutoMapper;
using Domain.Commands.Pessoas;
using Domain.Commands.Pessoas.Adicionar;
using Domain.Commands.Pessoas.Atualizar;
using Domain.Commands.Pessoas.Excluir;
using Domain.Commands.ValidarCpfCnpjs.Adicionar;
using SharedKernel.SharedObjects;

namespace Application.Mappings
{
    internal class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<AdicionarPessoaCommand, AdicionarPessoaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AdicionarPessoaDto, AdicionarPessoaCommand>();
            CreateMap<PessoaDto, AdicionarPessoaCommand>();

            CreateMap<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterCommand>();
            CreateMap<EnderecoDto, EnderecoCommand>();
            CreateMap<TelefoneDto, TelefoneCommand>();
            CreateMap<EmailDto, EmailCommand>();
            CreateMap<ContatoDto, ContatoCommand>();
            CreateMap<DadosCobrancaDto, DadosCobrancaCommand>();
            CreateMap<AnaliseCreditoDto, AnaliseCreditoCommand>();

            CreateMap<PessoaFuncionalidadeDto, PessoaFuncionalidadeCommand>();
            CreateMap<PessoaNivelAcessoDto, PessoaNivelAcessoCommand>();
            CreateMap<PermissaoDto, PermissaoCommand>();
            CreateMap<UsuarioPessoaDto, UsuarioPessoaCommand>();

            CreateMap<AdicionarValidarCpfCnpjCommand, AdicionarValidarCpfCnpjRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<ValidarCpfCnpjDto, AdicionarValidarCpfCnpjCommand>();

            CreateMap<AtualizarPessoaCommand, AtualizarPessoaRequestDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src)).ReverseMap();
            CreateMap<AtualizarPessoaDto, AtualizarPessoaCommand>();
            CreateMap<PessoaDto, AtualizarPessoaCommand>();

            CreateMap<FilterBulkBase, ExcluirPessoaCommand>();
            CreateMap<ExcluirPessoaCommand, ExcluirPessoaDto>()
                .ForMember(dest => dest.Formulario, opt => opt.MapFrom(src => src.FiltroBase)).ReverseMap();
        }
    }
}
using Application.DTOs.Pessoas.Filtro;
using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Domain.Entities.Pessoas;
using Application.DTOs.Pessoas;
using Application.DTOs.Funcionalidades;
using Application.DTOs.Pessoas.TipoConsumidores.Filtro;

namespace Infra.Queries.Pessoas
{
    public class PessoaQuery : IPessoaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public PessoaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<PessoaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Pessoa.AsNoTracking()
                        .Include(e => e.RelacionaPessoaEnderecos!).ThenInclude(rpe => rpe.Endereco).ThenInclude(e => e.Estado)
                        .AsQueryable(); //Remover o AsQueryable caso não preciso dos if's abaixo

            if (paginacaoRequest.FiltrarPor == "vendedor" && paginacaoRequest.ValorFiltro == "true")
                query = query.Where(x => x.Vendedor == true);

            if (paginacaoRequest.FiltrarPor == "fornecedor" && paginacaoRequest.ValorFiltro == "true")
                query = query.Where(x => x.Fornecedor == true);

            if (paginacaoRequest.FiltrarPor == "usuario" && paginacaoRequest.ValorFiltro == "true")
                query = query.Where(x => x.Usuario == true);

            var data = query.Select(x => new PessoaFilterDto
            {
                Id = x.Id,
                Ativo = x.Ativo,
                CnpjCpf = x.CnpjCpf,
                RazaoSocial = x.RazaoSocial,
                Vendedor = x.Vendedor ?? false,
                Fornecedor = x.Fornecedor ?? false,
                Usuario = x.Usuario ?? false,
                UF = x.RelacionaPessoaEnderecos!.Select(rpe => rpe.Endereco!.Estado!.Sigla).FirstOrDefault()!
            });

            var response = await data.RetonarFiltroCustomizado<PessoaFilterDto, PessoaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PessoaByIdDto?> RetornarPorId(Guid id)
        {
            var pessoa = await _dbContext.Pessoa.AsNoTracking()
                .Include(c => c.Vendedores)
                .Include(c => c.Regiao)
                .Include(c => c.Origem)
                .Include(c => c.SegmentoCliente)
                .Include(c => c.SegmentoEstrategico)
                .Include(c => c.DadosCobrancas!).ThenInclude(t => t.RelacionaDadosCobrancaEnderecos!).ThenInclude(rpe => rpe.Endereco).ThenInclude(te => te!.TiposEndereco)
                .Include(c => c.DadosCobrancas!).ThenInclude(t => t.RelacionaDadosCobrancaEnderecos!).ThenInclude(rpe => rpe.Endereco).ThenInclude(te => te!.Cidade)
                .Include(c => c.DadosCobrancas!).ThenInclude(t => t.RelacionaDadosCobrancaEnderecos!).ThenInclude(rpe => rpe.Endereco).ThenInclude(te => te!.Estado)
                .Include(c => c.DadosCobrancas!).ThenInclude(t => t.RelacionaDadosCobrancaTelefones!).ThenInclude(rpe => rpe.Telefone).ThenInclude(te => te!.TiposTelefone)
                .Include(c => c.AnaliseCreditos!).ThenInclude(t => t.ResponsavelConsulta)
                .Include(c => c.Contatos!).ThenInclude(t => t.RelacionaPessoaContatoTelefones).ThenInclude(rpe => rpe.Telefone).ThenInclude(te => te!.TiposTelefone)
                .Include(c => c.Contatos!).ThenInclude(t => t.RelacionaPessoaContatoEnderecos).ThenInclude(rpe => rpe.Endereco).ThenInclude(te => te!.TiposEndereco)
                .Include(c => c.Contatos!).ThenInclude(t => t.RelacionaPessoaContatoEnderecos).ThenInclude(rpe => rpe.Endereco).ThenInclude(te => te!.Cidade)
                .Include(c => c.Contatos!).ThenInclude(t => t.RelacionaPessoaContatoEnderecos).ThenInclude(rpe => rpe.Endereco).ThenInclude(te => te!.Estado)
                .Include(c => c.Contatos!).ThenInclude(t => t.Departamento)
                .Include(c => c.Contatos!).ThenInclude(t => t.Email)
                .Include(c => c.Contatos!).ThenInclude(t => t.Cargo)
                .Include(e => e.RelacionaPessoaEnderecos!).ThenInclude(rpe => rpe.Endereco).ThenInclude(te => te!.TiposEndereco)
                .Include(t => t.RelacionaPessoaTelefones!).ThenInclude(rpt => rpt.Telefone).ThenInclude(te => te!.TiposTelefone)
                .Include(em => em.RelacionaPessoaEmails!).ThenInclude(rpe => rpe.Email).ThenInclude(te => te!.TiposEmail)
                .Include(e => e.RelacionaPessoaEnderecos!).ThenInclude(rpe => rpe.Endereco).ThenInclude(e => e!.Cidade)
                .Include(e => e.RelacionaPessoaEnderecos!).ThenInclude(rpe => rpe.Endereco).ThenInclude(e => e!.Estado)
                .Include(c => c.Usuarios!).ThenInclude(p => p.RelacionaUsuarioFuncionalidadeNivelAcesso)
                .Include(c => c.UsuarioCadastro).ThenInclude(u => u.Pessoa)

                .FirstOrDefaultAsync(x => x.Id == id);

            if (pessoa == null)
                return null;

            return MapToPessoaByIdDto(pessoa);
        }

        private PessoaByIdDto MapToPessoaByIdDto(Pessoa pessoa)
        {
            return new PessoaByIdDto
            {
                Id = pessoa.Id,
                NomeUsuario = pessoa.UsuarioCadastro.Pessoa.RazaoSocial,
                Ativo = pessoa.Ativo,
                Cliente = pessoa.Cliente,
                Fornecedor = pessoa.Fornecedor,
                Juridica = pessoa.Juridica,
                Estrangeiro = pessoa.Estrangeiro,
                Nacional = pessoa.Nacional,
                Usuario = pessoa.Usuario,
                Motorista = pessoa.Motorista,
                Vendedor = pessoa.Vendedor,
                CnpjCpf = pessoa.CnpjCpf,
                RazaoSocial = pessoa.RazaoSocial,
                Fantasia = pessoa.Fantasia!,
                Regiao = pessoa.Regiao == null
                    ? null
                    : new PadraoIdDescricaoFilterDto
                    {
                        Id = pessoa.Regiao.Id,
                        Descricao = pessoa.Regiao.Nome,
                    },
                IdVendedor = pessoa.Vendedores != null ? pessoa.Vendedores.Id : null,
                InscricaoSuframa = pessoa.InscricaoSuframa!,
                EnviarEmail = pessoa.EnviarEmail,
                EtiquetaUnit = pessoa.EtiquetaUnit,
                ImprimeEtiqueta = pessoa.ImprimeEtiqueta,
                EtiquetaPorLote = pessoa.EtiquetaPorLote,
                Origem = pessoa.Origem == null
                    ? null
                    : new PadraoIdDescricaoFilterDto
                    {
                        Id = pessoa.Origem!.Id,
                        Descricao = pessoa.Origem.Descricao,
                    },
                SegmentoCliente = pessoa.SegmentoCliente == null
                    ? null
                    : new PadraoIdDescricaoFilterDto
                    {
                        Id = pessoa.SegmentoCliente!.Id,
                        Descricao = pessoa.SegmentoCliente.Descricao,
                    },
                SegmentoEstrategico = pessoa.SegmentoEstrategico == null
                    ? null
                    : new PadraoIdDescricaoFilterDto
                    {
                        Id = pessoa.SegmentoEstrategico!.Id,
                        Descricao = pessoa.SegmentoEstrategico.Descricao,
                    },
                InscricaoMunicipal = pessoa.InscricaoMunicipal!,
                InscricaoEstadual = pessoa.InscricaoEstadual!,
                Cei = pessoa.Cei!,

                NaoContribuinte = pessoa.NaoContribuinte ?? false,
                EtiquetaEspecialGuardian = pessoa.EtiquetaEspecialGuardian ?? false,
                IdTipoConsumidor = pessoa.IdTipoConsumidor,
                IncideSubstituicaoIcms = pessoa.IncideSubstituicaoIcms ?? false,
                ConsumidorFinal = pessoa.ConsumidorFinal ?? false,
                Industria = pessoa.Industria ?? false,
                DigitarIcms = pessoa.DigitarIcms ?? false,

                Enderecos = pessoa.RelacionaPessoaEnderecos!.Select(rpe => new EnderecoFilterDto
                {
                    Id = rpe.Endereco!.Id,
                    TipoEndereco = rpe.Endereco.TiposEndereco!.Descricao,
                    EnderecoDescricao = rpe.Endereco.EnderecoDescricao,
                    Numero = rpe.Endereco.Numero,
                    Complemento = rpe.Endereco.Complemento,
                    Cidade = rpe.Endereco.Cidade != null ? new PadraoIdDescricaoFilterDto
                    {
                        Id = rpe.Endereco.Cidade.Id,
                        Descricao = rpe.Endereco.Cidade?.Nome
                    } : null,
                    Bairro = rpe.Endereco.Bairro,
                    Uf = new PadraoIdDescricaoFilterDto
                    {
                        Id = rpe.Endereco.Estado!.Id,
                        Descricao = rpe.Endereco.Estado?.Sigla
                    },
                    Cep = rpe.Endereco.Cep
                }).ToList(),
                Telefones = pessoa.RelacionaPessoaTelefones!.Select(rpt => new TelefoneFilterDto
                {
                    Id = rpt.Telefone!.Id,
                    Numero = rpt.Telefone.Numero,
                    Tipo = rpt.Telefone.TiposTelefone!.Descricao,
                }).ToList(),
                Emails = pessoa.RelacionaPessoaEmails!.Select(rpt => new EmailFilterDto
                {
                    Id = rpt.Email!.Id,
                    Email = rpt.Email.EnderecoEmail,
                    Tipo = rpt.Email.TiposEmail.Descricao,
                }).ToList(),
                Contatos = pessoa.Contatos!.Select(rpc => new ContatoFilterDto
                {
                    Id = rpc.Id,
                    Nome = rpc.Nome,
                    Apelido = rpc.Apelido,
                    Departamento = rpc.Departamento != null ? new PadraoIdDescricaoFilterDto
                    {
                        Id = rpc.Departamento!.Id,
                        Descricao = rpc.Departamento?.Nome
                    } : null,
                    Cargo = rpc.Cargo != null ? new PadraoIdDescricaoFilterDto
                    {
                        Id = rpc.Cargo!.Id,
                        Descricao = rpc.Cargo?.Nome
                    } : null,
                    Secretaria = rpc.Secretaria,
                    DataAniversario = rpc.DataAniversario,
                    Email = rpc.Email != null ? new PadraoIdDescricaoFilterDto
                    {
                        Id = rpc.Email!.Id,
                        Descricao = rpc.Email?.EnderecoEmail
                    } : null,
                    Enderecos = rpc.RelacionaPessoaContatoEnderecos.Select(rpe => new EnderecoFilterDto
                    {
                        Id = rpe.Endereco!.Id,
                        TipoEndereco = rpe.Endereco.TiposEndereco?.Descricao!,
                        EnderecoDescricao = rpe.Endereco.EnderecoDescricao,
                        Numero = rpe.Endereco.Numero,
                        Complemento = rpe.Endereco.Complemento,
                        Cidade = new PadraoIdDescricaoFilterDto
                        {
                            Id = rpe.Endereco.Cidade!.Id,
                            Descricao = rpe.Endereco.Cidade?.Nome
                        },
                        Bairro = rpe.Endereco.Bairro,
                        Uf = new PadraoIdDescricaoFilterDto
                        {
                            Id = rpe.Endereco.Estado!.Id,
                            Descricao = rpe.Endereco.Estado?.Nome
                        },
                        Cep = rpe.Endereco.Cep
                    }).ToList(),
                    Telefones = rpc.RelacionaPessoaContatoTelefones.Select(rpt => new TelefoneFilterDto
                    {
                        Id = rpt.Telefone!.Id,
                        Numero = rpt.Telefone.Numero,
                        Tipo = rpt.Telefone.TiposTelefone!.Descricao,
                    }).ToList(),
                }).ToList(),
                DadosDaCobranca = pessoa.DadosCobrancas!.Select(rdp => new DadosCobrancaFilterDto
                {
                    Responsavel = rdp.Responsavel,
                    Enderecos = rdp.RelacionaDadosCobrancaEnderecos!.Select(rde => new EnderecoFilterDto
                    {
                        Id = rde.Endereco!.Id,
                        TipoEndereco = rde.Endereco.TiposEndereco!.Descricao,
                        EnderecoDescricao = rde.Endereco.EnderecoDescricao,
                        Numero = rde.Endereco.Numero,
                        Complemento = rde.Endereco.Complemento,
                        Cidade = new PadraoIdDescricaoFilterDto
                        {
                            Id = rde.Endereco.Cidade!.Id,
                            Descricao = rde.Endereco.Cidade?.Nome
                        },
                        Bairro = rde.Endereco.Bairro,
                        Uf = new PadraoIdDescricaoFilterDto
                        {
                            Id = rde.Endereco.Estado!.Id,
                            Descricao = rde.Endereco.Estado?.Sigla
                        },
                        Cep = rde.Endereco.Cep
                    }).ToList(),
                    Telefones = rdp.RelacionaDadosCobrancaTelefones!.Select(rdt => new TelefoneFilterDto
                    {
                        Id = rdt.Telefone!.Id,
                        Numero = rdt.Telefone.Numero,
                        Tipo = rdt.Telefone.TiposTelefone!.Descricao,
                    }).ToList(),
                }).ToList(),
                //CreditoComissao = new CreditoComissaoDto
                //{
                    ClienteEspecial = pessoa.ClienteEspecial,
                    DescontoEspecial = pessoa.DescontoEspecial,
                    PraticarLimiteCredito = pessoa.PraticarLimiteCredito,
                    LimiteCredito = pessoa.LimiteCredito,
                    PraticarInadimplencia = pessoa.PraticarInadimplencia,
                    DiasTolerancia = pessoa.DiasTolerancia,
                    ClienteBloqueado = pessoa.ClienteBloqueado,
                    JustificativaBloqueado = pessoa.JustificativaBloqueado,
                    ClienteSuspenso = pessoa.ClienteSuspenso,
                    JustificativaSuspenso = pessoa.JustificativaSuspenso,
                    ComissaoRepresentante = pessoa.ComissaoRepresentante,
                    ClienteNaoFlutuante = pessoa.ClienteNaoFlutuante,
                    ExigeInspecaoAgucada = pessoa.ExigeInspecaoAgucada,
                    NaoExigirNumeroPedido = pessoa.NaoExigirNumeroPedido,
                //},
                AnaliseCredito = pessoa.AnaliseCreditos!.Select(a => new AnaliseCreditoFilterDto
                {   DataConsulta = a.DataConsulta,
                    OrgaoConsulta = a.OrgaoConsulta,
                    ResponsavelConsulta = new PadraoIdDescricaoFilterDto
                    {
                        Id = a.IdResponsavelConsulta,
                        Descricao = a.ResponsavelConsulta!.RazaoSocial,
                    },
                    Observacao = a.Observacao
                }).ToList(),
                UserName = new UsuarioPessoaDto
                {
                    Nome = pessoa.Usuarios?.UserName ?? string.Empty,
                    Senha = "***"
                },
                Permissao = pessoa.Usuarios != null
                    ? pessoa.Usuarios.RelacionaUsuarioFuncionalidadeNivelAcesso!
                        .GroupBy(rufn => rufn.IdFuncionalidade) // Agrupar por IdFuncionalidade
                        .Select(grupo => new PessoaFuncionalidadeDto
                        {
                            IdFuncionalidade = grupo.Key, // O Id da funcionalidade
                            NivelAcesso = grupo
                                .Where(rufn => rufn.IdNivelAcesso != null) // Apenas onde existe IdNivelAcesso
                                .Select(rufn => new PessoaNivelAcessoDto
                                {
                                    IdNivelAcesso = rufn.IdNivelAcesso
                                }).ToList()
                        }).ToList()
                    : new List<PessoaFuncionalidadeDto>(),
                DataAlteracao = pessoa.UpdateAt
            };
        }

        public List<PessoaFuncionalidadeDto?> GetPessoaFuncionalidade(Guid idPessoa)
        {
            var pessoa = _dbContext.Pessoa.Include(u => u.Usuarios).ThenInclude(p => p.RelacionaUsuarioFuncionalidadeNivelAcesso)
            .AsNoTracking()
            .Where(x => x.Id.Equals(idPessoa))
            .FirstOrDefault();

            if (pessoa != null)
            {
                return pessoa.Usuarios.RelacionaUsuarioFuncionalidadeNivelAcesso!
                        .Select(rufn => new PessoaFuncionalidadeDto
                        {
                            IdFuncionalidade = rufn.IdFuncionalidade
                        }).ToList();
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarOrigemPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Origem.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarRegiaoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Regiao.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSegmentoClientePaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.SegmentoCliente.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSegmentoEstrategicoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.SegmentoEstrategico.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarDepartamentoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Departamento.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarCargoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Cargo.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarRegiaoPorId(Guid id)
        {
            var regiao = await _dbContext.Regiao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (regiao != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = regiao.Id,
                    Descricao = regiao.Nome,
                };
            }

            return null;
        }
        public async Task<PadraoIdDescricaoFilterDto?> RetornarOrigemPorId(Guid id)
        {
            var origem = await _dbContext.Origem
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (origem != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = origem.Id,
                    Descricao = origem.Descricao,
                };
            }

            return null;
        }
        public async Task<PadraoIdDescricaoFilterDto?> RetornarSegmentoClientePorId(Guid id)
        {
            var segmentocliente = await _dbContext.SegmentoCliente
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (segmentocliente != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = segmentocliente.Id,
                    Descricao = segmentocliente.Descricao,
                };
            }

            return null;
        }
        public async Task<PadraoIdDescricaoFilterDto?> RetornarSegmentoEstrategicoPorId(Guid id)
        {
            var segmentoestrategico = await _dbContext.SegmentoEstrategico
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (segmentoestrategico != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = segmentoestrategico.Id,
                    Descricao = segmentoestrategico.Descricao,
                };
            }

            return null;
        }
        public async Task<PadraoIdDescricaoFilterDto?> RetornarDepartamentoPorId(Guid id)
        {
            var departamento = await _dbContext.Departamento
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (departamento != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = departamento.Id,
                    Descricao = departamento.Nome,
                };
            }

            return null;
        }
        public async Task<PadraoIdDescricaoFilterDto?> RetornarCargoPorId(Guid id)
        {
            var cargo = await _dbContext.Cargo
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (cargo != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = cargo.Id,
                    Descricao = cargo.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<TipoConsumidorFilterDto>> RetornarTipoConsumidorPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.TipoConsumidor.AsNoTracking();

            var data = query.Select(x => new TipoConsumidorFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
            });

            var response = await data.RetonarFiltroCustomizado<TipoConsumidorFilterDto, TipoConsumidorFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<TipoConsumidorByCodeDto?> RetornarTipoConsumidorPorId(Guid id)
        {
            var TipoConsumidor = await _dbContext.TipoConsumidor
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (TipoConsumidor != null)
            {
                return new TipoConsumidorByCodeDto
                {
                    Id = TipoConsumidor.Id,
                    Nome = TipoConsumidor.Nome,
                    Descricao = TipoConsumidor.Descricao,
                    SomaItens = TipoConsumidor.SomaItens,
                    SomaDespesasBaseIcms = TipoConsumidor.SomaDespesasBaseIcms,
                    SomaIpiBaseIcms = TipoConsumidor.SomaIpiBaseIcms,
                    SomaDespesasBaseSt = TipoConsumidor.SomaDespesasBaseSt,
                    SomaIpiBaseSt = TipoConsumidor.SomaIpiBaseSt,
                    SomaStBaseIcms = TipoConsumidor.SomaStBaseIcms,
                    Difal = TipoConsumidor.Difal,
                    SubstituicaoIcms = TipoConsumidor.SubstituicaoIcms,
                };
            }

            return null;
        }
    }
}

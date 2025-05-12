using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Empresas.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Empresas;
using SharedKernel.Configuration.Extensions;
using Application.Interfaces.Queries;
using Application.DTOs.Pessoas;

namespace Infra.Queries.Empresas
{
    public class EmpresaQuery : IEmpresaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public EmpresaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<EmpresaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Empresa.AsNoTracking();

            var data = query.Select(x => new EmpresaFilterDto
            {
                Id = x.Id,
                CpfCnpj = x.CpfCnpj,
                RazaoSocial = x.RazaoSocial
            });

            var response = await data.RetonarFiltroCustomizado<EmpresaFilterDto, EmpresaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<EmpresaByCodeDto?> RetornarPorId(Guid id)
        {
            var Empresa = await _dbContext.Empresa
            .AsNoTracking()
            .Include(ee => ee.RelacionaEmpresaSocio)
            .Include(ee => ee.RelacionaEmpresaFaturaParametro)
            .Include(ee => ee.Endereco)
            .Include(ee => ee.Email)
            .Include(ee => ee.Telefone)
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Empresa != null)
            {
                return new EmpresaByCodeDto
                {
                    Id = Empresa.Id,
                    Socios = Empresa.RelacionaEmpresaSocio!.Select(item => new SocioDto
                    {
                        IdSocio = item.IdSocio,
                    }).ToList(),
                    CpfCnpj = Empresa.CpfCnpj,
                    InscricaoEstadual = Empresa.InscricaoEstadual,
                    InscricaoSuframa = Empresa.InscricaoSuframa,
                    RazaoSocial = Empresa.RazaoSocial,
                    NomeFantasia = Empresa.NomeFantasia,
                    IdRegimeTributario = Empresa.IdRegimeTributario,
                    IdEndereco = Empresa.IdEndereco,
                    Endereco = Empresa.Endereco != null
                        ? new EnderecoDto
                        {
                            IdTipoEndereco = Empresa.Endereco.IdTipoEndereco,
                            EnderecoDescricao = Empresa.Endereco.EnderecoDescricao,
                            Numero = Empresa.Endereco.Numero,
                            Complemento = Empresa.Endereco.Complemento,
                            IdCidade = Empresa.Endereco.IdCidade,
                            Bairro = Empresa.Endereco.Bairro,
                            IdUf = Empresa.Endereco.IdUf,
                            Cep = Empresa.Endereco.Cep,
                        }
                        : null,
                    IdEmail = Empresa.IdEmail,
                    Email = Empresa.Email != null
                        ? new EmailDto
                        {
                            IdTipoEmail = Empresa.Email.IdTipoEmail,
                            EnderecoEmail = Empresa.Email.EnderecoEmail
                        }
                        : null,
                    IdTelefone = Empresa.IdTelefone,
                    Telefone = Empresa.Telefone != null
                        ? new TelefoneDto
                        {
                            IdTipoTelefone = Empresa.Telefone.IdTipoTelefone,
                            Numero = Empresa.Telefone.Numero
                        }
                        : null,
                    ParametroFatura = Empresa.RelacionaEmpresaFaturaParametro!.Select(item => new ParametroFaturaDto
                    {
                        IdFaturaParametro = item.IdFaturaParametro,
                    }).ToList(),
                };
            }


            return null;
        }       
    }
}
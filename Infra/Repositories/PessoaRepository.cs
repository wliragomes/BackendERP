using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;
using System.Text.RegularExpressions;

namespace Infra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PessoaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Pessoa pessoa)
        {
            await _contexto.Pessoa.AddAsync(pessoa);
        }

        public async Task<Pessoa?> ObterPorId(Guid? id)
        {
            return await _contexto.Pessoa.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Pessoa.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteCpfCnpjAsync(string? cpfCnpj)
        {
            cpfCnpj = Regex.Replace(cpfCnpj, "[^0-9]", "");
            return await _contexto.Pessoa.AnyAsync(x => x.CnpjCpf == cpfCnpj);
        }

        public async Task<bool> ExisteCodigoAsync(string codigo, Guid? id)
        {
            //return await _contexto.Pessoa.AnyAsync(x => x.Codigo == codigo && x.Id != id);
            return default;
        }

        public async Task<bool> ExisteNomeAsync(string razaoSocial, Guid? id)
        {
            return await _contexto.Pessoa.AnyAsync(x => x.RazaoSocial == razaoSocial && x.Id != id);
        }


        public Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo()
        {
            return async (uow, codigo, id) => await ExisteCodigoAsync(codigo, id);
        }

        public async Task AdicionarEmMassa(List<Pessoa> pessoas, CancellationToken cancellationToken = default)
        {
            await _contexto.Pessoa.AddRangeAsync(pessoas, cancellationToken);
        }

        public async Task<List<Pessoa>> RetornarPessoasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Pessoa;
            var query = FiltroBuilder<Pessoa>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}

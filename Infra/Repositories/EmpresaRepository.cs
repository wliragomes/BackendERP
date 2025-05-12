using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public EmpresaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Empresa empresa)
        {
            await _contexto.Empresa.AddAsync(empresa);
        }

        public async Task<Empresa?> ObterPorId(Guid? id)
        {
            return await _contexto.Empresa.FindAsync(id);
        }

        public async Task<Guid> GetEmpresaPadrao()
        {
            var empresa = await _contexto.Empresa
                .Where(e => e.CpfCnpj == "20.382.746/0001-14")
                .Select(e => e.Id)
                .FirstOrDefaultAsync();

            return empresa;
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Empresa.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteCpfCnpjAsync(string cpfcnpj, Guid? id)
        {
            return await _contexto.Empresa.AnyAsync(x => x.CpfCnpj == cpfcnpj && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Empresa> empresas, CancellationToken cancellationToken = default)
        {
            await _contexto.Empresa.AddRangeAsync(empresas, cancellationToken);
        }

        public async Task<List<Empresa>> RetornarEmpresasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Empresa;
            var query = FiltroBuilder<Empresa>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
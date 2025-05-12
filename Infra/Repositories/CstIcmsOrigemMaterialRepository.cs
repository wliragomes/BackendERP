using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CstIcmsOrigemMaterialRepository : ICstIcmsOrigemMaterialRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CstIcmsOrigemMaterialRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(CstIcmsOrigemMaterial cst_icms_origem_material)
        {
            await _contexto.CST_ICMS_Origem_Material.AddAsync(cst_icms_origem_material);
        }

        public async Task<CstIcmsOrigemMaterial?> ObterPorId(Guid? id)
        {
            return await _contexto.CST_ICMS_Origem_Material.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.CST_ICMS_Origem_Material.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.CST_ICMS_Origem_Material.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<CstIcmsOrigemMaterial> cst_icms_origem_materials, CancellationToken cancellationToken = default)
        {
            await _contexto.CST_ICMS_Origem_Material.AddRangeAsync(cst_icms_origem_materials, cancellationToken);
        }

        public async Task<List<CstIcmsOrigemMaterial>> RetornarCST_ICMS_Origem_MaterialsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.CST_ICMS_Origem_Material;
            var query = FiltroBuilder<CstIcmsOrigemMaterial>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
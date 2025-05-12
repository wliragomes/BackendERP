using Domain.Commands.PlanosDeContas.Adicionar;
using Domain.Commands.PlanosDeContas.Atualizar;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class PlanoDeContasRepository : IPlanoDeContasRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PlanoDeContasRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(PlanoDeContas planoDeContas)
        {
            await _contexto.PlanoDeContas.AddAsync(planoDeContas);
        }

        public async Task<PlanoDeContas?> ObterPorId(Guid? id)
        {
            return await _contexto.PlanoDeContas.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.PlanoDeContas.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistePlanoDeContaAsync(string planoDeContasCompleto, Guid? id)
        {
            return await _contexto.PlanoDeContas.AnyAsync(x => x.PlanoDeContasCompleto == planoDeContasCompleto && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<PlanoDeContas> planosDeContas, CancellationToken cancellationToken = default)
        {
            await _contexto.PlanoDeContas.AddRangeAsync(planosDeContas, cancellationToken);
        }

        public async Task<List<PlanoDeContas>> RetornarPlanosDeContasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.PlanoDeContas;
            var query = FiltroBuilder<PlanoDeContas>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<PlanoDeContas> RetornarValidacao(AdicionarPlanoDeContasCommand command)
        {
            var query = await _contexto.PlanoDeContas.Where(x => x.Nivel == command.Nivel &&
                                            (command.Nivel >= 1 ? x.ContaPrincipal == command.ContaPrincipal : x.ContaPrincipal == 0) &&
                                            (command.Nivel >= 2 ? x.SubGrupo == command.SubGrupo : x.SubGrupo == 0) &&
                                            (command.Nivel >= 3 ? x.Analitico == command.Analitico : x.Analitico == 0) &&
                                            (command.Nivel >= 4 ? x.AnaliticoDetalhado == command.AnaliticoDetalhado : x.AnaliticoDetalhado == 0) &&
                                            (command.Nivel >= 5 ? x.Especifico == command.Especifico : x.Especifico == 0))

                    .GroupBy(p => 1) // truque pra usar agregação sem precisar de cláusula WHERE
                    .Select(g => new PlanoDeContas
                    {
                        ContaPrincipal = g.Max(x => x.ContaPrincipal),
                        SubGrupo = g.Max(x => x.SubGrupo),
                        Analitico = g.Max(x => x.Analitico),
                        AnaliticoDetalhado = g.Max(x => x.AnaliticoDetalhado),
                        Especifico = g.Max(x => x.Especifico),
                    }).FirstOrDefaultAsync();

            return query;
        }

        public async Task<PlanoDeContas> RetornarValidacao(AtualizarPlanoDeContasCommand command)
        {
            var query = await _contexto.PlanoDeContas.Where(x => x.Nivel == command.Nivel &&
                                            (command.Nivel >= 1 ? x.ContaPrincipal == command.ContaPrincipal : x.ContaPrincipal == 0) &&
                                            (command.Nivel >= 2 ? x.SubGrupo == command.SubGrupo : x.SubGrupo == 0) &&
                                            (command.Nivel >= 3 ? x.Analitico == command.Analitico : x.Analitico == 0) &&
                                            (command.Nivel >= 4 ? x.AnaliticoDetalhado == command.AnaliticoDetalhado : x.AnaliticoDetalhado == 0) &&
                                            (command.Nivel >= 5 ? x.Especifico == command.Especifico : x.Especifico == 0))

                    .GroupBy(p => 1) // truque pra usar agregação sem precisar de cláusula WHERE
                    .Select(g => new PlanoDeContas
                    {
                        ContaPrincipal = g.Max(x => x.ContaPrincipal),
                        SubGrupo = g.Max(x => x.SubGrupo),
                        Analitico = g.Max(x => x.Analitico),
                        AnaliticoDetalhado = g.Max(x => x.AnaliticoDetalhado),
                        Especifico = g.Max(x => x.Especifico),
                    }).FirstOrDefaultAsync();

            return query;
        }
    }
}
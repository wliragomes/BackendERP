using SharedKernel.SharedObjects;
using System.Linq.Expressions;
using System.Reflection;

namespace SharedKernel.Data
{
    public static class FiltroBuilder<TEntity> where TEntity : class
    {
        private const string _STATUS_ACTIVE = "ativo";
        private const string _STATUS_INACTIVE = "inativo";

        public static IQueryable<TEntity> ConstruirQuery(IQueryable<TEntity> query, FiltroBase excluirOpcoes)
        {
            if (excluirOpcoes.PropriedadesValoresNulos())
            {
                throw new DomainException("Os valores de filtros e ids não podem ser nulos");
            }
            Expression<Func<TEntity, bool>> filtroExpression = CreateFilterExpression(excluirOpcoes);

            if (excluirOpcoes.IdsSelecionados!.Any())
            {
                var IdsSelecionados = excluirOpcoes.IdsSelecionados!;
                var IdsSelecionadosPredicate = BuildIdPredicate<TEntity>(IdsSelecionados);
                filtroExpression = CombineExpressions(filtroExpression, IdsSelecionadosPredicate);
            }
            else if (excluirOpcoes.IdsNaoSelecionados!.Any())
            {
                var IdsNaoSelecionados = excluirOpcoes.IdsNaoSelecionados!;
                var IdsNaoSelecionadosPredicate = BuildIdPredicate<TEntity>(IdsNaoSelecionados);
                filtroExpression = CombineExpressions(filtroExpression, Expression.Lambda<Func<TEntity, bool>>(Expression.Not(IdsNaoSelecionadosPredicate.Body), IdsNaoSelecionadosPredicate.Parameters));
            }

            return query.Where(filtroExpression);
        }

        private static Expression<Func<TEntity, bool>> CombineExpressions(Expression<Func<TEntity, bool>> expressao1, Expression<Func<TEntity, bool>> expressao2)
        {
            var parameter = Expression.Parameter(typeof(TEntity));

            var leftVisitor = new ReplaceExpressionVisitor(expressao1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expressao1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expressao2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expressao2.Body);

            return Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(left, right), parameter);
        }

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _anteriorExpression;
            private readonly Expression _novaExpression;

            public ReplaceExpressionVisitor(Expression anteriorExpression, Expression novaExpression)
            {
                _anteriorExpression = anteriorExpression;
                _novaExpression = novaExpression;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _anteriorExpression)
                    return _novaExpression;
                return base.Visit(node);
            }
        }

        private static Expression<Func<TEntity, bool>> CreateFilterExpression(FiltroBase excluirOpcoes)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var filterColumns = excluirOpcoes.FiltrarPor?.Split(',').Select(x => x.Trim()).ToArray();

            var filterExpressions = CreateFilterExpressions(filterColumns, excluirOpcoes, parameter);

            return CreateFinalFilterExpression(excluirOpcoes, filterExpressions, parameter);
        }

        private static List<Expression> CreateFilterExpressions(string[]? colunaFiltro, FiltroBase excluirOpcoes, ParameterExpression parametro)
        {
            var filtroExpressions = new List<Expression>();

            if (colunaFiltro == null || !colunaFiltro.Any())
                return filtroExpressions;

            foreach (var coluna in colunaFiltro)
            {
                var propriedadeColuna = coluna.Split('.');
                var propriedadeExpression = GetPropertyExpression(parametro, propriedadeColuna);

                if (propriedadeExpression == null)
                    throw new DomainException("O formulário não foi preenchido corretamente.");

                var valorFiltro = excluirOpcoes.ValorFiltro;

                if (propriedadeColuna.Contains(_STATUS_ACTIVE) || propriedadeColuna.Contains(_STATUS_INACTIVE))
                {
                    var boolExpression = CreateBoolExpression(coluna, propriedadeExpression);
                    filtroExpressions.Add(boolExpression);
                }
                else if (!string.IsNullOrWhiteSpace(valorFiltro))
                {
                    var comparacaoExpression = CreateComparisonExpression(propriedadeExpression, valorFiltro);
                    if (comparacaoExpression != null)
                        filtroExpressions.Add(comparacaoExpression);
                }
            }

            return filtroExpressions;
        }

        private static MemberExpression? GetPropertyExpression(Expression parameter, string[] properties)
        {
            MemberExpression? propriedadeExpression = null;

            foreach (var property in properties)
            {
                var informacaoPropriedade = GetPropertyInfo(propriedadeExpression?.Type ?? typeof(TEntity), property);

                if (informacaoPropriedade != null)
                {
                    propriedadeExpression = Expression.Property(propriedadeExpression ?? parameter, informacaoPropriedade);
                }
                else
                {
                    return null;
                }
            }

            return propriedadeExpression;
        }

        private static PropertyInfo? GetPropertyInfo(Type tipo, string nomePropriedade)
        {
            var column = GetPropertyEntity(nomePropriedade);
            return tipo
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                .FirstOrDefault(p => string.Equals(p.Name, column, StringComparison.OrdinalIgnoreCase));
        }

        private static string GetPropertyEntity(string coluna)
        {
            if (coluna == _STATUS_ACTIVE || coluna == _STATUS_INACTIVE)
                return _STATUS_ACTIVE;

            return coluna.Trim();
        }

        private static Expression CreateBoolExpression(string coluna, MemberExpression propriedade)
        {
            var boolValue = coluna.ToLower() != _STATUS_INACTIVE;
            return Expression.Equal(propriedade, Expression.Constant(boolValue));
        }

        private static Expression? CreateComparisonExpression(MemberExpression propriedade, string valorFiltro)
        {
            switch (propriedade.Type.Name)
            {
                case nameof(String):
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    return Expression.Call(propriedade, containsMethod!, Expression.Constant(valorFiltro));

                case nameof(DateTime):
                    DateTime dateValue;
                    if (DateTime.TryParse(valorFiltro, out dateValue))
                    {
                        return Expression.Equal(propriedade, Expression.Constant(dateValue));
                    }
                    break;

                case nameof(Decimal):
                    Decimal decimalValue;
                    if (Decimal.TryParse(valorFiltro, out decimalValue))
                    {
                        return Expression.Equal(propriedade, Expression.Constant(decimalValue));
                    }
                    break;

                case nameof(Int32):
                    int intValue;
                    if (int.TryParse(valorFiltro, out intValue))
                    {
                        return Expression.Equal(propriedade, Expression.Constant(intValue));
                    }
                    break;

                case nameof(Boolean):
                    bool boolValue;
                    if (bool.TryParse(valorFiltro, out boolValue))
                    {
                        return Expression.Equal(propriedade, Expression.Constant(boolValue));
                    }
                    break;
            }

            return null;
        }

        private static Expression<Func<TEntity, bool>> CreateFinalFilterExpression(FiltroBase excluirOpcoes, List<Expression> filtroExpressions, ParameterExpression parametro)
        {
            if (filtroExpressions.Any())
            {
                var statusActiveExpressions = filtroExpressions.Where(e => IsStatusActiveExpression(e)).ToList();
                filtroExpressions = filtroExpressions.Except(statusActiveExpressions).ToList();

                var orExpression = filtroExpressions.Any() ? filtroExpressions.Aggregate(Expression.Or) : null;

                var andExpression = statusActiveExpressions.Any() ? statusActiveExpressions.Aggregate(Expression.And) : null;

                var finalExpression = orExpression != null && andExpression != null ? Expression.And(orExpression, andExpression) : orExpression ?? andExpression;

                return Expression.Lambda<Func<TEntity, bool>>(finalExpression, parametro);
            }

            if (excluirOpcoes.ValorFiltro is not null)
                throw new DomainException("ValorFiltro não pode ser nulo ou vazio");

            return entity => true;
        }

        private static bool IsStatusActiveExpression(Expression expression)
        {
            if (expression.NodeType == ExpressionType.Equal)
                return true;
            return false;
        }

        private static bool PropertyExists(string nomePropriedade)
        {
            return typeof(TEntity).GetProperty(nomePropriedade, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }

        private static Expression<Func<TEntity, bool>> BuildIdPredicate<TEntity>(List<Guid> ids)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var idProperty = Expression.Property(parameter, "Id");

            var constantIds = ids.Select(id => Expression.Constant(id));
            var containsMethod = typeof(Enumerable).GetMethods()
                .Single(m => m.Name == "Contains" && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(Guid));

            var body = Expression.Call(null, containsMethod, Expression.Constant(ids), idProperty);
            return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
        }        
    }
}

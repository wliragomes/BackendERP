using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using SharedKernel.Utils.Constants;
using SharedKernel.Utils;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SharedKernel.SharedMethods;

namespace SharedKernel.Configuration.Extensions
{
    public static class QueryExtensionBase
    {
        public static async Task<PaginacaoResponse<T>> RetonarFiltroCustomizado<TEntity, T>(this IQueryable<TEntity> query, PaginacaoRequest paginationRequest) where TEntity : class, new()
        {
            paginationRequest.ValorFiltro = RemoveMascaraCpfCnpj(paginationRequest.ValorFiltro ?? "");
            var totalRecords = query.Count();
            query = query.SearchIdsIfExists(paginationRequest);
            var skip = paginationRequest.ReturnSkip() ?? ValoresPadroesPaginacao.NumeroPaginaPadrao;
            var take = paginationRequest.TamanhoPagina ?? ValoresPadroesPaginacao.TamanhoPaginaPadrao;
            var pagedQueryable = query.CustomSearch(paginationRequest);

            var customSelect = CustomSelect<TEntity, T>();

            var response = await pagedQueryable.queryable
                        .Select(customSelect)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();

            var paginationResponse = new PaginacaoResponse<T>();
            paginationResponse.AddPagination(paginationRequest.NumeroPagina, paginationRequest.TamanhoPagina, totalRecords, pagedQueryable.filteredCount);
            paginationResponse.AddOrder(paginationRequest.OrdenarPor, paginationRequest.DirecaoOrdenacao);
            paginationResponse.AddFilter(paginationRequest.FiltrarPor, paginationRequest.ValorFiltro);
            if (response.Any())
                paginationResponse.AddData(response);
            return paginationResponse;
        }

        public static async Task<PaginacaoResponse<T>> RetonarFiltroCustomizado<TEntity, T>(this IEnumerable<TEntity> query, PaginacaoRequest paginationRequest) where TEntity : class, new()
        {
            paginationRequest.ValorFiltro = RemoveMascaraCpfCnpj(paginationRequest.ValorFiltro ?? "");
            var totalRecords = query.Count();
            query = query.SearchIdsIfExists(paginationRequest);
            var skip = paginationRequest.ReturnSkip() ?? ValoresPadroesPaginacao.NumeroPaginaPadrao;
            var take = paginationRequest.TamanhoPagina ?? ValoresPadroesPaginacao.TamanhoPaginaPadrao;
            var pagedQueryable = query.CustomSearch(paginationRequest);

            var customSelect = CustomSelect<TEntity, T>();

            List<T> response = pagedQueryable.queryable.AsQueryable()
                        .Select(customSelect)
                        .Skip(skip)
                        .Take(take)
                        .ToList();

            var paginationResponse = new PaginacaoResponse<T>();
            paginationResponse.AddPagination(paginationRequest.NumeroPagina, paginationRequest.TamanhoPagina, totalRecords, pagedQueryable.filteredCount);
            paginationResponse.AddOrder(paginationRequest.OrdenarPor, paginationRequest.DirecaoOrdenacao);
            paginationResponse.AddFilter(paginationRequest.FiltrarPor, paginationRequest.ValorFiltro);
            if (response.Any())
                paginationResponse.AddData(response);
            return paginationResponse;
        }

        public static async Task<PaginacaoResponse<T>> GetCustomFilterSync<TEntity, T>(this IQueryable<TEntity> query, PaginacaoRequest paginationRequest) where TEntity : class, new()
        {
            var totalRecords = query.Count();
            query = query.SearchIdsIfExists(paginationRequest);
            var skip = paginationRequest.ReturnSkip() ?? ValoresPadroesPaginacao.NumeroPaginaPadrao;
            var take = paginationRequest.TamanhoPagina ?? ValoresPadroesPaginacao.TamanhoPaginaPadrao;
            var pagedQueryable = query.CustomSearchByIndexOf(paginationRequest);

            var customSelect = CustomSelect<TEntity, T>();

            var response = pagedQueryable.queryable
                .Select(customSelect)
                .Skip(skip)
                .Take(take)
                .ToList();

            var paginationResponse = new PaginacaoResponse<T>();
            paginationResponse.AddPagination(paginationRequest.NumeroPagina, paginationRequest.TamanhoPagina, totalRecords, pagedQueryable.filteredCount);
            paginationResponse.AddOrder(paginationRequest.OrdenarPor, paginationRequest.DirecaoOrdenacao);
            paginationResponse.AddFilter(paginationRequest.FiltrarPor, paginationRequest.ValorFiltro);

            if (response.Any())
                paginationResponse.AddData(response);
            return paginationResponse;
        }

        public static async Task<PaginacaoResponse<TEntity>> GetCustomFilter<TEntity>(this IQueryable<TEntity> query, PaginacaoRequest paginationRequest) where TEntity : class, new()
        {
            var totalRecords = query.Count();
            query = query.SearchIdsIfExists(paginationRequest);
            var skip = paginationRequest.ReturnSkip() ?? ValoresPadroesPaginacao.NumeroPaginaPadrao;
            var take = paginationRequest.TamanhoPagina ?? ValoresPadroesPaginacao.TamanhoPaginaPadrao;
            var pagedQueryable = query.CustomSearch(paginationRequest);

            var response = await pagedQueryable.queryable
                .Skip(skip)
                .Take(take).ToListAsync();

            var paginationResponse = new PaginacaoResponse<TEntity>();
            paginationResponse.AddPagination(paginationRequest.NumeroPagina, paginationRequest.TamanhoPagina, totalRecords, pagedQueryable.filteredCount);
            paginationResponse.AddOrder(paginationRequest.OrdenarPor, paginationRequest.DirecaoOrdenacao);
            paginationResponse.AddFilter(paginationRequest.FiltrarPor, paginationRequest.ValorFiltro);
            paginationResponse.AddData(response);
            return paginationResponse;
        }

        private static Expression<Func<T, TSelect>> CustomSelect<T, TSelect>()
        {
            var EntityFields = typeof(TSelect).GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray();
            var xParameter = Expression.Parameter(typeof(T), "x");
            var DeclarationNew = Expression.New(typeof(TSelect));

            var bindings = EntityFields
                .Select(x =>
                {
                    string[] fieldAlias = x.Split(":");
                    string field = fieldAlias[0];

                    string[] fieldSplit = field.Split(".");
                    if (fieldSplit.Length > 1)
                    {
                        Expression expression = xParameter;
                        foreach (string fieldItem in fieldSplit)
                            expression = Expression.PropertyOrField(expression, fieldItem);

                        PropertyInfo? memberTwo = null;
                        if (fieldAlias.Length > 1)
                            memberTwo = typeof(TSelect).GetProperty(fieldAlias[1])!;
                        else
                            memberTwo = typeof(T).GetProperty(fieldSplit[fieldSplit.Length - 1])!;

                        var response = Expression.Bind(memberTwo, expression);
                        return response;
                    }
                    var property = typeof(T).GetProperty(field);
                    if (property == null) return null;
                    PropertyInfo member;
                    if (fieldAlias.Length > 1)
                        member = typeof(TSelect).GetProperty(fieldAlias[1])!;
                    else member = typeof(TSelect).GetProperty(field)!;
                    var original = Expression.Property(xParameter, property);
                    return Expression.Bind(member, original);
                }
            );

            var xInit = Expression.MemberInit(DeclarationNew, bindings.Where(x => x != null)!);
            var lambda = Expression.Lambda<Func<T, TSelect>>(xInit, xParameter);

            return lambda;
        }

        private static (IQueryable<T> queryable, int filteredCount) CustomSearch<T>(this IQueryable<T> query, PaginacaoRequest paginationRequest) where T : class, new()
        {
            var pattern = new Regex("[*%]");
            string searchText = pattern.Replace(paginationRequest.ValorFiltro
                ?? "", "");
            var parameterX = Expression.Parameter(typeof(T), PaginacaoConstants.ParametroX);
            Expression? completeExpression = null;
            Expression<Func<T, bool>>? expression = null;

            var filtersBy = paginationRequest.FiltrarPor!.Trim().ToLower().Split(',').Select(x => x.Trim()).ToList();
            var allProperties = GetEntityProperties(new T()).ToList();

            var entityFields = GetEntityProperties(new T())
                .Where(x => x.PropertyType == typeof(string) || x.PropertyType == typeof(bool) || x.PropertyType.IsEnum)
                .Select(propertyInfo => new
                {
                    Name = propertyInfo.ReflectedType == typeof(T) ?
                                                     propertyInfo.Name.ToLower() :
                                                     $"{allProperties.Where(x => x.PropertyType == propertyInfo.ReflectedType)
                                                                  .FirstOrDefault()?.Name}{(propertyInfo.Name != "Value" ? $".{propertyInfo.Name}" : string.Empty)}".ToLower(),
                    propertyInfo.PropertyType
                })
                .ToList();

            if (filtersBy.Any())
            {
                foreach (var filterBy in filtersBy)
                {
                    var existFieldString = entityFields.Where(x => (x.Name == filterBy || filterBy.Contains(x.Name)) && x.PropertyType == typeof(string)).FirstOrDefault();
                    if (existFieldString is not null && !searchText.IsNullOrEmptyOrWhiteSpace())
                    {
                        var leftSideExpression = filterBy.Split('.').Aggregate((Expression)parameterX, Expression.Property);
                        var rightSideExpression = Expression.Constant(searchText, typeof(string));

                        if (completeExpression is null)
                        {
                            completeExpression = Expression.Call(leftSideExpression, PaginacaoConstants.MetodoContem, Type.EmptyTypes, Expression.Constant(searchText));
                        }
                        else
                        {
                            completeExpression = Expression.OrElse(Expression.Call(leftSideExpression, PaginacaoConstants.MetodoContem, Type.EmptyTypes, Expression.Constant(searchText)), completeExpression);
                        }
                    }

                    var existFieldEnum = entityFields.Where(x =>
                        (x.Name == filterBy || filterBy.Contains(x.Name)) &&
                         x.PropertyType.IsEnum).FirstOrDefault();
                    if (existFieldEnum is not null && !searchText.IsNullOrEmptyOrWhiteSpace())
                    {
                        var leftSideExpression = filterBy.Split('.').Aggregate((Expression)parameterX, Expression.Property);
                        var assembly = Assembly.Load("Domain");
                        var type = assembly.GetType(existFieldEnum.PropertyType.FullName);
                        var nullableType = typeof(Nullable<>).MakeGenericType(type);
                        object enumValue;

                        if (!Enum.TryParse(type, searchText, out enumValue))
                            continue;

                        var rightSideExpression = Expression.Constant(enumValue, type);

                        if (completeExpression is null)
                        {
                            completeExpression = Expression.Equal(leftSideExpression, rightSideExpression);
                        }
                        else
                        {
                            completeExpression = Expression.OrElse(Expression.Equal(leftSideExpression, rightSideExpression), completeExpression);
                        }
                    }
                }

                completeExpression = CreateExpressionStatusActive(filtersBy, completeExpression, parameterX);
            }

            if (entityFields.Any(x => x.Name == PaginacaoConstants.ParametroRemovido))
            {
                if (completeExpression is null)
                {
                    completeExpression = Expression.Equal(PaginacaoConstants.ParametroRemovido.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(false));
                }
                else
                {
                    completeExpression = Expression.And(completeExpression, Expression.Equal(PaginacaoConstants.ParametroRemovido.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(false)));
                }
            }

            if (entityFields.Any(x => x.Name == PaginacaoConstants.ParametroVigencia.ToLower()))
            {
                completeExpression = CreateExpressionFilterByEffectiveDate(filtersBy, completeExpression, parameterX);
            }

            if (completeExpression is not null)
            {
                expression = Expression.Lambda<Func<T, bool>>(completeExpression, parameterX);
                if (expression is not null && paginationRequest.TipoSelecao != PaginacaoConstants.SelecaoTipoNenhum)
                    query = query.Where(expression);
            }

            if (paginationRequest.TipoSelecao == PaginacaoConstants.SelecaoTipoNenhum)
            {
                query = query.Where(x => false).Take(0);
                return (query, query.Count());
            }

            query = query.OrderByCustom(paginationRequest);
            return (query, query.Count());
        }

        private static (IEnumerable<T> queryable, int filteredCount) CustomSearch<T>(this IEnumerable<T> query, PaginacaoRequest paginationRequest) where T : class, new()
        {
            var pattern = new Regex("[*%]");
            string searchText = pattern.Replace(paginationRequest.ValorFiltro
                ?? "", "").ToUpper();
            var parameterX = Expression.Parameter(typeof(T), PaginacaoConstants.ParametroX);
            Expression? completeExpression = null;
            Expression<Func<T, bool>>? expression = null;

            var filtersBy = paginationRequest.FiltrarPor!.Trim().ToLower().Split(',').Select(x => x.Trim()).ToList();
            var allProperties = GetEntityProperties(new T()).ToList();

            var entityFields = new List<dynamic>();
            var propertyNameAlreadyAdded = new List<string>();
            foreach (var propertyInfo in allProperties.Where(x => x.PropertyType == typeof(string) || x.PropertyType == typeof(bool) || x.PropertyType.IsEnum || x.PropertyType == typeof(Guid)))
            {
                var MainPropertyName = allProperties.FirstOrDefault(x =>
                    x.PropertyType == propertyInfo.ReflectedType && propertyNameAlreadyAdded.Count(s => s.Contains(x.Name)) < 2)?.Name;

                var field = new
                {
                    Name = propertyInfo.ReflectedType == typeof(T)
                        ? propertyInfo.Name.ToLower()
                        : $"{MainPropertyName}{(propertyInfo.Name != "Value" ? $".{propertyInfo.Name}" : string.Empty)}".ToLower(),
                    propertyInfo.PropertyType
                };

                entityFields.Add(field);

                if (propertyInfo.ReflectedType != typeof(T) && !string.IsNullOrEmpty(MainPropertyName))
                    propertyNameAlreadyAdded.Add(MainPropertyName);
            }

            if (filtersBy.Any())
            {
                foreach (var filterBy in filtersBy)
                {
                    var existFieldString = entityFields.Where(x => (x.Name == filterBy || filterBy.Contains(x.Name)) && x.PropertyType == typeof(string)).FirstOrDefault();
                    if (existFieldString is not null && !searchText.IsNullOrEmptyOrWhiteSpace())
                    {
                        var leftSideExpression = filterBy.Split('.').Aggregate((Expression)parameterX, Expression.Property);
                        var rightSideExpression = Expression.Constant(searchText, typeof(string));

                        searchText = RemoverAcentuacao(searchText.ToLower());
                        var parameter = Expression.Parameter(typeof(string), "p");

                        var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                        var removerAcentuacaoMethod = typeof(QueryExtensionBase).GetMethod("RemoverAcentuacao", new[] { typeof(string) });
                        var toLowerCall = Expression.Call(leftSideExpression, toLowerMethod);
                        var removerAcentuacaoCall = Expression.Call(removerAcentuacaoMethod, toLowerCall);
                        var isMatchMethod = typeof(Regex).GetMethod("IsMatch", new[] { typeof(string), typeof(string) });
                        var patternExpression = Expression.Constant(".*" + searchText + ".*");
                        var isMatchCall = Expression.Call(isMatchMethod, removerAcentuacaoCall, patternExpression);
                        if (completeExpression is null)
                        {
                            completeExpression = Expression.Call(isMatchMethod, removerAcentuacaoCall, patternExpression);
                        }
                        else
                        {
                            completeExpression = Expression.OrElse(Expression.Call(isMatchMethod, removerAcentuacaoCall, patternExpression), completeExpression);
                        }
                    }

                    var existFieldEnum = entityFields.Where(x =>
                        (x.Name == filterBy || filterBy.Contains(x.Name)) &&
                         x.PropertyType.IsEnum).FirstOrDefault();
                    if (existFieldEnum is not null && !searchText.IsNullOrEmptyOrWhiteSpace())
                    {
                        var leftSideExpression = filterBy.Split('.').Aggregate((Expression)parameterX, Expression.Property);
                        var assembly = Assembly.Load("Domain");
                        var type = assembly.GetType(existFieldEnum.PropertyType.FullName);
                        var nullableType = typeof(Nullable<>).MakeGenericType(type);
                        object enumValue;

                        if (!Enum.TryParse(type, searchText, out enumValue))
                            continue;

                        var rightSideExpression = Expression.Constant(enumValue, type);

                        if (completeExpression is null)
                        {
                            completeExpression = Expression.Equal(leftSideExpression, rightSideExpression);
                        }
                        else
                        {
                            completeExpression = Expression.OrElse(Expression.Equal(leftSideExpression, rightSideExpression), completeExpression);
                        }
                    }

                    var existFieldGuid = entityFields.Where(x => x.Name == filterBy && x.PropertyType == typeof(Guid)).FirstOrDefault();
                    if (existFieldGuid is not null && !searchText.IsNullOrEmptyOrWhiteSpace())
                    {
                        var leftSideExpression = filterBy.Split('.').Aggregate((Expression)parameterX, Expression.Property);
                        var rightSideExpression = Expression.Constant(Guid.Parse(searchText), typeof(Guid));


                        if (completeExpression is null)
                        {
                            completeExpression = Expression.Equal(leftSideExpression, rightSideExpression);
                        }
                        else
                        {
                            completeExpression = Expression.OrElse(Expression.Equal(leftSideExpression, rightSideExpression), completeExpression);
                        }
                    }
                }

                completeExpression = CreateExpressionStatusActive(filtersBy, completeExpression, parameterX);
            }

            if (entityFields.Any(x => x.Name == PaginacaoConstants.ParametroRemovido))
            {
                if (completeExpression is null)
                {
                    completeExpression = Expression.Equal(PaginacaoConstants.ParametroRemovido.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(false));
                }
                else
                {
                    completeExpression = Expression.And(completeExpression, Expression.Equal(PaginacaoConstants.ParametroRemovido.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(false)));
                }
            }

            if (entityFields.Any(x => x.Name == PaginacaoConstants.ParametroVigencia.ToLower()))
            {
                completeExpression = CreateExpressionFilterByEffectiveDate(filtersBy, completeExpression, parameterX);
            }

            if (completeExpression is not null)
            {
                expression = Expression.Lambda<Func<T, bool>>(completeExpression, parameterX);
                if (expression is not null && paginationRequest.TipoSelecao != PaginacaoConstants.SelecaoTipoNenhum)
                    query = query.AsQueryable().Where(expression);
            }

            if (paginationRequest.TipoSelecao == PaginacaoConstants.SelecaoTipoNenhum)
            {
                query = query.Where(x => false).Take(0);
                return (query, query.Count());
            }

            query = query.OrderByCustom(paginationRequest);
            return (query, query.Count());
        }
        private static (IQueryable<T> queryable, int filteredCount) CustomSearchByIndexOf<T>(this IQueryable<T> query, PaginacaoRequest paginationRequest) where T : class, new()
        {
            var pattern = new Regex("[*%]");
            string searchText = pattern.Replace(paginationRequest.ValorFiltro ?? "", "");
            var parameterX = Expression.Parameter(typeof(T), PaginacaoConstants.ParametroX);
            Expression? completeExpression = null;
            Expression<Func<T, bool>>? expression = null;

            var filtersBy = paginationRequest.FiltrarPor!.Trim().ToLower().Split(',').Select(x => x.Trim()).ToList();
            var allProperties = GetEntityProperties(new T()).ToList();

            var entityFields = GetEntityProperties(new T())
                .Where(x => x.PropertyType == typeof(string) || x.PropertyType == typeof(bool) || x.PropertyType.IsEnum)
                .Select(propertyInfo => new
                {
                    Name = propertyInfo.ReflectedType == typeof(T) ?
                                                     propertyInfo.Name.ToLower() :
                                                     $"{allProperties.Where(x => x.PropertyType == propertyInfo.ReflectedType)
                                                                  .FirstOrDefault()?.Name}{(propertyInfo.Name != "Value" ? $".{propertyInfo.Name}" : string.Empty)}".ToLower(),
                    propertyInfo.PropertyType
                })
                .ToList();

            if (filtersBy.Any())
            {
                foreach (var filterBy in filtersBy)
                {
                    var existFieldString = entityFields.Where(x => (x.Name == filterBy || filterBy.Contains(x.Name)) && x.PropertyType == typeof(string)).FirstOrDefault();
                    if (existFieldString is not null && !searchText.IsNullOrEmptyOrWhiteSpace())
                    {
                        var leftSideExpression = filterBy.Split('.').Aggregate((Expression)parameterX, Expression.Property);
                        var rightSideExpression = Expression.Constant(searchText, typeof(string));

                        var indexOfMethod = typeof(string).GetMethod(PaginacaoConstants.MetodoIniciarEm, new[] { typeof(string), typeof(StringComparison) });
                        var indexOfCall = Expression.Call(leftSideExpression, indexOfMethod, rightSideExpression, Expression.Constant(StringComparison.OrdinalIgnoreCase));
                        var containsExpression = Expression.GreaterThanOrEqual(indexOfCall, Expression.Constant(0));

                        if (completeExpression is null)
                        {
                            completeExpression = containsExpression;
                        }
                        else
                        {
                            completeExpression = Expression.OrElse(containsExpression, completeExpression);
                        }
                    }

                    var existFieldEnum = entityFields.Where(x =>
                        (x.Name == filterBy || filterBy.Contains(x.Name)) &&
                         x.PropertyType.IsEnum).FirstOrDefault();
                    if (existFieldEnum is not null && !searchText.IsNullOrEmptyOrWhiteSpace())
                    {
                        var leftSideExpression = filterBy.Split('.').Aggregate((Expression)parameterX, Expression.Property);
                        var assembly = Assembly.Load("Domain");
                        var type = assembly.GetType(existFieldEnum.PropertyType.FullName);
                        var nullableType = typeof(Nullable<>).MakeGenericType(type);
                        object enumValue;

                        if (!Enum.TryParse(type, searchText, out enumValue))
                            continue;

                        var rightSideExpression = Expression.Constant(enumValue, type);

                        if (completeExpression is null)
                        {
                            completeExpression = Expression.Equal(leftSideExpression, rightSideExpression);
                        }
                        else
                        {
                            completeExpression = Expression.OrElse(Expression.Equal(leftSideExpression, rightSideExpression), completeExpression);
                        }
                    }
                }

                completeExpression = CreateExpressionStatusActive(filtersBy, completeExpression, parameterX);
            }

            if (entityFields.Any(x => x.Name == PaginacaoConstants.ParametroRemovido))
            {
                if (completeExpression is null)
                {
                    completeExpression = Expression.Equal(PaginacaoConstants.ParametroRemovido.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(false));
                }
                else
                {
                    completeExpression = Expression.And(completeExpression, Expression.Equal(PaginacaoConstants.ParametroRemovido.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(false)));
                }
            }

            if (entityFields.Any(x => x.Name == PaginacaoConstants.ParametroVigencia.ToLower()))
            {
                completeExpression = CreateExpressionFilterByEffectiveDate(filtersBy, completeExpression, parameterX);
            }

            if (completeExpression is not null)
            {
                expression = Expression.Lambda<Func<T, bool>>(completeExpression, parameterX);
                if (expression is not null && paginationRequest.TipoSelecao != PaginacaoConstants.SelecaoTipoNenhum)
                    query = query.Where(expression);
            }

            if (paginationRequest.TipoSelecao == PaginacaoConstants.SelecaoTipoNenhum)
            {
                query = query.Where(x => false).Take(0);
                return (query, query.Count());
            }

            query = query.OrderByCustom(paginationRequest);
            return (query, query.Count());
        }


        private static Expression? CreateExpressionStatusActive(IEnumerable<string> filtersBy, Expression? completeExpression, ParameterExpression parameterX)
        {
            if (filtersBy.Contains(PaginacaoConstants.FiltrarPorStatusAtivo.ToLower()))
            {
                var expressionToAdd = Expression.Equal(PaginacaoConstants.FiltrarPorStatusAtivo.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(true));
                completeExpression = completeExpression is null ? expressionToAdd : Expression.And(completeExpression, expressionToAdd);
            }

            if (filtersBy.Contains(PaginacaoConstants.FiltrarPorStatusInativo.ToLower()))
            {
                var expressionToAdd = Expression.Equal(PaginacaoConstants.FiltrarPorStatusAtivo.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(false));
                completeExpression = completeExpression is null ? expressionToAdd : Expression.And(completeExpression, expressionToAdd);
            }

            return completeExpression;
        }

        private static Expression? CreateExpressionFilterByEffectiveDate(IEnumerable<string> filtersBy, Expression? completeExpression, ParameterExpression parameterX)
        {
            if (filtersBy.Contains(PaginacaoConstants.VigenciaAtiva.ToLower()))
            {
                var expressionToAdd = Expression.Equal(PaginacaoConstants.VigenciaAtiva.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(true));
                completeExpression = completeExpression is null ? expressionToAdd : Expression.And(completeExpression, expressionToAdd);
            }

            if (filtersBy.Contains(PaginacaoConstants.VigenciaInativa.ToLower()))
            {
                var expressionToAdd = Expression.Equal(PaginacaoConstants.VigenciaAtiva.Split('.').Aggregate((Expression)parameterX, Expression.Property), Expression.Constant(false));
                completeExpression = completeExpression is null ? expressionToAdd : Expression.And(completeExpression, expressionToAdd);
            }

            return completeExpression;
        }

        private static IEnumerable<PropertyInfo> GetEntityProperties<T>(T entity)
        {
            if (entity == null)
            {
                throw new DomainException(nameof(entity));
            }

            var entityType = entity.GetType();
            var properties = new List<PropertyInfo>();

            AddPropertiesFromType(entityType, properties);

            return properties;
        }

        public static void AddPropertiesFromType(Type type, List<PropertyInfo> properties)
        {
            var complexTypesAlreadyAdded = new List<string>();
            var typesToProcess = new Stack<Type>();
            typesToProcess.Push(type);

            while (typesToProcess.Count > 0)
            {
                var currentType = typesToProcess.Pop();
                var currentTypeProperties = currentType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                properties.AddRange(currentTypeProperties);

                foreach (var property in currentTypeProperties)
                {
                    string propertyTypeFullName = $"{property.PropertyType.FullName} {property.Name} {property.ReflectedType}";

                    if (IsComplexType(property.PropertyType) && !complexTypesAlreadyAdded.Contains(propertyTypeFullName))
                    {
                        typesToProcess.Push(property.PropertyType);
                        complexTypesAlreadyAdded.Add(propertyTypeFullName);
                    }
                }
            }
        }

        private static bool IsComplexType(Type type)
        {
            return !type.IsPrimitive && !type.IsEnum && type != typeof(string) && type != typeof(decimal) && type != typeof(DateTime) && type != typeof(DateTimeOffset) && type != typeof(TimeSpan) && type != typeof(Guid);
        }

        private static PropertyInfo? GetSpecificPropertyInfo(IEnumerable<PropertyInfo> properties, string propertyName, PropertyInfo? lastProperty = null)
        {
            if (properties == null || string.IsNullOrWhiteSpace(propertyName))
            {
                throw new DomainException("Properties and property name must not be null or empty.");
            }

            PropertyInfo? specificPropertyInfo = null;

            foreach (var property in properties)
            {
                if (propertyName.Contains("."))
                {
                    var propertyNames = propertyName.Split('.');
                    specificPropertyInfo = GetNestedPropertyInfo(property, propertyNames, 0);
                }
                else
                {
                    if (lastProperty != null && property.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase) && property.DeclaringType == lastProperty.PropertyType)
                    {
                        specificPropertyInfo = property;
                    }
                    else if (lastProperty == null && property.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                    {
                        specificPropertyInfo = property;
                    }
                }

                if (specificPropertyInfo != null)
                {
                    break;
                }
            }

            return specificPropertyInfo;
        }

        private static PropertyInfo? GetNestedPropertyInfo(PropertyInfo property, string[] propertyNames, int index)
        {
            if (property.Name.Equals(propertyNames[index], StringComparison.OrdinalIgnoreCase))
            {
                if (index == propertyNames.Length - 1)
                {
                    return property;
                }
                else
                {
                    var nestedProperties = property.PropertyType.GetProperties();
                    return GetSpecificPropertyInfo(nestedProperties, string.Join(".", propertyNames, index + 1, propertyNames.Length - index - 1));
                }
            }

            return null;
        }

        private static IOrderedQueryable<TSource> OrderByCustom<TSource>(this IQueryable<TSource> query, PaginacaoRequest paginationRequest) where TSource : class, new()
        {
            var orderbyName = paginationRequest.OrdenarPor!.ToLower();

            if (string.IsNullOrWhiteSpace(orderbyName)) return (IOrderedQueryable<TSource>)query;

            var entityType = typeof(TSource);
            var properties = GetEntityProperties(new TSource()).ToArray();
            var propertyInfo = GetSpecificPropertyInfo(properties, paginationRequest.OrdenarPor);

            if (propertyInfo == null)
            {
                return query.AsQueryable().OrderBy(x => 0);
            }

            var direction = paginationRequest.DirecaoOrdenacao ?? PaginacaoConstants.OrientacaoAsc;
            var orderByDirection = direction == PaginacaoConstants.OrientacaoAsc ? PaginacaoConstants.OrdenarPor : PaginacaoConstants.OrdenarPorDesc;
            var parameterX = Expression.Parameter(entityType, PaginacaoConstants.ParametroX);

            Expression propertyExpression = parameterX;
            MemberExpression property;

            if (orderbyName.IndexOf('.') > 0)
            {
                var orderByProperties = orderbyName.Split(".").ToList();
                orderByProperties.RemoveAt(orderByProperties.Count - 1);

                foreach (var orderByPropertyName in orderByProperties)
                {
                    var propertyInfo2 = GetSpecificPropertyInfo(properties, orderByPropertyName);

                    if (propertyInfo2 == null)
                    {
                        return query.AsQueryable().OrderBy(x => 0);
                    }

                    propertyExpression = Expression.Property(propertyExpression, propertyInfo2);
                }

                property = Expression.Property(propertyExpression, propertyInfo.Name);
            }
            else
            {
                if (parameterX.Type.GetProperty(propertyInfo.Name) == null)
                    return (IOrderedQueryable<TSource>)query;

                property = Expression.Property(parameterX, propertyInfo.Name);
            }

            var selector = Expression.Lambda(property, new ParameterExpression[] { parameterX });

            var method = typeof(Queryable).GetMethods()
                .Where(m => m.Name == orderByDirection && m.IsGenericMethodDefinition)
                .Where(m => m.GetParameters().ToList().Count == 2)
                .Single();

            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            return (IOrderedQueryable<TSource>)genericMethod.Invoke(genericMethod, new object[] { query, selector })!;
        }
        private static IOrderedQueryable<TSource> OrderByCustom<TSource>(this IEnumerable<TSource> query, PaginacaoRequest paginationRequest) where TSource : class, new()
        {
            var orderbyName = paginationRequest.OrdenarPor!.ToLower();

            if (string.IsNullOrWhiteSpace(orderbyName)) return (IOrderedQueryable<TSource>)query;

            var entityType = typeof(TSource);
            var properties = GetEntityProperties(new TSource()).ToArray();
            var propertyInfo = GetSpecificPropertyInfo(properties, paginationRequest.OrdenarPor);

            if (propertyInfo == null)
            {
                return query.AsQueryable().OrderBy(x => 0);
            }

            var direction = paginationRequest.DirecaoOrdenacao ?? PaginacaoConstants.OrientacaoAsc;
            var orderByDirection = direction == PaginacaoConstants.OrientacaoAsc ? PaginacaoConstants.OrdenarPor : PaginacaoConstants.OrdenarPorDesc;
            var parameterX = Expression.Parameter(entityType, PaginacaoConstants.ParametroX);

            Expression propertyExpression = parameterX;
            MemberExpression property;

            if (orderbyName.IndexOf('.') > 0)
            {
                var orderByProperties = orderbyName.Split(".").ToList();
                orderByProperties.RemoveAt(orderByProperties.Count - 1);

                PropertyInfo lastProperty = null;
                foreach (var orderByPropertyName in orderByProperties)
                {
                    var propertyInfo2 = GetSpecificPropertyInfo(properties, orderByPropertyName, lastProperty);
                    lastProperty = propertyInfo2;

                    if (propertyInfo2 == null)
                    {
                        return query.AsQueryable().OrderBy(x => 0);
                    }

                    propertyExpression = Expression.Property(propertyExpression, propertyInfo2);
                }

                property = Expression.Property(propertyExpression, propertyInfo.Name);
            }
            else
            {
                if (parameterX.Type.GetProperty(propertyInfo.Name) == null)
                    return (IOrderedQueryable<TSource>)query;

                property = Expression.Property(parameterX, propertyInfo.Name);
            }

            var selector = Expression.Lambda(property, new ParameterExpression[] { parameterX });

            var method = typeof(Queryable).GetMethods()
                .Where(m => m.Name == orderByDirection && m.IsGenericMethodDefinition)
                .Where(m => m.GetParameters().ToList().Count == 2)
                .Single();

            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            return (IOrderedQueryable<TSource>)genericMethod.Invoke(genericMethod, new object[] { query.AsQueryable(), selector })!;
        }

        private static IQueryable<TEntity> SearchIdsIfExists<TEntity>(this IQueryable<TEntity> query, PaginacaoRequest paginationRequest) where TEntity : class
        {
            if (paginationRequest.Ids is null || paginationRequest.Ids.IsNullOrEmptyOrWhiteSpace())
            {
                return query;
            }

            var filterValues = paginationRequest.Ids.Split(",").Select(x => Guid.Parse(x)).ToList();

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, "Id");
            var containsMethod = typeof(List<Guid>).GetMethod("Contains", new[] { typeof(Guid) });

            if (containsMethod == null)
            {
                throw new DomainException("Não foi possível encontrar o método 'Contains' para List<string>.");
            }

            var filterValuesExpression = Expression.Constant(filterValues);
            var containsExpression = Expression.Call(filterValuesExpression, containsMethod, property);
            Expression filterExpression = containsExpression;

            if (paginationRequest.TipoSelecao == PaginacaoConstants.SelecaoTipoExcecao)
                filterExpression = Expression.Not(containsExpression);

            var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);

            return query.Where(lambda);
        }
        private static IEnumerable<TEntity> SearchIdsIfExists<TEntity>(this IEnumerable<TEntity> query, PaginacaoRequest paginationRequest) where TEntity : class
        {
            if (paginationRequest.Ids is null || paginationRequest.Ids.IsNullOrEmptyOrWhiteSpace())
            {
                return query;
            }

            var filterValues = paginationRequest.Ids.Split(",").Select(x => Guid.Parse(x)).ToList();

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, "Id");
            var containsMethod = typeof(List<Guid>).GetMethod("Contains", new[] { typeof(Guid) });

            if (containsMethod == null)
            {
                throw new DomainException("Não foi possível encontrar o método 'Contains' para List<string>.");
            }

            var filterValuesExpression = Expression.Constant(filterValues);
            var containsExpression = Expression.Call(filterValuesExpression, containsMethod, property);
            Expression filterExpression = containsExpression;

            if (paginationRequest.TipoSelecao == PaginacaoConstants.SelecaoTipoExcecao)
                filterExpression = Expression.Not(containsExpression);

            var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);

            return query.AsQueryable().Where(lambda);
        }

        private static string RemoveMascaraCpfCnpj(string cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(cpfCnpj))
                return string.Empty;

            int tamanhoCpfCnpj = Metodos.ApenasNumeros(cpfCnpj).Length;

            if (tamanhoCpfCnpj != 11 && tamanhoCpfCnpj != 14)
                return cpfCnpj;
            else
                return cpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        }
        public static string RemoverAcentuacao(string texto)
        {
            return string.Concat(texto.Normalize(NormalizationForm.FormD)
                                       .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
                         .Normalize(NormalizationForm.FormC);
        }
    }
}

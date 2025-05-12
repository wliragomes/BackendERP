using AutoMapper;
using Infra.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.MediatR;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Repositories;
using Infra.Repositories;
using Domain.Configuration;
using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Interfaces;
using Application.Services;
using Infra.IoC.Cidades;
using Infra.IoC.Estados;
using Infra.IoC.Pessoas;
using Infra.IoC.Paises;
using Infra.IoC.Produtos;
using Infra.IoC.Auth;
using Infra.IoC.Feriados;
using Infra.IoC.Faturas;
using Infra.IoC.Funcionalidades;
using Infra.IoC.NiveisAcessos;
using Infra.IoC.NormasAbnts;
using Infra.IoC.Vendas;
using Infra.IoC.TiposFretes;
using Infra.IoC.Impostos;
using Infra.IoC.Cfos;
using Infra.IoC.Empresas;
using Infra.IoC.RegimeTributarios;
using Infra.IoC.FaturaParametros;
using Infra.IoC.Modalidades;
using Infra.IoC.Acabamentos;
using Infra.IoC.CodigoDDIs;
using Infra.IoC.Moedas;
using Infra.IoC.Projetos;
using Infra.IoC.MotivoReposições;
using Infra.IoC.MotivoCancelamentos;
using Infra.IoC.ObraFases;
using Infra.IoC.ObraOrigems;
using Infra.IoC.ObrasPadrao;
using Infra.IoC.ObrasProjetos;
using Infra.IoC.Parametros;
using Infra.IoC.Financeiros;
using Infra.IoC.Classificacoes;
using Infra.IoC.Bancos;
using Infra.IoC.Despesas;
using Infra.IoC.Operacoes;
using Infra.IoC.ContasAPagar;
using Infra.IoC.Cartoes;
using Infra.IoC.Caminhoes;
using Infra.IoC.TiposCarrocerias;
using Infra.IoC.TiposRodados;
using Infra.IoC.ContasAPagarPago;
using Infra.IoC.FusoHorarios;
using Infra.IoC.CepsBloqueados;
using Infra.IoC.Chapas;
using Infra.IoC.ContasBancarias;
using Infra.IoC.MovimentosEstoque;
using Infra.IoC.MinimoCobrancas;
using Infra.IoC.Representantes;
using Infra.IoC.ContasAReceber;
using Infra.IoC.FluxoCaixas;
using Infra.IoC.Duplicatas;
using Infra.IoC.NFes;
using Infra.IoC.OrdensFabricacoes;
using Infra.IoC.Comissoes;
using Infra.IoC.Emails;
using Infra.IoC.PlanosDeContas;
using Infra.IoC.DashBoards;
using Infra.IoC.PlanejamentoProducaos;

namespace Infra.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext e UoW

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseDateOnlyTimeOnly();
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        b.EnableRetryOnFailure();
                    }));

            services.AddDbContext<CratosArquivosDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CratosArquivosConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(CratosArquivosDbContext).Assembly.FullName);
                        b.UseDateOnlyTimeOnly();
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        b.EnableRetryOnFailure();
                    }));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkArquivos, UnitOfWorkArquivos>();

            #endregion DbContext e UoW

            #region MediatR
            services.AddScoped<IMediatrHandler, MediatrHandler>();
            #endregion MediatR

            #region HttpClient
            //services.AddHttpClient<Service>();
            #endregion

            #region Configurations
            services.Configure<ProjectsUrlsConfiguration>(configuration.GetSection("ProjectsUrls"));
            #endregion

            #region AutoMApper

            var mapperConfig = new MapperConfiguration(cfg => { cfg.AddMaps("Application"); });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion AutoMApper

            #region Validators

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            #endregion Validators

            #region HttpContext

            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor?.HttpContext?.Request;
                var uri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
                return new UriService(uri);
            });

            #endregion HttpContext

            #region AWS

            //var awsOption = configuration.GetAWSOptions();
            //awsOption.Logging.LogTo = LoggingOptions.Console;
            //awsOption.Credentials = new BasicAWSCredentials(configuration["AWS:AccessKey"],
            //    configuration["AWS:AcessSecretKey"]);

            //services.AddDefaultAWSOptions(awsOption);
            //services.AddAWSService<IAmazonS3>();

            //services.AddScoped<IAmazonS3Storage, AmazonS3Storage>();

            #endregion AWS

            #region RabbitMQ

            //var rabbitSection = configuration.GetSection("RabbitMQ");

            //if (rabbitSection != null)
            //{
            //    var rabbitMQConfig = rabbitSection.Get<RabbitMQConfig>();

            //    services.AddQueueing(new QueueingConfigurationSettings
            //    {
            //        RabbitMqConsumerConcurrency = 5,
            //        RabbitMqHostname = rabbitMQConfig!.HostName,
            //        RabbitMqPort = rabbitMQConfig.Port,
            //        RabbitMqUsername = rabbitMQConfig.UserName,
            //        RabbitMqPassword = rabbitMQConfig.Password,
            //    });

            //    services.AddQueueMessageConsumer<PriceAdjustmentUpdateConsumer, PriceAdjustmentUpdateMessage>();
            //    services.AddQueueMessageConsumer<VigenciaStatusMessageConsumer, SharedKernel.DTOs.Vigencia.VigenciaStatusMessage>(_microservico);

            //    services.AddScoped<IEntityPropertyUpdater, EntityPropertyUpdater>();
            //    services.AddScoped<IGenericRepository<PerfilCota>, GenericRepository<PerfilCota>>();
            //    services.AddScoped<IGenericRepository<Regional>, GenericRepository<Regional>>();
            //    services.AddScoped<IGenericRepository<AssociaParceiroNegocioPlanoComercial>, GenericRepository<AssociaParceiroNegocioPlanoComercial>>();
            //    services.AddScoped<IGenericRepository<AssociaParceiroNegocioSegmentacao>, GenericRepository<AssociaParceiroNegocioSegmentacao>>();
            //    services.AddScoped<IGenericRepository<Campanha>, GenericRepository<Campanha>>();
            //    services.AddScoped<IGenericRepository<ChecklistVenda>, GenericRepository<ChecklistVenda>>();
            //    services.AddScoped<IGenericRepository<AssociaPontoComercialPlanoComercial>, GenericRepository<AssociaPontoComercialPlanoComercial>>();
            //    services.AddScoped<IGenericRepository<Equipe>, GenericRepository<Equipe>>();
            //    services.AddScoped<IGenericRepository<Domain.Entities.Equipes.Equipes>, GenericRepository<Domain.Entities.Equipes.Equipes>>();
            //    services.AddScoped<IGenericRepository<Filial>, GenericRepository<Filial>>();
            //    services.AddScoped<IGenericRepository<AlocacaoVendedor>, GenericRepository<AlocacaoVendedor>>();
            //    services.AddScoped<IGenericRepository<AssociaVendedorCampanha>, GenericRepository<AssociaVendedorCampanha>>();
            //    services.AddScoped<IGenericRepository<AssociaVendedorSegmentacao>, GenericRepository<AssociaVendedorSegmentacao>>();
            //    services.AddScoped<IGenericRepository<BoundSellersUsers>, GenericRepository<BoundSellersUsers>>();
            //    services.AddScoped<IGenericRepository<Seller>, GenericRepository<Seller>>();
            //    services.AddScoped<IGenericRepository<HierarquiaEquipe>, GenericRepository<HierarquiaEquipe>>();
            //    services.AddScoped<IGenericRepository<RegraPlanoReduzido>, GenericRepository<RegraPlanoReduzido>>();
            //    services.AddScoped<IGenericRepository<CondicoesVenda>, GenericRepository<CondicoesVenda>>();
            //    services.AddScoped<IGenericRepository<CondicoesVendaBemObjeto>, GenericRepository<CondicoesVendaBemObjeto>>();

            //}
            #endregion

            services.AddAuthDependencyInjection();
            services.AddCidadeDependencyInjection();
            services.AddEstadoDependencyInjection();
            services.AddPaisDependencyInjection();
            services.AddBancoDependencyInjection();
            services.AddTipoConsumidorDependencyInjection();
            services.AddCstIcmsOrigemMaterialDependencyInjection();
            services.AddCstIcmsDependencyInjection();
            services.AddCstIpiDependencyInjection();            
            services.AddFeriadoDependencyInjection();
            services.AddCentroCustoDependencyInjection();
            services.AddPessoaDependencyInjection();
            services.AddCargoDependencyInjection();
            services.AddDepartamentoDependencyInjection();
            services.AddRegiaoDependencyInjection();
            services.AddOrigemDependencyInjection();
            services.AddSegmentoClienteDependencyInjection();
            services.AddSegmentoEstrategicoDependencyInjection();
            services.AddProdutoDependencyInjection();
            services.AddVendaDependencyInjection();
            services.AddGrupoDependencyInjection();
            services.AddCodigoImportacaoDependencyInjection();
            services.AddSetorDependencyInjection();
            services.AddRuaDependencyInjection();
            services.AddSubgrupoDependencyInjection();
            services.AddPrateleiraDependencyInjection();
            services.AddNcmDependencyInjection();
            services.AddFamiliaDependencyInjection();
            services.AddTipoProdutoDependencyInjection();
            services.AddTipoPrecoDependencyInjection();
            services.AddSetorProdutoDependencyInjection();
            services.AddOrigemMaterialDependencyInjection();
            services.AddFuncionalidadeDependencyInjection();
            services.AddNivelAcessoDependencyInjection();
            services.AddFaturaDependencyInjection();
            services.AddClasseReajusteDependencyInjection();
            services.AddDesgastePolimentoDependencyInjection();
            services.AddNormaAbntDependencyInjection();
            services.AddTipoFreteDependencyInjection();
            services.AddUnidadeMedidaDependencyInjection();
            services.AddImpostoDependencyInjection();            
            services.AddPisDependencyInjection();            
            services.AddCofinsDependencyInjection();            
            services.AddCfopDependencyInjection();            
            services.AddEmpresaDependencyInjection();            
            services.AddRegimeTributarioDependencyInjection();            
            services.AddFaturaParametroDependencyInjection();            
            services.AddModalidadeDependencyInjection();            
            services.AddAcabamentoDependencyInjection();            
            services.AddCodigoDDIDependencyInjection();            
            services.AddMoedaDependencyInjection();            
            services.AddProjetoDependencyInjection();            
            services.AddMotivoReposicaoDependencyInjection();            
            services.AddMotivoCancelamentoDependencyInjection();            
            services.AddObraFaseDependencyInjection();            
            services.AddObraOrigemDependencyInjection();            
            services.AddObraPadraoDependencyInjection();            
            services.AddObraProjetoDependencyInjection();            
            services.AddParametroDependencyInjection();            
            services.AddClassificacaoDependencyInjection();            
            services.AddDespesaDependencyInjection();            
            services.AddOperacaoDependencyInjection();            
            services.AddContaAPagarDependencyInjection();            
            services.AddCartaoDependencyInjection();
            services.AddContaAPagarPagoDependencyInjection();
            services.AddCaminhaoDependencyInjection();            
            services.AddTipoCarroceriaDependencyInjection();            
            services.AddTipoRodadoDependencyInjection();            
            services.AddFusoHorarioDependencyInjection();            
            services.AddCepBloqueadoDependencyInjection();             
            services.AddChapaDependencyInjection();             
            services.AddContaBancariaDependencyInjection();             
            services.AddMovimentoEstoqueDependencyInjection();             
            services.AddMinimoCobrancaDependencyInjection();             
            services.AddRepresentanteDependencyInjection();             
            services.AddContaAReceberDependencyInjection();             
            services.AddFluxoCaixaDependencyInjection();             
            services.AddDuplicataDependencyInjection();             
            services.AddOrdemFabricacaoDependencyInjection();             
            services.AddNFeDependencyInjection();
            services.AddRomaneioDependencyInjection();
            services.AddComissaoDependencyInjection();
            services.AddEmailoDependencyInjection();
            services.AddOrdemFabricacaoItemTemporariaDependencyInjection();
            services.AddPlanoDeContasDependencyInjection();
            services.AddFaturaTemporariaDependencyInjection();
            services.AddDashBoardDependencyInjection();
            services.AddPedidoDependencyInjection();
            services.AddPlanejamentoProducaoDependencyInjection();

            return services;
        }
    }
}

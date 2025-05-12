using APIs.Security.JWT;
using Infra.IoC;
using Microsoft.Extensions.Options;
using SharedKernel.Configuration.Cache;
using SharedKernel.Configuration.Extensions;
using SharedKernel.Configuration.Security.JWT;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var tokenConfigurations = builder.Configuration.GetSection("TokenConfigurations");
var cacheProviderSection = builder.Configuration.GetSection("CacheProvider");
var swaggerSection = builder.Configuration.GetSection("SwaggerConfiguration");

//Todo: Descomentar esse c?digo ap?s subir servidor redis
builder.Services.AddCacheProviderExtension(cacheProviderSection);
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddSwaggerConfigurationExtension(swaggerSection);

builder.Services.AddSession();

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cacheProvider = builder.Services.BuildServiceProvider().GetService<ICacheProvider>();
builder.Services.AddAuthExtension(tokenConfigurations, cacheProvider);

//--------------Auth
var _tokenConfigurations = new TokenConfigurations();
new ConfigureFromConfigurationOptions<TokenConfigurations>(
        tokenConfigurations)
    .Configure(_tokenConfigurations);

builder.Services.AddJwtSecurity(_tokenConfigurations);
//--------------Auth

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddmediatRApi(typeof(MediatrExtension).GetTypeInfo().Assembly);

var app = builder.Build();

app.UseSession();

app.UseSwaggerConfiguration(swaggerSection);
app.RegisterUseExceptionHandlerExtension();
app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<TokenMissingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy
    .WithOrigins("http://localhost:4200", 
                 "https://localhost:4200", 
                 "https://192.168.3.51",
                 "https://srv-server")
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.Run();

/*
 <!-- exemplo de webconfigo para quando o put e delete não funcionar: remover o WebDAVModule -->
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
	  <modules runAllManagedModulesForAllRequests="true">
		<remove name="WebDAVModule" />
	  </modules>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath="dotnet" arguments=".\API.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess" />
    </system.webServer>
  </location>
</configuration>
 */
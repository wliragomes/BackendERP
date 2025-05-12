using Application.DTOs.Cidades;
using Application.Interfaces.Cidades;
using Application.Interfaces.Queries;
using Domain.Commands.Cidades.Adicionar;
using Domain.Commands.Cidades.Atualizar;
using Domain.Commands.Cidades.Excluir;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects;
using SharedKernel.SharedObjects.Paginations;
using AutoMapper;
using Application.DTOs.Cidades.Adicionar;
using Application.DTOs.Cidades.Atualizar;
using Application.DTOs.Cidades.Excluir;
using Application.DTOs.Cidades.Filtro;
using Microsoft.Reporting.NETCore;

namespace Application.Services.Cidade
{
    public class CidadeService : ICidadeService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly ICidadeQuery _cidadeQuery;

        public CidadeService(IMapper mapper, IMediatrHandler mediatorHandler, ICidadeQuery cidadeQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _cidadeQuery = cidadeQuery;
        }

        public async Task<FormularioResponse<AdicionarCidadeCommand>> Adicionar(AdicionarCidadeRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCidadeCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCidadeCommand>> Atualizar(AtualizarCidadeRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCidadeCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCidadeCommand>>> Excluir(ExcluirCidadeDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCidadeCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCidadeCommand, ExcluirCidadeCommand>(commands);
        }

        public async Task<PaginacaoResponse<CidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _cidadeQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<List<CidadeByCodeDto?>> RetornarPorId(Guid id)
        {
            return await _cidadeQuery.RetornarPorId(id);
        }

        public byte[] RetornarRelatorio()
        {
            try
            {
                // Caminho do arquivo RDLC
                var relatorioPath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios", "ListaCidades.rdlc");

                if (!System.IO.File.Exists(relatorioPath))
                {
                    throw new FileNotFoundException("Arquivo RDLC não encontrado no caminho: " + relatorioPath);
                }

                // Configurar o ReportViewer
                using var localReport = new LocalReport();
                using var stream = new FileStream(relatorioPath, FileMode.Open, FileAccess.Read);
                localReport.LoadReportDefinition(stream);

                // Configurar o parâmetro
                string Estado = "SP"; // Valor do parâmetro
                localReport.SetParameters(new[] {
                    new ReportParameter("Estado", Estado)
                });

                // Configurar os dados
                var dadosFiltrados = ObterDados()
                    .Where(cidade => cidade.SG_ESTADO.Equals(Estado, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                localReport.DataSources.Add(new ReportDataSource("DataSetCidadesEstados", dadosFiltrados));

                // Renderizar o relatório como PDF
                var pdfBytes = localReport.Render("PDF");

                return pdfBytes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar o relatório: {ex.Message}");
            }
        }

        // Método para obter dados (simulação ou consulta real ao banco)
        private List<CidadeEstado> ObterDados()
        {
            return new List<CidadeEstado>
            {
                new CidadeEstado { SG_ESTADO = "SP", NM_CIDADE = "São Paulo" },
                new CidadeEstado { SG_ESTADO = "RJ", NM_CIDADE = "Rio de Janeiro" },
                new CidadeEstado { SG_ESTADO = "MG", NM_CIDADE = "Belo Horizonte" },
            };
        }

        // Modelo de dados usado no DataSet
        public class CidadeEstado
        {
            public string SG_ESTADO { get; set; } = "";
            public string NM_CIDADE { get; set; } = "";
        }
    }
}

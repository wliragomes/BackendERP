using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.OrdensFabricacoes;
using Application.Interfaces.Queries;
using Application.DTOs.OrdensFabricacoes;
using Application.DTOs.OrdensFabricacoes.Filtro;
using Application.DTOs.OrdensFabricacoes.Excluir;
using Application.DTOs.OrdensFabricacoes.Atualizar;
using Application.DTOs.OrdensFabricacoes.Adicionar;
using Domain.Commands.OrdensFabricacoes.Adicionar;
using Domain.Commands.OrdensFabricacoes.Atualizar;
using Domain.Commands.OrdensFabricacoes.Excluir;
using Application.DTOs.Vendas.Filtro;
using Microsoft.Reporting.NETCore;
using Application.DTOs.OrdensFabricacoes.Relatorios;
using Domain.Entities;
using System.Threading.Tasks;
using Application.DTOs.PlanejamentosProducoes;

namespace Application.Services.OrdensFabricacoes
{
    public class OrdemFabricacaoService : IOrdemFabricacaoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IOrdemFabricacaoQuery _OrdemFabricacaoQuery;

        public OrdemFabricacaoService(IMapper mapper, IMediatrHandler mediatorHandler, IOrdemFabricacaoQuery OrdemFabricacaoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _OrdemFabricacaoQuery = OrdemFabricacaoQuery;
        }

        public async Task<FormularioResponse<AdicionarOrdemFabricacaoCommand>> Adicionar(AdicionarOrdemFabricacaoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarOrdemFabricacaoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AdicionarOrdemFabricacaoTemporariaCommand>> AdicionarOrdemFabricacaoItemTemporaria(AdicionarOrdemFabricacaoTemporariaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarOrdemFabricacaoTemporariaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarOrdemFabricacaoCommand>> Atualizar(AtualizarOrdemFabricacaoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarOrdemFabricacaoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirOrdemFabricacaoCommand>>> Excluir(ExcluirOrdemFabricacaoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirOrdemFabricacaoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirOrdemFabricacaoCommand, ExcluirOrdemFabricacaoCommand>(commands);
        }

        public async Task<PaginacaoResponse<OrdemFabricacaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _OrdemFabricacaoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<OrdemFabricacaoListaRomaneioDto>> RetornarOrdemFabricacaoRomaneioPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _OrdemFabricacaoQuery.RetornarOrdemFabricacaoRomaneioPaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<OrdemFabricacaoGetDto>> RetornarOrdemFabricacaoGetPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _OrdemFabricacaoQuery.RetornarOrdemFabricacaoGetPaginacao(paginacaoRequest);
        }

        public async Task<OrdemFabricacaoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _OrdemFabricacaoQuery.RetornarPorId(id);
        }

        public async Task<List<GetTemporarioDto?>> RetornarGetTemporarioPaginacao(Guid idVenda)
        {
            return await _OrdemFabricacaoQuery.RetornarGetTemporarioPaginacao(idVenda);
        }

        public async Task<List<GetOrdemFabricacaoObterVendaDto?>> RetornarVendaPorOrdemFabricacao(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno)
        {
            return await _OrdemFabricacaoQuery.RetornarVendaPorOrdemFabricacao(sqOrdemFabricacaoCodigo, sqOrdemFabricacaoAno);
        }

        public async Task<EnderecoOrdemFabricacaoDto?> RetornarEnderecoOrdemFabricacao(Guid id, Guid idEnderecoEntrega)
        {
            return await _OrdemFabricacaoQuery.RetornarEnderecoOrdemFabricacao(id, idEnderecoEntrega);
        }

        public async Task<OrdemFabricacaoItemDimensaoCalculoDto?> GetCalculoDimensoesItem(OrdemFabricacaoItemDimensaoDto dimensao)
        {
            return await _OrdemFabricacaoQuery.GetCalculoDimensoesItem(dimensao);
        }

        public async Task<OrdemFabricacaoCalculoLapidacaoDto?> GetCalculoLapidacaoItem(OrdemFabricacaoItemLapidacaoDto lapidacao)
        {
            return await _OrdemFabricacaoQuery.GetCalculoLapidacaoItem(lapidacao);
        }

        public async Task<byte[]> RetornarRelatorioProforma(Guid idOrdemFabricacao)
        {
            try
            {
                // Caminho do arquivo RDLC
                var relatorioPath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios", "proforma.rdlc");

                if (!System.IO.File.Exists(relatorioPath))
                {
                    throw new FileNotFoundException("Arquivo RDLC não encontrado no caminho: " + relatorioPath);
                }

                // Configurar o ReportViewer
                using var localReport = new LocalReport();
                using var stream = new FileStream(relatorioPath, FileMode.Open, FileAccess.Read);
                localReport.LoadReportDefinition(stream);

                // Configurar o parâmetro
                localReport.SetParameters(new[] {
                    new ReportParameter("idOrdemFabricacao", idOrdemFabricacao.ToString())
                });

                // Configurar os dados
                var dadosFiltrados = await _OrdemFabricacaoQuery.RetornarClienteProforma(idOrdemFabricacao);

                localReport.DataSources.Add(new ReportDataSource("DataSetCliente", dadosFiltrados));

                // Renderizar o relatório como PDF
                var pdfBytes = localReport.Render("PDF");

                return pdfBytes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar o relatório: {ex.Message}");
            }
        }


        public async Task<ResultadoOrdemFabricacaoResumoDto?> GetOrdemFabricacaoResumo(Guid idOrdemTmp)
        {
            return await _OrdemFabricacaoQuery.GetOrdemFabricacaoResumo(idOrdemTmp);
        }
    }
}
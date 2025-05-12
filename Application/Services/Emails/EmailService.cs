using Application.DTOs.Emails;
using Application.DTOs.OrdensFabricacoes.Relatorios;
using Application.Interfaces.Emails;
using Application.Interfaces.Queries;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Reporting.NETCore;
using MimeKit;

namespace Application.Services.Emails
{
    public class EmailService : IEmailService
    {
        private readonly IVendaQuery _vendaQuery;

        public EmailService(IVendaQuery vendaQuery)
        {
            _vendaQuery = vendaQuery;
        }

        public async Task EnviarEmailOrcamento(EnviaEmailOrcamentoDto email, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ERP", "crm@wgomes.com"));
            message.To.Add(MailboxAddress.Parse(email.Para));

            if (!string.IsNullOrWhiteSpace(email.Cc))
                message.Cc.Add(MailboxAddress.Parse(email.Cc));

            message.Subject = email.Assunto;

            var builder = new BodyBuilder
            {
                HtmlBody = email.Mensagem
            };

            // Verifica se deve gerar anexo de orçamento
            if (email.AnexoOrcamento != null)
            {
                var pdfBytes = await RetornarImpressao(
                    email.AnexoOrcamento.IdVenda,
                    email.AnexoOrcamento.Especial,
                    email.AnexoOrcamento.Orcamento,
                    email.AnexoOrcamento.IdCliente,
                    email.AnexoOrcamento.SuprimirVendedor
                );

                builder.Attachments.Add("orcamento.pdf", pdfBytes, ContentType.Parse("application/pdf"));
            }

            message.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("mail.wgomes.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("crm@wgomes.com", "2%&nLxbfc3");
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }

        public async Task<byte[]> RetornarImpressao(Guid idVenda, bool especial, bool orcamento, Guid idCliente, bool suprimirVendedor)
        {
            var nomeArquivo = orcamento
                ? (especial ? "relOrcamentoEspecial.rdlc" : "relOrcamento.rdlc")
                : (especial ? "relPedidoEspecial.rdlc" : "relPedido.rdlc");

            var relatorioPath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios", nomeArquivo);

            if (!System.IO.File.Exists(relatorioPath))
                throw new FileNotFoundException($"Arquivo RDLC não encontrado: {relatorioPath}");

            using var localReport = new LocalReport();
            using var stream = new FileStream(relatorioPath, FileMode.Open, FileAccess.Read);
            localReport.LoadReportDefinition(stream);

            localReport.SetParameters(new[] {
        new ReportParameter("idVenda", idVenda.ToString())
            });

            var dadosFiltrados = await _vendaQuery.RetornarImpressaoNew(idVenda, especial, orcamento, idCliente, suprimirVendedor);
            localReport.DataSources.Add(new ReportDataSource("DataSetOrcamento", dadosFiltrados));

            return localReport.Render("PDF");
        }

    }
}

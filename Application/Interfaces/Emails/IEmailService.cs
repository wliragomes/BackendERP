using Application.DTOs.Emails;

namespace Application.Interfaces.Emails
{
    public interface IEmailService
    {
        Task EnviarEmailOrcamento(EnviaEmailOrcamentoDto email, CancellationToken cancellationToken);
    }
}

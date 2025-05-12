using Application.DTOs.Emails;
using Application.DTOs.Pessoas;
using Application.Interfaces.Emails;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : PrincipalController
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService EmailService)
        {
            _emailService = EmailService;
        }

        [HttpPost("enviar-email-orcamento")]
        public async Task<IActionResult> EnviarEmailOrcamento([FromBody] EnviaEmailOrcamentoDto email, CancellationToken cancellationToken)
        {
            try
            {
                await _emailService.EnviarEmailOrcamento(email, cancellationToken);
                return Ok(new { message = "E-mail enviado com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erro ao enviar e-mail: {ex.Message}" });
            }
        }

    }
}

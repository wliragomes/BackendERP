using System;

namespace Domain.Commands.ContasAPagarPago.Adicionar
{
    public class AdicionarContaAPagarPagoCommand : ContaAPagarPagoCommand<AdicionarContaAPagarPagoCommand>
    {
        public AdicionarContaAPagarPagoCommand()
        {

        }

        public AdicionarContaAPagarPagoCommand(Guid id, Guid idContaAPagar, int nItem, DateTime baixa, Guid idBanco, string agencia, string agenciaDigito, string conta,
                                               string contaDigito, decimal valorPago, DateTime dataOperacao, string historico, string nDocumentoPago/*, bool status*/)
            : base(id, idContaAPagar, nItem, baixa, idBanco, agencia, agenciaDigito, conta, contaDigito, valorPago, dataOperacao, historico, nDocumentoPago/*, status*/)
        {
        }
    }
}

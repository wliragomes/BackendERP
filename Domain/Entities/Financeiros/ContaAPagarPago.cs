using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ContaAPagarPago : EntityId
    {
        public Guid IdContaAPagar { get; set; }
        public int NItem { get; set; }
        public DateTime Baixa { get; set; }
        public Guid IdBanco { get; set; }
        public string Agencia { get; set; }
        public string AgenciaDigito { get; set; }
        public string Conta { get; set; }
        public string ContaDigito { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataOperacao { get; set; }
        public string Historico { get; set; }
        public string NDocumentoPago { get; set; }
        //public bool Status { get; set; }

        public ContaAPagarPago(Guid idContaAPagar, int nItem, DateTime baixa, Guid idBanco, string agencia, string agenciaDigito, string conta,
                                      string contaDigito, decimal valorPago, DateTime dataOperacao, string historico, string nDocumentoPago/*, bool status*/)
        {
            SetId(Guid.NewGuid());
            IdContaAPagar = idContaAPagar;
            NItem = nItem;
            Baixa = baixa;
            IdBanco = idBanco;
            Agencia = agencia;
            AgenciaDigito = agenciaDigito;
            Conta = conta;
            ContaDigito = contaDigito;
            ValorPago = valorPago;
            DataOperacao = dataOperacao;
            Historico = historico;
            NDocumentoPago = nDocumentoPago;
            //Status = status;    

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idContaAPagar, int nItem, DateTime baixa, Guid idBanco, string agencia, string agenciaDigito, string conta,
                           string contaDigito, decimal valorPago, DateTime dataOperacao, string historico, string nDocumentoPago/*, bool status*/)
        {
            IdContaAPagar = idContaAPagar;
            NItem = nItem;
            Baixa = baixa;
            IdBanco = idBanco;
            Agencia = agencia;
            AgenciaDigito = agenciaDigito;
            Conta = conta;
            ContaDigito = contaDigito;
            ValorPago = valorPago;
            DataOperacao = dataOperacao;
            Historico = historico;
            NDocumentoPago = nDocumentoPago;
            //Status = status;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}

using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ContaBancaria : EntityIdDescricao
    {
        public Guid IdBanco { get; set; }
        public string Agencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string Conta { get; set; }
        public string DigitoConta { get; set; }
        public bool LimiteEspecial { get; set; }
        public decimal ValorLimiteEspecial { get; set; }
        public bool ContaGarantida { get; set; }
        public decimal ValorContaGarantida { get; set; }

        public ContaBancaria(string descricao, Guid idBanco, string agencia, string digitoAgencia, string conta, string digitoConta, bool limiteEspecial,
                             decimal valorLimiteEspecial, bool contaGarantida, decimal valorContaGarantida)
        {
            SetId(Guid.NewGuid());
            SetDescricao(descricao);
            IdBanco = idBanco;
            Agencia = agencia;
            DigitoAgencia = digitoAgencia;
            Conta = conta;
            DigitoConta = digitoConta;
            LimiteEspecial = limiteEspecial;
            ValorLimiteEspecial = valorLimiteEspecial;
            ContaGarantida = contaGarantida;
            ValorContaGarantida = valorContaGarantida;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao, Guid idBanco, string agencia, string digitoAgencia, string conta, string digitoConta, bool limiteEspecial,
                           decimal valorLimiteEspecial, bool contaGarantida, decimal valorContaGarantida)
        {
            SetDescricao(descricao);
            IdBanco = idBanco;
            Agencia = agencia;
            DigitoAgencia = digitoAgencia;
            Conta = conta;
            DigitoConta = digitoConta;
            LimiteEspecial = limiteEspecial;
            ValorLimiteEspecial = valorLimiteEspecial;
            ContaGarantida = contaGarantida;
            ValorContaGarantida = valorContaGarantida;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}

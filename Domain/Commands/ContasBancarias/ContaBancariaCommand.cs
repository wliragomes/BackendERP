using SharedKernel.MediatR;

namespace Domain.Commands.ContasBancarias
{
    public abstract class ContaBancariaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IdBanco { get; set; }
        public string Agencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string Conta { get; set; }
        public string DigitoConta { get; set; }
        public bool LimiteEspecial { get; set; }
        public decimal ValorLimiteEspecial { get; set; }
        public bool ContaGarantida { get; set; }
        public decimal ValorContaGarantida { get; set; }

        public ContaBancariaCommand()
        {

        }

        public ContaBancariaCommand(Guid id, string descricao, Guid idBanco, string agencia, string digitoAgencia, string conta, string digitoConta, bool limiteEspecial,
                                    decimal valorLimiteEspecial, bool contaGarantida, decimal valorContaGarantida)
        {
            Id = id;
            Descricao = descricao;
            IdBanco = idBanco;
            Agencia = agencia;
            DigitoAgencia = digitoAgencia;
            Conta = conta;
            DigitoConta = digitoConta;
            LimiteEspecial = limiteEspecial;
            ValorLimiteEspecial = valorLimiteEspecial;
            ContaGarantida = contaGarantida;
            ValorContaGarantida = valorContaGarantida;

        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
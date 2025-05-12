namespace Domain.Commands.ContasBancarias.Adicionar
{
    public class AdicionarContaBancariaCommand : ContaBancariaCommand<AdicionarContaBancariaCommand>
    {
        public AdicionarContaBancariaCommand()
        {

        }

        public AdicionarContaBancariaCommand(Guid id, string descricao, Guid idBanco, string agencia, string digitoAgencia, string conta, string digitoConta, bool limiteEspecial,
                                             decimal valorLimiteEspecial, bool contaGarantida, decimal valorContaGarantida)
            : base(id, descricao, idBanco, agencia, digitoAgencia, conta, digitoConta, limiteEspecial, valorLimiteEspecial, contaGarantida, valorContaGarantida)
        {
        }
    }
}

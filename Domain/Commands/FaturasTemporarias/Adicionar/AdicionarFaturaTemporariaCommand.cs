namespace Domain.Commands.FaturaTemporarias.Adicionar
{
    public class AdicionarFaturaTemporariaCommand : FaturaTemporariaCommand<AdicionarFaturaTemporariaCommand>
    {
        public AdicionarFaturaTemporariaCommand()
        {

        }

        public AdicionarFaturaTemporariaCommand(Guid id, Guid idEmpresa, Guid idPessoa, decimal valorFrete, decimal valorSeguro, decimal valorOutrasDespesas,
                                                decimal prIcms, decimal valorIcms, decimal valorPis, decimal valorIpi, decimal valorCofins, decimal baseCalculoSt,
                                                decimal valorSt, decimal valorTotalProduto, decimal valorTotalNota)
            : base(id, idEmpresa, idPessoa, valorFrete, valorSeguro, valorOutrasDespesas, prIcms, valorIcms, valorPis, valorIpi, valorCofins, 
                  baseCalculoSt, valorSt, valorTotalProduto, valorTotalNota)
        {
        }
    }
}

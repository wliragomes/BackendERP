namespace Domain.Commands.Produtos.Ncms.Adicionar
{
    public class AdicionarNcmCommand : NcmCommand<AdicionarNcmCommand>
    {
        public AdicionarNcmCommand()
        {

        }

        public AdicionarNcmCommand(Guid id, string? nrNcm01, string? nrNcm02, string? nrNcm03, string nrNcmCompleta, string descricao, decimal aliquota, bool insiteSt, decimal aliquotaSt)
            : base(id, nrNcm01, nrNcm02, nrNcm03, nrNcmCompleta, descricao, aliquota,  insiteSt, aliquotaSt)
        {
        }
    }
}

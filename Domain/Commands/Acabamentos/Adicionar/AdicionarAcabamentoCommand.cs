namespace Domain.Commands.Acabamentos.Adicionar
{
    public class AdicionarAcabamentoCommand : AcabamentoCommand<AdicionarAcabamentoCommand>
    {
        public AdicionarAcabamentoCommand()
        {

        }

        public AdicionarAcabamentoCommand(Guid id, string descricao, bool tolerancia)
            : base(id, descricao, tolerancia)
        {
        }
    }
}

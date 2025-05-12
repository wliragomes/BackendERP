namespace Domain.Commands.Acabamentos.Atualizar
{
    public class AtualizarAcabamentoCommand : AcabamentoCommand<AtualizarAcabamentoCommand>
    {
        public AtualizarAcabamentoCommand(Guid id, string descricao, bool tolerancia)
            : base(id, descricao, tolerancia)
        {
        }

        public AtualizarAcabamentoCommand()
        {

        }
    }
}
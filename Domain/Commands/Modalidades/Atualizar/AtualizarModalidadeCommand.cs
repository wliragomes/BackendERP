namespace Domain.Commands.Modalidades.Atualizar
{
    public class AtualizarModalidadeCommand : ModalidadeCommand<AtualizarModalidadeCommand>
    {
        public AtualizarModalidadeCommand(Guid id, string descricaoModalidade, bool exigeNumero)
            : base(id, descricaoModalidade, exigeNumero)
        {
        }

        public AtualizarModalidadeCommand()
        {

        }
    }
}
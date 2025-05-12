namespace Domain.Commands.Modalidades.Adicionar
{
    public class AdicionarModalidadeCommand : ModalidadeCommand<AdicionarModalidadeCommand>
    {
        public AdicionarModalidadeCommand()
        {

        }

        public AdicionarModalidadeCommand(Guid id, string descricaoModalidade, bool exigeNumero)
            : base(id, descricaoModalidade, exigeNumero)
        {
        }
    }
}

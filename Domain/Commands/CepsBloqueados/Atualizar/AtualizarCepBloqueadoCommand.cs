namespace Domain.Commands.CepsBloqueados.Atualizar
{
    public class AtualizarCepBloqueadoCommand : CepBloqueadoCommand<AtualizarCepBloqueadoCommand>
    {
        public AtualizarCepBloqueadoCommand(Guid id, string numeroCep, string descricao, int numeroDe, int numeroAte, bool par, bool impar)
            : base(id, numeroCep, descricao, numeroDe, numeroAte, par, impar)
        {
        }

        public AtualizarCepBloqueadoCommand()
        {

        }
    }
}
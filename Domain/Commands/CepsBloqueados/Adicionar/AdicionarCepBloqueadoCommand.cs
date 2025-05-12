namespace Domain.Commands.CepsBloqueados.Adicionar
{
    public class AdicionarCepBloqueadoCommand : CepBloqueadoCommand<AdicionarCepBloqueadoCommand>
    {
        public AdicionarCepBloqueadoCommand()
        {

        }

        public AdicionarCepBloqueadoCommand(Guid id, string numeroCep, string descricao, int numeroDe, int numeroAte, bool par, bool impar)
            : base(id, numeroCep, descricao, numeroDe, numeroAte, par, impar)
        {
        }
    }
}

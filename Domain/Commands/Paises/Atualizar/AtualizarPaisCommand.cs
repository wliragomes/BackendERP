namespace Domain.Commands.Paises.Atualizar
{
    public class AtualizarPaisCommand : PaisCommand<AtualizarPaisCommand>
    {
        public AtualizarPaisCommand(Guid? id, string? nome, Guid? idFusoHorario, Guid? idDdi, Guid? idMoedaPrincipal)
            : base(id, nome, idFusoHorario, idDdi, idMoedaPrincipal)
        {
        }

        public AtualizarPaisCommand()
        {

        }
    }
}
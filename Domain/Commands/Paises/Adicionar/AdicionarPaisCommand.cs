namespace Domain.Commands.Paises.Adicionar
{
    public class AdicionarPaisCommand : PaisCommand<AdicionarPaisCommand>
    {
        public AdicionarPaisCommand()
        {

        }

        public AdicionarPaisCommand(Guid? id, string? nome, Guid? idFusoHorario, Guid idDdi, Guid? idMoedaPrincipal)
            : base(id, nome, idFusoHorario, idDdi, idMoedaPrincipal)
        {
        }
    }
}

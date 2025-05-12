namespace Domain.Commands.Caminhoes.Atualizar
{
    public class AtualizarCaminhaoCommand : CaminhaoCommand<AtualizarCaminhaoCommand>
    {
        public AtualizarCaminhaoCommand(Guid id, string descricao, int caminhaoCarreta, string numero, string placa, decimal tara, decimal capacidadeKg, decimal capacidadeM3,
                                        Guid idPessoa, Guid idTipoRodado, Guid idTipoCarroceria, Guid idEstado, bool inativo)
            : base(id, descricao, caminhaoCarreta, numero, placa, tara, capacidadeKg, capacidadeM3, idPessoa, idTipoRodado, idTipoCarroceria, idEstado, inativo)
        {
        }

        public AtualizarCaminhaoCommand()
        {

        }
    }
}
using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.CodigosImportacoes
{
    public abstract class CodigoImportacaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public CodigoImportacaoCommand()
        {

        }

        public CodigoImportacaoCommand(Guid id, string? descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}

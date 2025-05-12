using SharedKernel.MediatR;

namespace Domain.Commands.TipoFretes
{
    public abstract class TipoFreteCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public int NFrete { get; set; }
        public string? Descricao { get; set; }
        public string? DescricaoResumida { get; set; }

        public TipoFreteCommand()
        {

        }

        public TipoFreteCommand(Guid id, int nFrete, string? descricao, string? descricaoResumida)
        {
            Id = id;
            NFrete = nFrete;
            Descricao = descricao;
            DescricaoResumida = descricaoResumida;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
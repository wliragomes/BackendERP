using SharedKernel.MediatR;

namespace Domain.Commands.Modalidades
{
    public abstract class ModalidadeCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string DescricaoModalidade { get; set; }
        public bool ExigeNumero { get; set; }

        public ModalidadeCommand()
        {

        }

        public ModalidadeCommand(Guid id, string descricaoModalidade, bool exigeNumero)
        {
            Id = id;
            DescricaoModalidade = descricaoModalidade;
            ExigeNumero = exigeNumero;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
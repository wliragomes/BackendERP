using SharedKernel.MediatR;

namespace Domain.Commands.Representantes
{
    public abstract class RepresentanteCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public Guid IdPessoa { get; set; }
        public bool Externo { get; set; }
        public decimal Comissao { get; set; }

        public RepresentanteCommand()
        {

        }

        public RepresentanteCommand(Guid id, Guid idPessoa,  bool externo, decimal comissao)
        {
            Id = id;
            IdPessoa = idPessoa;
            Externo = externo;
            Comissao = comissao;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
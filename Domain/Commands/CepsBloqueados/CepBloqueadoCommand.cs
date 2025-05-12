using SharedKernel.MediatR;

namespace Domain.Commands.CepsBloqueados
{
    public abstract class CepBloqueadoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string NumeroCep { get; set; }
        public string Descricao { get; set; }
        public int NumeroDe { get; set; }
        public int NumeroAte { get; set; }
        public bool Par { get; set; }
        public bool Impar { get; set; }

        public CepBloqueadoCommand()
        {

        }

        public CepBloqueadoCommand(Guid id, string numeroCep, string descricao, int numeroDe, int numeroAte, bool par, bool impar)
        {
            Id = id;
            NumeroCep = numeroCep;
            Descricao = descricao;
            NumeroDe = numeroDe;
            NumeroAte = numeroAte;
            Par = par;
            Impar = impar;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
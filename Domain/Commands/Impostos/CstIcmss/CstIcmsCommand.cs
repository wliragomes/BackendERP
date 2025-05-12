using SharedKernel.MediatR;

namespace Domain.Commands.Impostos.CstIcmss
{
    public abstract class CstIcmsCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string CstIcmsAmigavel { get; set; }
        public string Nome { get; set; }
        public bool DescontaIcms { get; set; }

        public CstIcmsCommand()
        {

        }

        public CstIcmsCommand(Guid id, string nome, string csticmsamigavel, bool descontaicms)
        {
            Id = id;
            Nome = nome;
            CstIcmsAmigavel = csticmsamigavel;
            DescontaIcms = descontaicms;

        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}

using SharedKernel.MediatR;

namespace Domain.Commands.Pessoas.TipoConsumidores
{
    public abstract class TipoConsumidorCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool SomaItens { get; set; }
        public bool SomaDespesasBaseIcms { get; set; }
        public bool SomaIpiBaseIcms { get; set; }
        public bool SomaDespesasBaseSt { get; set; }
        public bool SomaIpiBaseSt { get; set; }
        public bool SomaStBaseIcms { get; set; }
        public bool Difal { get; set; }
        public bool SubstituicaoIcms { get; set; }
        public TipoConsumidorCommand()
        {

        }

        public TipoConsumidorCommand(Guid id, string nome, string descricao, bool somaItens, bool somaDespesasBaseIcms, bool somaIpiBaseIcms,
                                     bool somaDespesasBaseSt, bool somaIpiBaseSt, bool somaStBaseIcms, bool difal, bool substituicaoIcms)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            SomaItens = somaItens;
            SomaDespesasBaseIcms = somaDespesasBaseIcms;
            SomaIpiBaseIcms = somaIpiBaseIcms;
            SomaDespesasBaseSt = somaDespesasBaseSt;
            SomaIpiBaseSt = somaIpiBaseSt;
            SomaStBaseIcms = somaStBaseIcms;
            Difal = difal;
            SubstituicaoIcms = substituicaoIcms;
        }
    }
}

using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class TipoConsumidor : EntityId
    {
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

        public TipoConsumidor() { }

        public TipoConsumidor(string nome, string descricao, bool somaItens, bool somaDespesasBaseIcms, bool somaIpiBaseIcms,
                             bool somaDespesasBaseSt, bool somaIpiBaseSt, bool somaStBaseIcms, bool difal, bool substituicaoIcms)
        {
            SetId(Guid.NewGuid());
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

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, string descricao, bool somaItens, bool somaDespesasBaseIcms, bool somaIpiBaseIcms,
                           bool somaDespesasBaseSt, bool somaIpiBaseSt, bool somaStBaseIcms, bool difal, bool substituicaoIcms)
        {
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

            ChangeUpdateAtToDateTimeNow();
        }
    }
}


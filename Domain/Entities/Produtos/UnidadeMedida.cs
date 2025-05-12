using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class UnidadeMedida : EntityIdNome
    {
        public string Sigla { get; set; }
        public int? CasasDecimais { get; set; }

        public UnidadeMedida(string nome, string sigla, int? casasDecimais)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            Sigla = sigla;
            CasasDecimais = casasDecimais;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid id, string nome, string sigla, int? casasDecimais)
        { 
            SetId(id);
            SetNome(nome);
            Sigla = sigla;
            CasasDecimais = casasDecimais;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}

using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class RegimeTributario : EntityIdNome
    {        
        public decimal ValorPis {  get; set; }
        public decimal ValorCofins {  get; set; }
        public RegimeTributario(string nome, decimal valorPis, decimal valorCofins)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            ValorPis = valorPis;
            ValorCofins = valorCofins;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, decimal valorPis, decimal valorCofins)
        {
            SetNome(nome);
            ValorPis = valorPis;
            ValorCofins = valorCofins;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}

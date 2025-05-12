using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class ContatoVenda : EntityId
    {
        public Guid IdContato { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Fax { get; set; }
        public string? Celular { get; set; }

        public ContatoVenda() 
        {
        }

        public ContatoVenda(Guid idContato, string nome, string telefone, string fax, string celular)
        {
            IdContato = idContato;
            Nome = nome;
            Telefone = telefone;
            Fax = fax;
            Celular = celular;            
        }

        public void Update(string nome, string telefone, string fax, string celular)
        {
            Nome = nome;
            Telefone = telefone;
            Fax = fax;
            Celular = celular;
        }
    }
}

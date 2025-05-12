namespace SharedKernel.SharedObjects
{
    public abstract class EntityIdNome : EntityId
    {
        public string? Nome { get; private set; }

        public void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}


namespace SharedKernel.SharedObjects
{
    public abstract class EntityIdDescricao : EntityId
    {
        public string Descricao { get; private set; }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}

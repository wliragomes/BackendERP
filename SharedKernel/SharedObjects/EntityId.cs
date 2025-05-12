namespace SharedKernel.SharedObjects
{
    public abstract class EntityId : Entity
    {
        public Guid Id { get; private set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}

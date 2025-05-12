namespace SharedKernel.Data
{
    public interface INewUnitOfWork
    {
        Task<bool> Commit();
    }
}

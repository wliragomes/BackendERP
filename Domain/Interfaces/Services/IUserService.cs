namespace Application.Interfaces.Auth
{
    public interface IUserService
    {
        Guid GetUserId();
        string GetUserName();
    }
}

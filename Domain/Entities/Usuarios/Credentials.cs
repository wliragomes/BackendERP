namespace Domain.Entities.Usuarios
{
    public class Credentials
    {
        public List<string> Claims { get; private set; }

        public Credentials(List<string> claims)
        {
            Claims = claims;
        }
    }
}

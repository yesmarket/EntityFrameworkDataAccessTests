namespace Domain.DataAccess.Support
{
    public class DbContextFactory : IDbContextFactory
    {
        public NorthwndDbContext GetContext()
        {
            return new NorthwndDbContext();
        }
    }
}
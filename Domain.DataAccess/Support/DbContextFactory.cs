namespace Domain.DataAccess.Support
{
    public class DbContextFactory : IDbContextFactory
    {
        public BrgDbContext GetContext()
        {
            return new BrgDbContext();
        }
    }
}
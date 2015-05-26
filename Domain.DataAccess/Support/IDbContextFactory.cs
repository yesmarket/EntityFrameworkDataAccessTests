namespace Domain.DataAccess.Support
{
    public interface IDbContextFactory
    {
        BrgDbContext GetContext();
    }
}
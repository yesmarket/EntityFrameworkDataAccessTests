namespace Domain.DataAccess.Support
{
    public interface IDbContextFactory
    {
        NorthwndDbContext GetContext();
    }
}
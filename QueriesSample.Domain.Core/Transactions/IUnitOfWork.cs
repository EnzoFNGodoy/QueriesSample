namespace QueriesSample.Domain.Core.Transactions;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
}
using QueriesSample.Domain.Core.Transactions;
using QueriesSample.Infra.Data.Context;

namespace QueriesSample.Infra.Data.Transactions;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly QueriesSampleContext _context;

    public UnitOfWork(QueriesSampleContext context) => _context = context;

    public Task<bool> SaveChangesAsync()
        => _context.SaveChangesAsync() > 0;
}
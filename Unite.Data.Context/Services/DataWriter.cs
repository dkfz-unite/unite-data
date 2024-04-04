using Microsoft.EntityFrameworkCore;

namespace Unite.Data.Context.Services;

public abstract class DataWriter<TModel> : IDataWriter<TModel>
{
    protected readonly IDbContextFactory<DomainDbContext> _dbContextFactory;


    public DataWriter(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    public abstract void Initialize(DomainDbContext dbContext);

    public virtual void SaveData(in TModel model)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        using var transaction = dbContext.Database.BeginTransaction();

        Initialize(dbContext);

        try
        {
            ProcessModel(model);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();

            throw;
        }
    }

    public virtual void SaveData(in IEnumerable<TModel> models)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        using var transaction = dbContext.Database.BeginTransaction();

        Initialize(dbContext);

        try
        {
            ProcessModels(models);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();

            throw;
        }
    }


    protected abstract void ProcessModel(TModel model);

    protected virtual void ProcessModels(IEnumerable<TModel> models)
    {
        foreach (var model in models)
        {
            ProcessModel(model);
        }
    }
}


public abstract class DataWriter<TModel, TAudit> : IDataWriter<TModel, TAudit>
    where TAudit : class, new()
{
    protected readonly IDbContextFactory<DomainDbContext> _dbContextFactory;


    public DataWriter(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    public abstract void Initialize(DomainDbContext dbContext);

    public virtual void SaveData(in TModel model, out TAudit audit)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        using var transaction = dbContext.Database.BeginTransaction();

        Initialize(dbContext);

        try
        {
            audit = new TAudit();

            ProcessModel(model, ref audit);

            transaction.Commit();
        }
        catch
        {
            audit = null;

            transaction.Rollback();

            throw;
        }
    }

    public virtual void SaveData(in IEnumerable<TModel> models, out TAudit audit)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        using var transaction = dbContext.Database.BeginTransaction();

        Initialize(dbContext);

        try
        {
            audit = new TAudit();

            ProcessModels(models, ref audit);

            transaction.Commit();
        }
        catch
        {
            audit = null;

            transaction.Rollback();

            throw;
        }
    }


    protected abstract void ProcessModel(TModel model, ref TAudit audit);

    protected virtual void ProcessModels(IEnumerable<TModel> models, ref TAudit audit)
    {
        foreach (var model in models)
        {
            ProcessModel(model, ref audit);
        }
    }
}

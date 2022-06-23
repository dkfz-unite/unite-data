using System.Collections.Generic;

namespace Unite.Data.Services;

public abstract class DataWriter<TModel> : IDataWriter<TModel> where TModel : class
{
    protected readonly DomainDbContext _dbContext;


    public DataWriter(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public virtual void SaveData(in TModel model)
    {
        using var transaction = _dbContext.Database.BeginTransaction();

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
        using var transaction = _dbContext.Database.BeginTransaction();

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
    where TModel : class
    where TAudit : class, new()
{
    protected readonly DomainDbContext _dbContext;


    public DataWriter(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public virtual void SaveData(in TModel model, out TAudit audit)
    {
        using var transaction = _dbContext.Database.BeginTransaction();

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
        using var transaction = _dbContext.Database.BeginTransaction();

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

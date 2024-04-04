namespace Unite.Data.Context.Services;

public interface IDataWriter<TModel>
{
    void SaveData(in TModel model);
    void SaveData(in IEnumerable<TModel> models);
}

public interface IDataWriter<TModel, TAudit>
    where TAudit : class, new()
{
    void SaveData(in TModel model, out TAudit audit);
    void SaveData(in IEnumerable<TModel> models, out TAudit audit);
}

using System.Collections.Generic;

namespace Unite.Data.Services;

public interface IDataWriter<TModel> where TModel : class
{
    void SaveData(in TModel model);
    void SaveData(in IEnumerable<TModel> models);
}

public interface IDataWriter<TModel, TAudit>
    where TModel : class
    where TAudit : class, new()
{
    void SaveData(in TModel model, out TAudit audit);
    void SaveData(in IEnumerable<TModel> models, out TAudit audit);
}

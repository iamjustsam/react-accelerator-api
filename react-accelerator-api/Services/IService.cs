using System;
using System.Collections.Generic;

namespace react_accelerator_api.Services
{
    public interface IService<TModel> where TModel : Model
    {
        IEnumerable<TModel> Get();
        TModel Get(Guid id);
        TModel Create(TModel model);
        TModel Update(Guid id, TModel model);
        void Delete(Guid id);
    }
}

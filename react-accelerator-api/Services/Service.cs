using System;
using System.Collections.Generic;

namespace react_accelerator_api.Services
{
    public class Service<TModel> : IService<TModel>
        where TModel : Model
    {
        private readonly IDictionary<Guid, TModel> _models;

        protected Service()
        {
            _models = new Dictionary<Guid, TModel>();
        }

        public IEnumerable<TModel> Get()
        {
            return _models.Values;
        }

        public TModel Get(Guid id)
        {
            var hasData = _models.TryGetValue(id, out var model);

            return hasData ? model : null;
        }

        public TModel Create(TModel model)
        {
            model.Id = Guid.NewGuid();

            _models.Add(model.Id, model);

            return model;
        }

        public TModel Update(Guid id, TModel model)
        {
            if (!_models.ContainsKey(id))
                return null;

            model.Id = id;
            _models[id] = model;

            return model;

        }

        public void Delete(Guid clientId)
        {
            _models.Remove(clientId);
        }
    }
}

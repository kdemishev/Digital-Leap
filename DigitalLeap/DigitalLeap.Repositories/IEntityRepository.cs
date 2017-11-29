using System.Collections.Generic;
using DigitalLeap.Domain.Model;
using DigitalLeap.Repositories.EntityModel;

namespace DigitalLeap.Repositories
{
    public interface IEntityRepository<TModel, TEntity> 
        where TModel: DomainModel
        where TEntity: Entity
    {
        int Add(TModel model);

        void Update(TModel model);

        void Save(TModel model);

        IEnumerable<TModel> Select();

        void Delete(int entityId);

        TModel ToModel(TEntity entity);
    }
}
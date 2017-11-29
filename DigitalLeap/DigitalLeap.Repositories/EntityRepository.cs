using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DigitalLeap.Domain.Model;
using DigitalLeap.Repositories.EntityModel;

namespace DigitalLeap.Repositories
{
    public abstract class EntityRepository<TModel, TEntity> : IEntityRepository<TModel, TEntity>
        where TModel : DomainModel
        where TEntity : Entity
    {
        protected readonly DbContext Context;
        private readonly IMapper _mapper;

        protected EntityRepository(DbContext dbContext, IMapper mapper)
        {
            Context = dbContext;
            _mapper = mapper;
        }
        public virtual int Add(TModel model)
        {
            var entity = ToEntity(model);
            Context.Set<TEntity>().Add(entity);

            Context.SaveChanges();

            return entity.Id;
        }

        public IEnumerable<TModel> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Context.Set<TEntity>().Where(predicate);
            return query.ToList().Select(ToModel);
        }

        public TModel FindFirstBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            includeProperties.ToList().ForEach(x => query.Include(x));

            return ToModel(query.FirstOrDefault(predicate));
        }


        public virtual void Update(TModel model)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(TModel model)
        {
            if (model.Id == 0)
            {
                Add(model);
            }
            else
            {
                Update(model);
            }
        }

        public virtual IEnumerable<TModel> Select()
        {
            var entities = Context.Set<TEntity>();

            return entities.Select(ToModel);
        }

        public virtual void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public virtual TModel ToModel(TEntity entity)
        {
            return _mapper.Map<TEntity, TModel>(entity);
        }

        public virtual TEntity ToEntity(TModel model)
        {
            return _mapper.Map<TModel, TEntity>(model);
        }
    }
}
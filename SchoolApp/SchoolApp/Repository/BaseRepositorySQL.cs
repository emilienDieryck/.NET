using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using School.Repository;
using SchoolApp.Models;

namespace SchoolApp.Repository
{
    public class BaseRepositorySQL<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SchoolContext _dbSchoolContext;
        public BaseRepositorySQL(SchoolContext dbSchoolContext)
        {
            _dbSchoolContext = dbSchoolContext;
        }

        public void Insert(TEntity entity)
        {
            _dbSchoolContext.Set<TEntity>().Add(entity);

            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSchoolContext?.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSchoolContext.Set<TEntity>().Where(predicate).ToList();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSchoolContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSchoolContext.Set<TEntity>().Find(id);
        }

        public bool Save(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            TEntity ent = (SearchFor(predicate)).FirstOrDefault();

            if (ent == null)
            {
                Insert(entity);
                return true;
            }
            SaveChanges();
            return false;
        }

        protected void SaveChanges()
        {
            try
            {
                _dbSchoolContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.InnerException.Message);
            }
        }

    }
}

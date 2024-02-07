
using ShirtSkirt.Contexts;

using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Repositories
{
    public abstract class BaseRepo<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;
        private readonly AppContext _appContext;

        protected BaseRepo(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        protected BaseRepo(AppContext appContext)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }

        public virtual TEntity Create(TEntity entity)
        {
            try
            {
                if (_dataContext != null)
                {
                    _dataContext.Set<TEntity>().Add(entity);
                    _dataContext.SaveChanges();
                }
                else if (_appContext != null)
                {
                    _appContext.Set<TEntity>().Add(entity);
                    _appContext.SaveChanges();
                }

                return entity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
                return null!;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                if (_dataContext != null)
                    return _dataContext.Set<TEntity>().ToList();
                else if (_appContext != null)
                    return _appContext.Set<TEntity>().ToList();
                else
                    return Enumerable.Empty<TEntity>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
                return Enumerable.Empty<TEntity>();
            }
        }

        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                if (_dataContext != null)
                    return _dataContext.Set<TEntity>().Where(expression).AsEnumerable().FirstOrDefault();
                else if (_appContext != null)
                    return _appContext.Set<TEntity>().Where(expression).AsEnumerable().FirstOrDefault();
                else
                    return null!;
                        
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
                return null!;
            }
        }

        public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            try
            {
                TEntity entityToUpdate = null!;

                if (_dataContext != null)
                    entityToUpdate = _dataContext.Set<TEntity>().FirstOrDefault(expression);
                else if (_appContext != null)
                    entityToUpdate = _appContext.Set<TEntity>().FirstOrDefault(expression);

                if (entityToUpdate != null)
                {
                    if (_dataContext != null)
                    {
                        _dataContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                        _dataContext.SaveChanges();
                    }
                    else if (_appContext != null)
                    {
                        _appContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                        _appContext.SaveChanges();
                    }
                }

                return entityToUpdate!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
                return null!;
            }
        }

        public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                TEntity? entityToDelete = null;

                if (_dataContext != null)
                    entityToDelete = _dataContext.Set<TEntity>().FirstOrDefault(predicate);
                else if (_appContext != null)
                    entityToDelete = _appContext.Set<TEntity>().FirstOrDefault(predicate);

                if (entityToDelete != null)
                {
                    if (_dataContext != null)
                    {
                        _dataContext.Set<TEntity>().Remove(entityToDelete);
                        _dataContext.SaveChanges();
                    }
                    else if (_appContext != null)
                    {
                        _appContext.Set<TEntity>().Remove(entityToDelete);
                        _appContext.SaveChanges();
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
                return false;
            }
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                if (_dataContext != null)
                    return _dataContext.Set<TEntity>().Any(predicate);
                else if (_appContext != null)
                    return _appContext.Set<TEntity>().Any(predicate);
                else
                    return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
                return false;
            }
        }
    }
}

using Core.Entity;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.EntityFramework
{
    public class EfRepository<TEntity> : IRepository<TEntity>
           where TEntity : class, IEntity, new()
    {
        private readonly DbContext context;
        public EfRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<BaseResponse<TEntity>> AddAsync(TEntity entity)
        {
            try
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return new BaseResponse<TEntity>().Success(addedEntity.Entity);
            }
            catch (Exception e)
            {
                return new BaseResponse<TEntity>().Fail(e.Message);
            }

        }

        public async Task<BaseResponse<int>> DeleteAsync(TEntity entity)
        {
            try
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return new BaseResponse<int>().Success(1);

            }
            catch (Exception e)
            {
                return new BaseResponse<int>().Fail(e.Message);
            }
        }

        public async Task<BaseResponse<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (includes.Length > 0)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }

                var result = await query.AsNoTracking().FirstOrDefaultAsync(filter);

                if (result == null)
                {
                    return new BaseResponse<TEntity>().Fail("Kayıt bulunamadı");
                }
                return new BaseResponse<TEntity>().Success(result);
            }
            catch (Exception e)
            {
                return new BaseResponse<TEntity>().Fail(e.Message);
            }

        }

        public async Task<BaseResponse<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                foreach (Expression<Func<TEntity, object>> include in includes)
                {
                    query = query.Include(include);
                }

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                var result = await query.AsNoTracking().OrderByDescending(s => s.CreateDate).ToListAsync();

                return new BaseResponse<List<TEntity>>().Success(result);
            }
            catch (Exception e)
            {
                return new BaseResponse<List<TEntity>>().Fail(e.Message);
            }
        }

        public async Task<BaseResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            try
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new BaseResponse<TEntity>().Success(addedEntity.Entity);
            }
            catch (Exception e)
            {
                return new BaseResponse<TEntity>().Fail(e.Message);
            }

        }
    }
}

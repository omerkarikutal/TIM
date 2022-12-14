using Core.Entity;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<BaseResponse<T>> GetAsync(Expression<Func<T, bool>> Filter = null, params Expression<Func<T, object>>[] includes);
        Task<BaseResponse<List<T>>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params Expression<Func<T, object>>[] includes);
        Task<BaseResponse<T>> AddAsync(T Entity);
        Task<BaseResponse<T>> UpdateAsync(T Entity);
        Task<BaseResponse<int>> DeleteAsync(T Entity);
    }
}

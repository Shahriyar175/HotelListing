using HotelListing.Data;
using System.Linq.Expressions;
using X.PagedList;

namespace HotelListing.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(Expression<Func<T, bool>>? expression = null, List<string>? includes=null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy=null);
        IPagedList<T> GetAllPaged(RequestParams requestParams, List<string>? includes=null);
        Task<T> Get(Expression<Func<T, bool>>? expression = null, List<string>? includes = null);
        Task InsertAsync(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}

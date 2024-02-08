using EFDataAccessLibrary.DomainModels;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess;

public interface IRepository <T> where T : BaseModel
{
    public IQueryable<T> NoTracking { get; }

    public IQueryable<T> Tracking { get; }

    public Task<T?> GetByIdAsync(int id);

    public Task<IEnumerable<T>> GetAll();

    public Task<int> InsertAsync(T entity);

    public Task<int> UpdateAsync(T entity);

    public Task<int> DeleteAsync(T entity);
}

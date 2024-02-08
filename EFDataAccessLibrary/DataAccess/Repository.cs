using EFDataAccessLibrary.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.DataAccess;

public class Repository<T> : IRepository<T> where T : BaseModel
{
    private WebShopContext _context { get; set; }

    public IQueryable<T> NoTracking { get; }

    public IQueryable<T> Tracking { get; }

    public Repository(WebShopContext context)
    {
        _context = context;
        NoTracking = _context.Set<T>().AsNoTracking();
        Tracking = _context.Set<T>().AsTracking();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<int> InsertAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity) 
    {  
        _context.Set<T>().Update(entity);

        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);

        return await _context.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using MyStore.Context;

namespace MyStore.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }
    }

}

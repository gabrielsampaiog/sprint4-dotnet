using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using TAQUI.Database;

namespace TAQUI.Repository
{
    public class MongoDbRepository<T> : IRepository<T> where T : class
    {
        private readonly FIAPMongoDBContext _context;

        private readonly DbSet<T> _dbSet;

        public MongoDbRepository(FIAPMongoDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(ObjectId id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(ObjectId? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Update(ObjectId? id, T entity)
        {
            var existing = await _dbSet.FindAsync(id);

            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

        }
    }
}

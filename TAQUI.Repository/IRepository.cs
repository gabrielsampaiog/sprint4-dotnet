using MongoDB.Bson;

namespace TAQUI.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(ObjectId? id);

        Task Add(T entity);

        Task Update(ObjectId? id, T entity);

        Task Delete(ObjectId id);
    }
}

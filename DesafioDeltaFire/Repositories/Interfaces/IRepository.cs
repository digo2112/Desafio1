using System.Linq.Expressions;

namespace DesafioDeltaFire.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {

        //nao violar o principio ISP


        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        //esses tres nao precisam pq estao fazendo em memoria e nao no banco de dados
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}

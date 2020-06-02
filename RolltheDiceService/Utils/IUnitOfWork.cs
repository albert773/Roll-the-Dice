using RolltheDiceService.Models;

namespace RolltheDiceService.Utils
{
    public interface IUnitOfWork
    {
        GenericRepository<TEntity> RepositoryClient<TEntity>() where TEntity : class;
        RolltheDiceDBEntities Repository();
        void SaveChanges();
    }
}
using Roll_the_Dice_Service.Models;

namespace Roll_the_Dice_Service.Utils
{
    public interface IUnitOfWork
    {
        GenericRepository<TEntity> RepositoryClient<TEntity>() where TEntity : class;
        RolltheDiceDBEntities Repository();
        void SaveChanges();
    }
}
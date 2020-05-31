using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
{
    [InjectableAttributeTransient]
    public class SalaService : IService, ISalaService
    {
        private IUnitOfWork uow;

        public SalaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Sala> GetAllSalas()
        {
            return uow.RepositoryClient<Sala>().GetAll();
        }

        public IEnumerable<Sala> GetAllSalasByUsuario(int id)
        {
            return uow.RepositoryClient<Sala>().GetMany(q => q.Usuario.usuarioId == id);
        }

        public Sala GetSalaById(int id)
        {
            return uow.RepositoryClient<Sala>().GetByID(id);
        }

        public Sala PostSala(Sala sala)
        {
            uow.RepositoryClient<Sala>().Insert(sala);
            uow.SaveChanges();
            return GetSalaById(sala.salaId);
        }

        public Sala PutSala(int id, Sala sala)
        {
            uow.RepositoryClient<Sala>().Update(sala);
            uow.SaveChanges();
            return GetSalaById(id);
        }
        public void DeleteSala(int id)
        {
            uow.RepositoryClient<Sala>().Delete(id);
            uow.SaveChanges();
        }
    }
}
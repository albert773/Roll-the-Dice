using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
{
    [InjectableAttributeTransient]
    public class EstadisticaService : IService, IEstadisticaService
    {
        private IUnitOfWork uow;

        public EstadisticaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Estadistica> GetAllEstadisticas()
        {
            return uow.RepositoryClient<Estadistica>().GetAll();
        }

        public IEnumerable<Estadistica> GetAllEstadisticasByPersonaje(int id)
        {
            //TODO - MtM Acabar llamada para que devuelva todas las estadisticas de un Personaje
            return uow.RepositoryClient<Estadistica>().GetAll();
        }

        public Estadistica GetEstadisticaById(int id)
        {
            return uow.RepositoryClient<Estadistica>().GetByID(id);
        }

        public Estadistica PostEstadistica(Estadistica estadistica)
        {
            uow.RepositoryClient<Estadistica>().Insert(estadistica);
            uow.SaveChanges();
            return GetEstadisticaById(estadistica.estadisticaId);
        }

        public Estadistica PutEstadistica(int id, Estadistica estadistica)
        {
            uow.RepositoryClient<Estadistica>().Update(estadistica);
            uow.SaveChanges();
            return GetEstadisticaById(id);
        }

        public void DeleteEstadistica(int id)
        {
            uow.RepositoryClient<Estadistica>().Delete(id);
        }
    }
}
using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class EstadisticaService : IService, IEstadisticaService
    {
        private IUnitOfWork uow;

        public EstadisticaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Estadistica> GetAllEstadisticas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estadistica> GetAllEstadisticasByPersonaje(int id)
        {
            throw new NotImplementedException();
        }

        public Estadistica GetEstadisticaById(int id)
        {
            throw new NotImplementedException();
        }

        public Estadistica PostEstadistica(Estadistica accion)
        {
            throw new NotImplementedException();
        }

        public Estadistica PutEstadistica(int id, Estadistica accion)
        {
            throw new NotImplementedException();
        }

        public void DeleteEstadistica(int id)
        {
            throw new NotImplementedException();
        }
    }
}
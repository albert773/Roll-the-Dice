using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
{
    [InjectableAttributeTransient]
    public class ArmaService : IService, IArmaService
    {
        private IUnitOfWork uow;

        public ArmaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Arma> GetAllArmas()
        {
            return uow.RepositoryClient<Arma>().GetAll();
        }

        public IEnumerable<Arma> GetAllArmasByPersonaje(int id)
        {
            return uow.RepositoryClient<Arma>().GetWithInclude(q => q.Inventario1.propietario == id, "Elemento1", "Estadistica1", "Inventario1", "NombreArma", "Rareza1");
        }

        public Arma GetArmaById(int id)
        {
            return uow.RepositoryClient<Arma>().GetWithInclude("Elemento1", "Estadistica1", "Inventario1", "NombreArma", "Rareza1").FirstOrDefault(q => q.armaId == id);
        }

        public Arma PostArma(Arma arma)
        {
            uow.RepositoryClient<Arma>().Insert(arma);
            uow.SaveChanges();
            return GetArmaById(arma.armaId);
        }

        public Arma PutArma(int id, Arma arma)
        {
            uow.RepositoryClient<Arma>().Update(arma);
            uow.SaveChanges();
            return GetArmaById(id);
        }

        public void DeleteArma(int id)
        {
            uow.RepositoryClient<Arma>().Delete(id);
            uow.SaveChanges();
        }
    }
}
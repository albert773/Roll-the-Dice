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
    public class ArmaduraService : IService, IArmaduraService
    {
        private IUnitOfWork uow;

        public ArmaduraService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Armadura> GetAllArmaduras()
        {
            return uow.RepositoryClient<Armadura>().GetAll();
        }

        public Armadura GetArmaduraById(int id)
        {
            return uow.RepositoryClient<Armadura>().GetWithInclude("Elemento1", "Estadistica1", "Inventario1", "NombreArmadura", "Rareza1").FirstOrDefault(q => q.armaduraId == id);
        }

        public IEnumerable<Armadura> GetAllArmadurasByPersonaje(int id)
        {
            return uow.RepositoryClient<Armadura>().GetWithInclude(q => q.Inventario1.propietario == id, "Elemento1", "Estadistica1", "Inventario1", "NombreArma", "Rareza1");
        }

        public Armadura PostArmadura(Armadura armadura)
        {
            uow.RepositoryClient<Armadura>().Insert(armadura);
            uow.SaveChanges();
            return GetArmaduraById(armadura.armaduraId);
        }

        public Armadura PutArmadura(int id, Armadura armadura)
        {
            uow.RepositoryClient<Armadura>().Update(armadura);
            uow.SaveChanges();
            return GetArmaduraById(id);
        }

        public void DeleteArmadura(int id)
        {
            uow.RepositoryClient<Armadura>().Delete(id);
            uow.SaveChanges();
        }
    }
}
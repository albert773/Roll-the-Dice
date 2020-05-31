﻿using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
{
    [InjectableAttributeTransient]
    public class RazaService : IService, IRazaService
    {
        private IUnitOfWork uow;

        public RazaService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Raza> GetAllRazas()
        {
            return uow.RepositoryClient<Raza>().GetAll();
        }

        public Raza GetRazaById(int id)
        {
            return uow.RepositoryClient<Raza>().GetByID(id);
        }

        public Raza PostRaza(Raza raza)
        {
            uow.RepositoryClient<Raza>().Insert(raza);
            uow.SaveChanges();
            return GetRazaById(raza.razaId);
        }

        public Raza PutRaza(int id, Raza raza)
        {
            uow.RepositoryClient<Raza>().Update(raza);
            uow.SaveChanges();
            return GetRazaById(id);
        }

        public void DeleteRaza(int id)
        {
            uow.RepositoryClient<Raza>().Delete(id);
        }
    }
}
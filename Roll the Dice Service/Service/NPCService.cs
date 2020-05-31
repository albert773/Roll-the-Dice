using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service
{
    public class NPCService : IService, INPCService
    {
        private IUnitOfWork uow;

        public NPCService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<NPC> GetAllNPCs()
        {
            return uow.RepositoryClient<NPC>().GetAll();
        }

        public IEnumerable<NPC> GetAllNPCsBySala(int id)
        {
            return uow.RepositoryClient<NPC>().GetMany(q => q.Sala.salaId == id);
        }

        public NPC GetNPCById(int id)
        {
            return uow.RepositoryClient<NPC>().GetByID(id);
        }

        public NPC PostNPC(NPC npc)
        {
            uow.RepositoryClient<NPC>().Insert(npc);
            uow.SaveChanges();
            return GetNPCById(npc.NPCId);
        }

        public NPC PutNPC(int id, NPC npc)
        {
            uow.RepositoryClient<NPC>().Update(npc);
            uow.SaveChanges();
            return GetNPCById(id);
        }

        public void DeleteNPC(int id)
        {
            uow.RepositoryClient<NPC>().Delete(id);
        }
    }
}
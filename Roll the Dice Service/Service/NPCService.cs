using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            throw new NotImplementedException();
        }

        public IEnumerable<NPC> GetAllNPCsBySala(int id)
        {
            throw new NotImplementedException();
        }

        public NPC GetNPCById(int id)
        {
            throw new NotImplementedException();
        }

        public NPC PostNPC(NPC npc)
        {
            throw new NotImplementedException();
        }

        public NPC PutNPC(int id, NPC npc)
        {
            throw new NotImplementedException();
        }

        public void DeleteNPC(int id)
        {
            throw new NotImplementedException();
        }
    }
}
using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface INPCService
    {
        IEnumerable<NPC> GetAllNPCs();
        IEnumerable<NPC> GetAllNPCsBySala(int id);
        NPC GetNPCById(int id);
        NPC PostNPC(NPC npc);
        NPC PutNPC(int id, NPC npc);
        void DeleteNPC(int id);
    }
}

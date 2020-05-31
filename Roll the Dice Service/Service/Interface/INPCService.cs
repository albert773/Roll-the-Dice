using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
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

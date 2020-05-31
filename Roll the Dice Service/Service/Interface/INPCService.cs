using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface INPCService
    {
        IEnumerable<NPC> GetAllNPCs();
        IEnumerable<NPC> GetAllNPCsBySala(int id);
        NPC GetNPCById(int id);
        NPC PostNPC(NPC npc);
        NPC PutNPC(int id, NPC npc);
        void DeleteNPC(int id);
    }
}

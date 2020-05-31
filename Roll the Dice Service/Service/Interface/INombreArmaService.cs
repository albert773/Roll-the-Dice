using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface INombreArmaService
    {
        IEnumerable<NombreArma> GetAllNombreArmas();
        NombreArma GetNombreArmaById(int id);
        NombreArma PostNombreArma(NombreArma nombreArma);
        NombreArma PutNombreArma(int id, NombreArma nombreArma);
        void DeleteNombreArma(int id);
    }
}

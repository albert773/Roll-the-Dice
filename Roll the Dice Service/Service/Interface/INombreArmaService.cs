using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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

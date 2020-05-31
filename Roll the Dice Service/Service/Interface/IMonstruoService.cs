using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IMonstruoService
    {
        IEnumerable<Monstruo> GetAllMonstruos();
        IEnumerable<Monstruo> GetAllMonstruosBySala(int id);
        Monstruo GetMonstruoById(int id);
        Monstruo PostMonstruo(Monstruo monstruo);
        Monstruo PutMonstruo(int id, Monstruo monstruo);
        void DeleteMonstruo(int id);
    }
}

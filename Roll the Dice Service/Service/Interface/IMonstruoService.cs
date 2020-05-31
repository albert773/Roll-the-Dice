using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    public interface IMonstruoService
    {
        IEnumerable<Monstruo> GetAllMonstruos();
        IEnumerable<Monstruo> GetAllMonstruosBySala(int id);
        Monstruo GetMonstruoById(int id);
        Monstruo PostMonstruo(Monstruo monstruo);
        Monstruo PutMonstruo(int id, Monstruo monstruo);
        void DeleteMonstruo(int id);
    }
}

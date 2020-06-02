using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
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

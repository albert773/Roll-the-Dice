using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    public interface IInventarioService
    {
        IEnumerable<Inventario> GetAllInventarios();
        Inventario GetInventarioById(int id);
        Inventario GetInventarioByPersonaje(int id);
        Inventario PostInventario(Inventario inventario);
        Inventario PutInventario(int id, Inventario inventario);
        void DeleteInventario(int id);
    }
}

using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IInventarioService
    {
        IEnumerable<Inventario> GetAllInventarios();
        Inventario GetInventarioById(int id);
        Inventario GetInventarioByPersonaje(int id);
        Inventario GetInventarioByUsuario(int id);
        Inventario PostInventario(Inventario inventario);
        Inventario PutInventario(int id, Inventario inventario);
        void DeleteInventario(int id);
    }
}

using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IInventarioService
    {
        IEnumerable<Inventario> GetAllInventarios();
        Inventario GetInventarioById(int id);
        Inventario GetInventarioByPersonaje(int id);
        Inventario PostInventario(Inventario inventario);
        Inventario PutInventario(int id, Inventario inventario);
        void DeleteInventario(int id);
    }
}

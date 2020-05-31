using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IAccionService
    {
        IEnumerable<Accion> GetAllAcciones();
        Accion GetAccionById(int id);
        Accion PostAccion(Accion accion);
        Accion PutAccion(int id, Accion accion);
        void DeleteAccion(int id);
    }
}

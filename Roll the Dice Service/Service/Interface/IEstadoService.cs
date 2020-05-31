using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IEstadoService
    {
        IEnumerable<Estado> GetAllEstados();
        Estado GetEstadoById(int id);
        Estado PostEstado(Estado estado);
        Estado PutEstado(int id, Estado estado);
        void DeleteEstado(int id);
    }
}

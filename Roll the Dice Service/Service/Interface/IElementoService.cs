using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IElementoService
    {
        IEnumerable<Elemento> GetAllElementos();
        Elemento GetElementoById(int id);
        Elemento PostElemento(Elemento elemento);
        Elemento PutElemento(int id, Elemento elemento);
        void DeleteElemento(int id);
    }
}

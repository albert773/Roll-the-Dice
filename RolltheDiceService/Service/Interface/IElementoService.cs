using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IElementoService
    {
        IEnumerable<Elemento> GetAllElementos();
        Elemento GetElementoById(int id);
        Elemento PostElemento(Elemento elemento);
        Elemento PutElemento(int id, Elemento elemento);
        void DeleteElemento(int id);
    }
}

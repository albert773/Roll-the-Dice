using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IIdiomaService
    {
        IEnumerable<Idioma> GetAllIdiomas();
        Idioma GetIdiomaById(int id);
        Idioma PostIdioma(Idioma idioma);
        Idioma PutIdioma(int id, Idioma idioma);
        void DeleteIdioma(int id);
    }
}

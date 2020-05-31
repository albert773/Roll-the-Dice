using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IIdiomaService
    {
        IEnumerable<Idioma> GetAllIdiomas();
        Idioma GetIdiomaById(int id);
        Idioma PostIdioma(Idioma idioma);
        Idioma PutIdioma(int id, Idioma idioma);
        void DeleteIdioma(int id);
    }
}

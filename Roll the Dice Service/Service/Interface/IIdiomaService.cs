using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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

using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IArmaService
    {
        IEnumerable<Arma> GetAllArmas();
        IEnumerable<Arma> GetAllArmasByPersonaje(int id);
        Arma GetArmaById(int id);
        Arma PostArma(Arma arma);
        Arma PutArma(int id, Arma arma);
        void DeleteArma(int id);
    }
}

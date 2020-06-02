using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IArmaService
    {
        IEnumerable<Arma> GetAllArmas();
        IEnumerable<Arma> GetAllArmasByPersonaje(int id);
        Arma GetArmaById(int id);
        Arma PostArma(Arma arma);
        Arma PutArma(int id, Arma arma);
        void DeleteArma(int id);
    }
}

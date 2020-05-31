﻿using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IRazaService
    {
        IEnumerable<Raza> GetAllRazas();
        Raza GetRazaById(int id);
        Raza PostRaza(Raza raza);
        Raza PutRaza(int id, Raza raza);
        void DeleteRaza(int id);
    }
}

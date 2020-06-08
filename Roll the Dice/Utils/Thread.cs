using RestSharp;
using Roll_the_Dice.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Roll_the_Dice.Utils
{
    public static class ThreadGUI
    {
        public static RestClient client;
        public static MenuGM mGm;
        public static MenuPlayer mPm;
        public static void threadGO()
        {
            client = new RestClient(Constants.IP);
            
            if ((Constants.Usuario.usuarioId != Constants.Sala.propietario))
            {
                mPm = new MenuPlayer();
            }
            else
            {
                mGm = new MenuGM();
            }

            while (true)
            {
                //turnTryer();
                if (Constants.Usuario.usuarioId != Constants.Sala.propietario)
                {

                    mPm.mapaSetterPos();
                    mPm.UpdateDice();
                }
                else
                {
                    mGm.mapaSetterPos();
                    mGm.UpdateDice(); 
                }
            }
        }

        /* public static async void turnTryer()
        {
            var request = new RestRequest("isMyTurn/{usuarioId}", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            request.AddParameter("usuarioId", Constants.Usuario, ParameterType.UrlSegment);
            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
            if (Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(response.Content))
            {
                
            }
        }*/
    }
}

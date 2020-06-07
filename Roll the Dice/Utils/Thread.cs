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
        static RestClient client;
        static int lastDice = 0;
        static MenuGM mGm;
        static MenuPlayer mPm;
        static bool val = true;

        public static void threadGO()
        {
            client = new RestClient(Constants.IP);

            if(Constants.Usuario.usuarioId != Constants.Sala.propietario && val == true)
            {   
                val = false;
                mPm = new MenuPlayer();
            }
            else if(Constants.Usuario.usuarioId == Constants.Sala.propietario && val == true)
            {
                val = false;
                mGm = new MenuGM();
            }

            while (true)
            {
                //diceComprobatorAsync();
                //turnTryer();
                if (Constants.Usuario.usuarioId != Constants.Sala.propietario)
                {
                    MenuPlayer.mapa.positionAllSetter();
                    mPm.UpdateDice();
                }
                else
                {
                    MenuGM.mapa.positionAllSetter();
                    mGm.UpdateDice(); 
                }
                
                

            }
        }
        public static void diceComprobatorAsync()
        {
            var request = new RestRequest("singleton/dados", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
            if (lastDice != Newtonsoft.Json.JsonConvert.DeserializeObject<int>(response.Content))
            {
                
            }
        }

        public static async void turnTryer()
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
        }
    }
}

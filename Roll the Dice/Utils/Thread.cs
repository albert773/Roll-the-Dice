using RestSharp;
using Roll_the_Dice.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Roll_the_Dice.Utils
{
    class Thread
    {
        static RestClient client;
        static int lastDice = 0;
        static MenuGM mGm = new MenuGM();
        static MenuPlayer mPm = new MenuPlayer();
        public static void threadGO()
        {
            client = new RestClient(Constants.IP);
            while (true)
            {
                diceComprobatorAsync();
                turnTryer();
            }
        }
        public static async void diceComprobatorAsync()
        {
            var request = new RestRequest("singleton/dados", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }
            if (lastDice != Newtonsoft.Json.JsonConvert.DeserializeObject<int>(response.Content))
            {
                mGm.UpdateDice(); 
                mPm.UpdateDice();
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

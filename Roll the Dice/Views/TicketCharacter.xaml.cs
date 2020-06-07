using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RestSharp;
using Roll_the_Dice.Utils;
using Roll_the_Dice.Models;
using System.Diagnostics;
using RestSharp;
using Roll_the_Dice.Utils;
using Roll_the_Dice.Models;
using System.Diagnostics;

namespace Roll_the_Dice.Views
{
    /// <summary>
    /// Lógica de interacción para TicketCharacter.xaml
    /// </summary>
    public partial class TicketCharacter : Window
    {
        RestClient client;
        Personaje personaje;
        public TicketCharacter()
        {
            client = new RestClient(Constants.IP);
            InitializeComponent();
            estatsPersonaje();
            //falta estadisticas
        }

        public async void estatsPersonaje()
        {
            var request = new RestRequest("personajes/usuario/{email}/sala/{salaId}", Method.GET);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", Constants.Token);
            request.AddParameter("email", Constants.Usuario.email, ParameterType.UrlSegment);
            request.AddParameter("salaId", Constants.Sala.salaId, ParameterType.UrlSegment);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                //TODO - Credenciales incorrectos
                return;
            }

            personaje = Newtonsoft.Json.JsonConvert.DeserializeObject<Personaje>(response.Content);

            nombreJg.Text = personaje.nombre;
            hp.Text = personaje.vida.ToString();
            lvl.Text = personaje.nivel.ToString();
            exp.Text = personaje.experiencia.ToString();
            turno.Text = personaje.turnos.ToString();
            historia.Text = personaje.misionOculta;
            fue.Text = personaje.UnionEstatPerso.FirstOrDefault(q => q.Estadistica.nombre == "Fuerza").valorBase.ToString();
            des.Text = personaje.UnionEstatPerso.FirstOrDefault(q => q.Estadistica.nombre == "Destreza").valorBase.ToString();
            con.Text = personaje.UnionEstatPerso.FirstOrDefault(q => q.Estadistica.nombre == "Constitucion").valorBase.ToString();
            car.Text = personaje.UnionEstatPerso.FirstOrDefault(q => q.Estadistica.nombre == "Carisma").valorBase.ToString();
            sab.Text = personaje.UnionEstatPerso.FirstOrDefault(q => q.Estadistica.nombre == "Sabiduria").valorBase.ToString();
            intel.Text = personaje.UnionEstatPerso.FirstOrDefault(q => q.Estadistica.nombre == "Inteligencia").valorBase.ToString();
        }
    }
}

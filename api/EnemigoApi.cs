using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace videoGame.api
{
    public class EnemigoApi
    {
        public string CrearPersonaje()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Accept", "application/json");
                
                var response = client.DownloadString("https://www.dnd5eapi.co/api/monsters");
                
                // Parsear la respuesta JSON
                JObject json = JObject.Parse(response);
                JArray monsters = (JArray)json["results"];

                Random random = new Random();
                int randomIndex = random.Next(monsters.Count);

                string monsterName = monsters[randomIndex]["name"].ToString();

                return monsterName;
            }
        }
    }
}

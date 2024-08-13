using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace videoGame.api
{
    public class EnemigoApi
    {
        public string CrearPersonaje()
        {
            try
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
            catch (WebException ex)
            {
                Console.WriteLine($"Error de red: {ex.Message}");
                return "Error de red. No se pudo obtener el personaje.";
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al procesar el JSON: {ex.Message}");
                return "Error al procesar la respuesta. No se pudo obtener el personaje.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return "Ocurrió un error inesperado. No se pudo obtener el personaje.";
            }
        }
    }
}

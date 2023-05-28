using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Desafio_Alura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/pikachu/");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            dynamic resultado = serializer.DeserializeObject(response.Content);

            foreach (KeyValuePair<string, object> entry in resultado)
            {
                var key = entry.Key;
                var value = entry.Value as string;
                Console.WriteLine(key, value);
            }
        }
    }
}

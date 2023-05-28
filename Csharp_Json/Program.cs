using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Csharp_Json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/pikachu/");

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string json = @"{ ""nome"" : ""Jose Carlos"", ""sobrenome"" : ""Macoratti"", ""email"": ""macoratti@yahoo.com"" }";

            dynamic resultado = serializer.DeserializeObject(json);

            foreach (KeyValuePair<string, object> entry in resultado)
            {
                var key = entry.Key;
                var value = entry.Value as string;
                Console.WriteLine(String.Format("{0} : {1}", key, value));
            }

            Console.WriteLine("");
            Console.WriteLine(serializer.Serialize(resultado));
            Console.WriteLine("");
            Console.ReadKey();

            List<string> Especies = new List<string> {
                "charmander",
                "squirtle",
                "bulbasaur"
            };

            Console.WriteLine($"Escolha um dos pokemons abaixo:\n");
            foreach (string pokemons in Especies)
            {
                Console.WriteLine(pokemons);
            }
            Console.Write("\nFaça sua escolha: ");

            while (true)
            {
                string escolha = Console.ReadLine().ToLower();

                if (Especies.Contains(escolha))
                {
                    Console.WriteLine($"\nVocê escolheu {escolha}");
                    break;
                }
                else
                {
                    Console.WriteLine("Pokemon indisponível!");
                }
            }
        }
    }
}

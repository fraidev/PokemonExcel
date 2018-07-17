using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PokemonExcel.Domain;
using RestSharp;
using PokemonExcel.Domain;
using Newtonsoft.Json;

namespace PokemonExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://pokeapi.co/api/v2/");
            
            var pokemonsList = new List<Pokemon>();
            for (var i = 1; i <= 151; i++)
            {
                var requestPokemons = new RestRequest("pokemon/{id}", Method.GET);
                requestPokemons.AddUrlSegment("id", i.ToString()); 
                
                IRestResponse response = client.Execute(requestPokemons);
                var content = response.Content; // raw content as string
                
                pokemonsList.Add(JsonConvert.DeserializeObject<Pokemon>(content));
            }
            
            Console.ReadLine();
        }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Serilog;

namespace PokemonExcel.Domain
{
    public class Pokemon
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private int Weight { get; set; }
        private int Height { get; set; }
        private int Base_Experience { get; set; }
        
        public static List<Pokemon> GetPokemonsList(int pokemonsCount){
    
            var client = new RestClient("http://pokeapi.co/api/v2/");
            
            //TODO argumentar maximos pokemons
            var pokemonsList = new List<Pokemon>();
            for (var i = 1; i <= pokemonsCount; i++)
            {
                var requestPokemons = new RestRequest("pokemon/{id}", Method.GET);
                requestPokemons.AddUrlSegment("id", i.ToString()); 
                
                IRestResponse response = client.Execute(requestPokemons);
                var content = response.Content; // raw content as string
                
                pokemonsList.Add(JsonConvert.DeserializeObject<Pokemon>(content));
                Log.Information("Pokemon {pokemon} added", pokemonsList[i-1].Name);
            }    
            return pokemonsList;
        }
    }
}
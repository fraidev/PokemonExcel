using System.Collections.Generic;

namespace PokemonExcel.Domain
{
    public interface IExcelExtractor
    {
        string LibName { get; }
        void Extract(string pathString, IEnumerable<Pokemon> pokemons);
    }
}
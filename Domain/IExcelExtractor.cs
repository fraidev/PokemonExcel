using System.Collections.Generic;

namespace PokemonExcel.Domain
{
    public interface IExcelExtractor
    {
        void PokemonExcelExtractor(string pathString, IEnumerable<Pokemon> pokemons);
    }
}
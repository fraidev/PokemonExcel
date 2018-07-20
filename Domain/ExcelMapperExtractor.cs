using System.Collections.Generic;
using Ganss.Excel;
using Serilog;

namespace PokemonExcel.Domain
{
    public class ExcelMapperExtractor: IExcelExtractor
    {
        //ExcelMapper
        private static void ExcelExtractorByExcelMapper(string pathString, IEnumerable<Pokemon> pokemons)
        {
            new ExcelMapper().Save(pathString, pokemons, "Pokemons");
            Log.Information("Successful importing in excel");
        }

        public static void PokemonExcelExtractor(string pathString, IEnumerable<Pokemon> pokemons)
        {
            ExcelExtractorByExcelMapper(pathString, pokemons);
        }

        void IExcelExtractor.PokemonExcelExtractor(string pathString, IEnumerable<Pokemon> pokemons)
        {
            PokemonExcelExtractor(pathString, pokemons);
        }
    }
}
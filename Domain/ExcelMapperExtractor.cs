using System.Collections.Generic;
using Ganss.Excel;
using Serilog;

namespace PokemonExcel.Domain
{
    public class ExcelMapperExtractor: IExcelExtractor
    {
        //ExcelMapper

        public string LibName => "ExcelMapper";

        public void Extract(string pathString, IEnumerable<Pokemon> pokemons)
        {
            new ExcelMapper().Save(pathString, pokemons, "Pokemons");
            Log.Information("Successful importing in excel");
        }

    }
}
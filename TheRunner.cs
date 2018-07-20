using System;
using System.Collections.Generic;
using System.Linq;
using Ganss.Excel;
using PokemonExcel.Domain;
using Serilog;
using CLAP;
using NPOI.SS.Extractor;

namespace PokemonExcel
{
    public class TheRunner
    {
        [Verb]
        public static void Run(
            [DefaultValue(@"C:\")]string pathString,
            [DefaultValue("151")]int pokemonsCount,
            [DefaultValue("FluentExcel")]string lib)
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger = log;
            
            Log.Information("The app is started");

            //Create the object list of Pokemons
            var pokemons = Pokemon.GetPokemonsList(pokemonsCount);
            Log.Information("Pokemons Colected");

            //Create or access an excel file
            System.IO.Directory.CreateDirectory(pathString);
            
            //pokemons.xlsx
            const string fileExcelName = "pokemons.xlsx";
            pathString = System.IO.Path.Combine(pathString, fileExcelName);

            if (!System.IO.File.Exists(pathString))
            {
                WhitchLib(lib, pathString, pokemons);
            }
            else
            {
                System.IO.File.Delete(pathString);
                Log.Information("Deleted old excel file");
                WhitchLib(lib, pathString, pokemons);
                
            }
            Console.ReadLine();
        }

        private static void WhitchLib(string lib, string pathString, IEnumerable<Pokemon> pokemons)
        {
            switch (lib)
            {
                case "FluentExcel":
                {
                    FluentExcelExtractor.PokemonExcelExtractor(pathString, pokemons);
                    break;
                }
                case "ExcelMapper":
                {
                    ExcelMapperExtractor.PokemonExcelExtractor(pathString, pokemons);
                    break;
                }
            }
        }
    }
}
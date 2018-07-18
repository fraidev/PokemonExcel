using System;
using System.Collections.Generic;
using System.Linq;
using Ganss.Excel;
using PokemonExcel.Domain;
using Serilog;
using CLAP;

namespace PokemonExcel
{
    public class TheRunner
    {
        [Verb]
        public static void Run(
            string pathString,
            int pokemonsCount)
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
                ExcelExtractor(pathString, pokemons);
            }
            else
            {
                System.IO.File.Delete(pathString);
                Log.Information("Deleted old excel file");
                ExcelExtractor(pathString, pokemons);
            }
            Console.ReadLine();
        }

        //Include information in an excel file
        private static void ExcelExtractor(string pathString, IEnumerable<Pokemon> pokemons)
        {
            new ExcelMapper().Save(pathString, pokemons, "Pokemons");
            Log.Information("Successful importing in excel");
        }
    }
}
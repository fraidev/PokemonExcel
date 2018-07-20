using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Ganss.Excel;
using PokemonExcel.Domain;
using Serilog;
using CLAP;
using NPOI.SS.Extractor;
using IExcelExtractor = NPOI.SS.Extractor.IExcelExtractor;

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
            var extractors = new List<Domain.IExcelExtractor>
            {
                new FluentExcelExtractor(),
                new ExcelMapperExtractor()
            };


            foreach (var extractor in extractors)
            {
                if (extractor.LibName == lib)
                {
                    extractor.Extract(pathString, pokemons);
                }
            }
        }
    }
}
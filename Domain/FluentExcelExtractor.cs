using System.Collections.Generic;
using FluentExcel;
using Ganss.Excel;
using Serilog;

namespace PokemonExcel.Domain
{
    public class FluentExcelExtractor:Pokemon
    {
        //ExcelMapper
        private static void ExcelExtractorByExcelMapper(string pathString, IEnumerable<Pokemon> pokemons)
        {
            new ExcelMapper().Save(pathString, pokemons, "Pokemons");
            Log.Information("Successful importing in excel");
        }
        
        //FluentExcel
        private static void ExcelExtractorByFluentExcel(string pathString, IEnumerable<Pokemon> pokemons)
        {
            var fc = Excel.Setting.For<Pokemon>();
            fc.Property(r => r.Id)
                .HasExcelIndex(0)
                .HasExcelTitle("Id");
            
            fc.Property(r => r.Name)
                .HasExcelIndex(1)
                .HasExcelTitle("Name");
            
            fc.Property(r => r.Weight)
                .HasExcelIndex(2)
                .HasExcelTitle("Weight");
            
            fc.Property(r => r.Height)
                .HasExcelIndex(3)
                .HasExcelTitle("Height");
            
            fc.Property(r => r.BaseExperience)
                .HasExcelIndex(4)
                .HasExcelTitle("BaseExperience");
            
            pokemons.ToExcel(pathString);
            Log.Information("Successful importing in excel");
        }

        protected static void PokemonExcelExtractor(string lib,string pathString, IEnumerable<Pokemon> pokemons)
        {
            switch (lib)
            {
                case "ExcelMapper":
                    ExcelExtractorByExcelMapper(pathString, pokemons);
                    break;
                case "FluentExcel":
                    ExcelExtractorByFluentExcel(pathString, pokemons);
                    break;
            }
        }
    }
}
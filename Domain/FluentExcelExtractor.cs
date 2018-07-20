using System.Collections.Generic;
using FluentExcel;
using Serilog;

namespace PokemonExcel.Domain
{
    
    public class FluentExcelExtractor:IExcelExtractor
    {
        //FluentExcel
        public string LibName => "FluentExcel";

        public void Extract(string pathString, IEnumerable<Pokemon> pokemons)
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
        
    }
}
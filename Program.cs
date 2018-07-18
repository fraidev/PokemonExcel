using System;
using System.Collections.Generic;
using Ganss.Excel;
using PokemonExcel.Domain;
using Serilog;
using CLAP;

namespace PokemonExcel
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Parser.Run<TheRunner>(args);
        }
    }
}
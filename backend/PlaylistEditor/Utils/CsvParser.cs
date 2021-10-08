using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;

using PlaylistEditor.Models;

namespace PlaylistEditor.Utils
{
    public class CsvParser
    {

        public delegate object ParseLine(string[] line);
        
        public static List<TLine> ParseCsvFile<TLine>(string filename, ParseLine parseFunc) where TLine : class
        {
            using var reader = new StreamReader(Path.Combine("Resources/csv", filename));
            reader.ReadLine();
            var result = new List<TLine>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = Regex.Replace(line, "\"", "");
                string[] row = line.Split(',');
                TLine parsedLine;
                try
                {
                    parsedLine = parseFunc(row) as TLine;
                }
                catch (FormatException )
                {
                    continue;
                }

                if (parsedLine == null)
                {
                    continue;
                }
                result.Add(parsedLine);
            }
            return result;
        }
    }
}

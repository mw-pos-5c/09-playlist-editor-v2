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
        public static List<TLine> ParseCsvFile<TLine>(string filename) where TLine : class
        {
            using var reader = new StreamReader(Path.Combine("Resources/csv", filename));
            string line;

            var result = new List<TLine>();
            
            while ((line = reader.ReadLine()) != null)
            {
                line = Regex.Replace(line, "\"", "");
                string[] row = line.Split(',');

                TLine lineObj;
                try
                {
                    switch (typeof(TLine))
                    {
                        case var type when type == typeof(Playlist):
                            lineObj = ParsePlaylist(row) as TLine;
                            break;
                        default: continue;
                    }

                }
                catch (FormatException)
                {
                    continue;
                }

                if (lineObj == null)
                {
                    continue;
                }
                
                result.Add(lineObj);
            }

            return result;
        }

        private static Playlist ParsePlaylist(string[] line)
        {
            if (line.Length != 2) return null;

            return new Playlist {
                Id = int.Parse(line[0]),
                Name = line[1]
            };
        }
        
        private static 

    }
}

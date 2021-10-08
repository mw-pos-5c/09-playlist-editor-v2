using System;
using System.Globalization;

namespace PlaylistEditor.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public long Bytes { get; set; }
        public double UnitPrice { get; set; }
        
        public static Track ParseCsvLine(string[] line)
        {
            if (line.Length != 9) return null;
            var track = new Track
                {
                    Id = int.Parse(line[0]),
                    Name = line[1],
                    AlbumId = int.Parse(line[2]),
                    MediaTypeId = int.Parse(line[3]),
                    GenreId = int.Parse(line[4]),
                    Composer = line[5],
                    Milliseconds = int.Parse(line[6]),
                    Bytes = long.Parse(line[7]),
                    UnitPrice = Double.Parse(line[8], CultureInfo.InvariantCulture)
                };

            return track;
        }
    }
}

namespace PlaylistEditor.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public static Genre ParseCsvLine(string[] line)
        {
            if (line.Length != 2) return null;

            return new Genre {
                Id = int.Parse(line[0]),
                Name = line[1]
            };
        }
    }
}

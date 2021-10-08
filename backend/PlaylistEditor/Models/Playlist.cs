namespace PlaylistEditor.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Playlist ParseCsvLine(string[] line)
        {
            if (line.Length != 2) return null;

            return new Playlist {
                Id = int.Parse(line[0]),
                Name = line[1]
            };
        }
    }
}

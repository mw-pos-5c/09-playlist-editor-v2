namespace PlaylistEditor.Models
{
    public class PlaylistTrack
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        
        public static PlaylistTrack ParseCsvLine(string[] line)
        {
            if (line.Length != 2) return null;

            return new PlaylistTrack {
                PlaylistId = int.Parse(line[0]),
                TrackId = int.Parse(line[1])
            };
        }
        
    }
}

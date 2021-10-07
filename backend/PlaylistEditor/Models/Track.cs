namespace PlaylistEditor.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlbumId { get; set; }
        public string MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public double UnitPrice { get; set; }
    }
}

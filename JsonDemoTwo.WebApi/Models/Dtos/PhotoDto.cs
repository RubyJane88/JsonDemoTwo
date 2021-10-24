namespace JsonDemoTwo.Models.Dtos
{
    public sealed class PhotoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

        public string AlbumId { get; set; }
        
    }
}
namespace EldenRingWiki.Models
{
    public class LocationResponse
    {
        public bool Success { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public List<Location>? Data { get; set; }  // Change Npc to Location
    }

    public class Location
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}

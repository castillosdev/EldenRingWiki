namespace EldenRingWiki.Models
{
public class CreatureResponse
{
    public bool Success { get; set; }
    public int Count { get; set; }
    public int Total { get; set; }
    public List<Creature>? Data { get; set; }
}
public class Creature{
    public string ? Id { get; set; }
    public string ? Name { get; set; }
    public string ? Image { get; set; }
    public string ? Description { get; set; }
    public string ? Location { get; set; }
    public string[] ?  drops { get; set; }
}

}

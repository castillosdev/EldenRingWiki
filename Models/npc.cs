namespace EldenRingWiki.Models
{
    public class NpcResponse
{
    public bool Success { get; set; }
    public int Count { get; set; }
    public int Total { get; set; }
    public List<Npc> ? Data { get; set; }
}

public class Npc
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Quote { get; set; }
    public string? Location { get; set; }
    public string? Role { get; set; }
}

}

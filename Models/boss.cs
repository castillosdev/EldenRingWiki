namespace EldenRingWiki.Models
{
public class BossResponse
{
    public bool Success { get; set; }
    public int Count { get; set; }
    public int Total { get; set; }
    public List<Boss>? Data { get; set; }
}
public class Boss {
    public string?  Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string[]? drops { get; set; }
    public string? healthPoints { get; set; }
}

}

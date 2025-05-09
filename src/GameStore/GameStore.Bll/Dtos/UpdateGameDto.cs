namespace GameStore.Bll.Dtos;

public class UpdateGameDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Key { get; set; }
    public string? Description { get; set; }
    public List<Guid> GenreIds { get; set; }
    public List<Guid> PlatformIds { get; set; }
}


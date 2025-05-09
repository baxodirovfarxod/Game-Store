namespace GameStore.Dal.Entities;

public class Game
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public string? Description { get; set; }
    public ICollection<GameGenre> GameGenres { get; set; }
    public ICollection<GamePlatform> GamePlatforms { get; set; }
}


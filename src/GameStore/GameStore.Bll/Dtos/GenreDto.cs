namespace GameStore.Bll.Dtos;

public class GenreDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentGenreId { get; set; }
}


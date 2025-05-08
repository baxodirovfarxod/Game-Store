namespace GameStore.Bll.Dtos;

public class GenreCreateDto
{
    public string Name { get; set; }
    public Guid? ParentGenreId { get; set; }
}

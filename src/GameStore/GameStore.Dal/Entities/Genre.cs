using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Dal.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentGenreId { get; set; }
        public Genre? ParentGenre { get; set; }
        public ICollection<Genre> SubGenres { get; set; } = new List<Genre>();
    }


}

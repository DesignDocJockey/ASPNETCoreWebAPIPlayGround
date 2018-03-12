using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class SneakerDto
    {
        public int Id { get; set; }
        public string SneakerName { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public ICollection<PlayerDto> WornByPlayers { get; set; } = new List<PlayerDto>();
    }
}

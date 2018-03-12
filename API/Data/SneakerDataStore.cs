using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public sealed class SneakerDataStore
    {
        private static readonly SneakerDataStore _Instance = new SneakerDataStore();
        private IEnumerable<SneakerDto> _Sneakers { get; }

        public static SneakerDataStore Instance => _Instance;
        public IEnumerable<SneakerDto> GetSneakers() { return _Sneakers; }

        private SneakerDataStore()
        {
            _Sneakers = new List<SneakerDto>()
            {
                    new SneakerDto()
                                 {     Id = 1,
                                       SneakerName = "Nike Hyperdunk 2008",
                                       Description = "This is the OG Hyperdunk",
                                       ReleaseYear = 2008,
                                       Tags = new List<string>() { "Redeem Team", "OG Hyperdunk", "Kobe", "Olympics"},
                                       WornByPlayers = new List<PlayerDto>
                                        {
                                            new PlayerDto() { Id = 1, FirstName="Kobe", LastName = "Bryant"},
                                            new PlayerDto() { Id = 2, FirstName="Pau", LastName = "Gasol"}
                                        }
                                  },
                new SneakerDto() { Id = 2,
                                   SneakerName = "Nike Hyperfuse ",
                                   Description = "This is the OG Hyperfuse",
                                   ReleaseYear = 2008,
                                   Tags = new List<string>() { "Celtics", "OG Hyperfuse", "Celtics", "Rando"},
                                      WornByPlayers = new List<PlayerDto>
                                        {
                                            new PlayerDto() { Id = 3, FirstName="Ranjon", LastName = "Rondo"},
                                            new PlayerDto() { Id = 4, FirstName="Kevin", LastName = "Durant"}
                                        }
                                  },
                new SneakerDto() {
                                    Id = 3,
                                    SneakerName = "Jordan 1",
                                    Description = "This is the OG Air Jordan 1",
                                    ReleaseYear = 1984,
                                    Tags = new List<string>() { "Jordan", "Retro", "Slam Dunk"},
                                    WornByPlayers = new List<PlayerDto>
                                        {
                                            new PlayerDto() { Id = 5, FirstName="Michael", LastName = "Jordan"}
                                        }
                                   }
            };
        }
    }
}

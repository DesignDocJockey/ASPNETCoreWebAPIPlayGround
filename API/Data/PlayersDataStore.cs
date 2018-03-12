using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public sealed class PlayersDataStore
    {
        private static readonly PlayersDataStore _Instance = new PlayersDataStore();
        private ICollection<PlayerDto> _Players;

        public static PlayersDataStore Instance => _Instance;
        public IEnumerable<PlayerDto> GetPlayers() { return _Players; }

        private PlayersDataStore()
        {
            _Players = new List<PlayerDto>()
            {
                  new PlayerDto() { Id = 1, FirstName="Kobe", LastName = "Bryant"},
                  new PlayerDto() { Id = 2, FirstName="Pau", LastName = "Gasol"},
                  new PlayerDto() { Id = 3, FirstName="Ranjon", LastName = "Rondo"},
                  new PlayerDto() { Id = 4, FirstName="Kevin", LastName = "Durant"},
                  new PlayerDto() { Id = 5, FirstName="Michael", LastName = "Jordan"}
            };
        }

        public PlayerDto AddNewPlayer(CreatePlayerDto player)
        {
            var maxId = _Players.Max(i => i.Id);
            var newPlayer = new PlayerDto()
            {
                Id = (maxId + 1),
                FirstName = player.FirstName,
                LastName = player.LastName
            };
            _Players.Add(newPlayer);
            return newPlayer;
        }
    }
}

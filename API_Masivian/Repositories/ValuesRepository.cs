using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Masivian.Models;
using System.Linq;

namespace API_Masivian.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        public static List<Roulette> Roulettes = new List<Roulette>();
        public static List<Bet> Bets = new List<Bet>();
        public static List<Client> Clients = new List<Client>();

        public Task<List<Roulette>> GetAllRoulettesAsync()
        {
            return Task.FromResult(Roulettes);
        }

        public Task<string> AddRouletteAsync()
        {
            return Task.FromResult(LogicRepository.AddRoullete());
        }

        public Task<bool> OpenRouletteAsync(string id)
        {
           return Task.FromResult(LogicRepository.OpenRoulette(id));
        }

        public Task<bool> BetInRouletteAsync(Bet _bet)
        {
            return Task.FromResult(LogicRepository.BetInRoulette(_bet));           
        }

        public Task<ICollection<Client>> CloseRouletteAsync(string id)
        {
            return Task.FromResult(LogicRepository.CloseRoulette(id));
        }
    }
}

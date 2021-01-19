using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Masivian.Extensions;
using API_Masivian.Models;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace API_Masivian.Repositories
{
    public class CachedValuesRepository : IValuesRepository
    {
        private const string ROULETTES_KEY = "Roulettes";
        private const string BETS_KEY = "Bets";

        private readonly ValuesRepository _repository;
        private readonly IDistributedCache _cache;

        public CachedValuesRepository(ValuesRepository repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public Task<List<Roulette>> GetAllRoulettesAsync() =>
            _cache.GetOrCreateAsync(ROULETTES_KEY, _repository.GetAllRoulettesAsync);

        public async Task<string> AddRouletteAsync()
        {
            string id = await _repository.AddRouletteAsync();
            await _cache.RemoveAsync(ROULETTES_KEY);
            return id;
        }

        public async Task<bool> OpenRouletteAsync(string id)
        {
            bool isOpen = await _repository.OpenRouletteAsync(id);
            await _cache.RemoveAsync(ROULETTES_KEY);
            return isOpen;
        }

        public async Task<bool> BetInRouletteAsync(Bet _bet)
        {
            bool isSuccessful = await _repository.BetInRouletteAsync(_bet);
            await _cache.SetStringAsync(BETS_KEY, JsonConvert.SerializeObject(_bet));
            return isSuccessful;
        }

        public async Task<ICollection<Client>> CloseRouletteAsync(string id)
        {
            ICollection<Client> Winners = await _repository.CloseRouletteAsync(id);
            return Winners;
        }
    }
}

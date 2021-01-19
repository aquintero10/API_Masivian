using System.Collections.Generic;
using System.Threading.Tasks;
using API_Masivian.Models;

namespace API_Masivian.Repositories
{
    public interface IValuesRepository
    {
        Task<List<Roulette>> GetAllRoulettesAsync();

        Task<string> AddRouletteAsync();

        Task<bool> OpenRouletteAsync(string id);

        Task<bool> BetInRouletteAsync(Bet _bet);

        Task<ICollection<Client>> CloseRouletteAsync(string id);
    }
}

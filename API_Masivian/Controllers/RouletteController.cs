using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Masivian.Contracts;
using API_Masivian.Repositories;
using API_Masivian.Models;

namespace API_Masivian.Controllers
{
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IValuesRepository _valuesRepository;
        public RouletteController(IValuesRepository valuesRepository) =>
            _valuesRepository = valuesRepository;

        [HttpPost(ApiRoutes.AddRoulette)]
        public async Task<ActionResult> AddRouletteAsync()
        {
            string id = await _valuesRepository.AddRouletteAsync();

            return Ok(id);
        }

       [HttpPost(ApiRoutes.OpenRoulette)]
        public async Task<ActionResult> OpenRouletteAsync([FromBody] string id)
        {
            bool isOpen = await _valuesRepository.OpenRouletteAsync(id);

            if (isOpen)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost(ApiRoutes.BetInRoulette)]
        public async Task<ActionResult> BetInRouletteAsync([FromBody] Bet _bet, [FromHeader] string _id_client)
        {
            _bet.id_client = _id_client;
            bool isSuccesful= await _valuesRepository.BetInRouletteAsync(_bet);

            if (isSuccesful)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost(ApiRoutes.CloseRoulette)]
        public async Task<ActionResult<IEnumerable<Client>>> CloseRouletteAsync([FromBody] string id)
        {
            ICollection<Client> Winners = await _valuesRepository.CloseRouletteAsync(id);

            if (Winners.Count>0)
                return Ok(Winners);
            else
                return BadRequest();
        }

        [HttpGet(ApiRoutes.GetAllRoulettes)]
        public async Task<ActionResult<IEnumerable<Roulette>>> GetAllRoulettesAsync()
        {
            var result = await _valuesRepository.GetAllRoulettesAsync();

            return Ok(result);
        }
    }
}

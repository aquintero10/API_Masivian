using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Masivian.Models;

namespace API_Masivian.Repositories
{
    public class LogicRepository : ValuesRepository
    {
        public static string AddRoullete()
        {
            Guid _id = Guid.NewGuid();
            Roulettes.Add(new Roulette { id = _id });
            return _id.ToString();
        }

        public static bool OpenRoulette(string id)
        {
            List<Roulette> OpenRoulette = Roulettes.Where(x => x.id == Guid.Parse(id)).ToList();
            OpenRoulette.ForEach(x => x.isOpen = true);
            return OpenRoulette.Count > 0;
        }

        public static bool BetInRoulette(Bet _bet)
        {
            if (Roulettes.Any(roullete => roullete.id == _bet.id_roullete && roullete.isOpen))
            {
                Bets.Add(_bet);
                if(!Clients.Any(client=> client.id_client == _bet.id_client))
                {
                    Clients.Add(new Client { id_client = _bet.id_client });
                }

                Clients.Where(client => client.id_client == _bet.id_client)
                    .ToList()
                    .ForEach(client => 
                    { 
                        client.balance -= _bet.amount;
                        client.earnings = 0;
                        client.isWinner = false;
                    });

                return true;
            }
            else
                return false;
        }

        public static ICollection<Client> CloseRoulette(string id)
        {
            if(Roulettes.Any(roullete => roullete.id.ToString() == id && roullete.isOpen))
            {
                Roulettes.Where(roullete => roullete.id.ToString() == id)
                    .ToList()
                    .ForEach(roulette => roulette.isOpen = false);

                return GetClientsWinners();
            }
            else
            {
                return new List<Client>();
            }
        }

        private static List<Client> GetClientsWinners()
        {
            int winning_number = new Random().Next(0, 37);
            string winning_color = (winning_number % 2 == 0 ? "Red" : "Black");
            List<Bet> BetsWinners = Bets.Where(bet => bet.colour == winning_color && bet.number != winning_number).ToList();
            Bet Winner = Bets.Where(bet => bet.number == winning_number).FirstOrDefault();

            if (Clients.Count > 0)
            {
                List<Client> Winners = Clients.Join(BetsWinners, client => client.id_client,
                                        bets => bets.id_client,
                                        (client, bets) => client).ToList();

                foreach(Client client in Winners)
                {
                    client.isWinner = true;
                    client.earnings = BetsWinners.Where(i => i.id_client == client.id_client).Select(bet => bet.amount).First() * 1.8;
                    client.balance += client.earnings;
                }
            
                if (Winner != null)
                {
                    Clients.Where(client => client.id_client == Winner.id_client)
                     .ToList()
                     .ForEach(client =>
                     {
                         client.isWinner = true;
                         client.earnings = Winner.amount * 5;
                         client.balance += client.earnings;
                     });
                }
                return Clients;
            }
            else
            {
                return new List<Client>();
            }
        }
    }
}

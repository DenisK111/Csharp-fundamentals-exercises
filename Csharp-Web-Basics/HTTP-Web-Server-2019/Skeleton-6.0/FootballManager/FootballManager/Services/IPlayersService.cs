using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public interface IPlayersService
    {
        void AddPlayerToDb(CreatePlayerInputModel player,string userId);

        IEnumerable<PlayersViewModel> GetAllPlayers();

        IEnumerable<PlayersViewModel> GetPlayersFromUserCollection(string username);

        void RemovePlayerFromCollection(string username, int playerId);

       bool AddPlayerToUserCollection(string playerId,string userId);
        

    }
}

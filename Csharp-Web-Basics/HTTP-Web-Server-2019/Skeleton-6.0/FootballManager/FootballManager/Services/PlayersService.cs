using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FootballManager.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly FootballManagerDbContext context;

        public PlayersService(FootballManagerDbContext context)
        {
            this.context = context;
        }
        public void AddPlayerToDb(CreatePlayerInputModel model,string userId)
        {
            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = HttpUtility.UrlDecode(model.ImageUrl),
                Description = model.Description,
                Endurance = model.Endurance,
                Speed = model.Speed,
                Position = model.Position,


            };
            context.Players.Add(player);
            context.SaveChanges();
            var user = context.Users.First(x => x.Username == userId);

            var entry = new UserPlayer()
            {
                Player = player,
                User = user,
                UserId = user.Id,
                PlayerId = player.Id

            };

            context.UserPlayers.Add(entry);

            context.SaveChanges();
        }

        public bool AddPlayerToUserCollection(string playerId,string userId)
        {
            var player = context.Players.First(x => x.Id == int.Parse(playerId));

            var user = context.Users.First(u => u.Username == userId);

            if (this.context.UserPlayers.Any(x => x.PlayerId == player.Id && x.UserId == user.Id))
            {
                return false;
            }

            context.UserPlayers.Add(new UserPlayer
            {
                Player = player,
                User = user!,
                PlayerId = player.Id,
                UserId = user!.Id

            });

            context.SaveChanges();

            return true;
        }

        public IEnumerable<PlayersViewModel> GetAllPlayers()
        {
            var response = context.Players.Select(
               p => new PlayersViewModel
               {
                   Description = p.Description,
                   FullName = p.FullName,
                   Endurance = p.Endurance,
                   Speed = p.Speed,
                   Position = p.Position,
                   ImageUrl = p.ImageUrl,
                   Id = p.Id
               }).ToList();

            return response;
        }

        public IEnumerable<PlayersViewModel> GetPlayersFromUserCollection(string username)
        {
            var players = context.Users
               .Include(u => u.UserPlayers)
               .ThenInclude(up => up.Player)
               .Where(x => x.Username == username)
               .First()
               .UserPlayers
               .Select(p => new PlayersViewModel
               {
                   FullName = p.Player.FullName,
                   ImageUrl = p.Player.ImageUrl,
                   Endurance = p.Player.Endurance,
                   Speed = p.Player.Speed,
                   Id = p.PlayerId,
                   Position = p.Player.Position,
                   Description = p.Player.Description,

               })
               .ToList();

            return players;
        }

        public void RemovePlayerFromCollection(string username, int playerId)
        {
            var entry = context.UserPlayers.Where(x => x.PlayerId == playerId && x.User.Username == username).First();

            this.context.Remove(entry);
            context.SaveChanges();
        }
    }
}

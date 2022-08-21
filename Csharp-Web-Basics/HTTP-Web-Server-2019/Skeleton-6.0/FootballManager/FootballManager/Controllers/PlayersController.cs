using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Common;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
     
        private readonly IPlayersService service;

        public PlayersController(IPlayersService service, Request request) : base(request)
        {
            
            this.service = service;
        }

        public Response All()
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");

            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var response = service.GetAllPlayers();
            var viewModel = new
            {
                IsAuthenticated = this.User.IsAuthenticated,
                Players = response
            };
            return this.View(viewModel);
        }

        public Response Add()
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");
            return View(new { IsAuthenticated = true });
        }

        [HttpPost]
        public Response Add(CreatePlayerInputModel model)
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");


            if (model.Position.Length<5 || model.FullName.Length>20)
            {
                return this.Add();
            }

            if (model.FullName.Length < 5 || model.FullName.Length > 80)
            {
                return this.Add();
            }
            if (model.Speed < 0 || model.Speed > 10)
            {
                return this.Add();
            }
            if (model.Endurance < 0 || model.Endurance > 10)
            {
                return this.Add();
            }
            if (model.Description.Length>200)
            {
                return this.Add();
            }

            service.AddPlayerToDb(model, this.User.Id);
           

            return Redirect("/");
        }

        public Response AddToCollection(string playerId)
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");
            if (!service.AddPlayerToUserCollection(playerId,this.User.Id))
            {
                return Redirect("/");
            }
            return Redirect("/Players/All");
        }

        public Response Collection()
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");
            var players = service.GetPlayersFromUserCollection(this.User.Id);
            var viewModel = new
            {
                IsAuthenticated = true,
                Players = players,
            };

            return this.View(viewModel);
        }

        public Response RemoveFromCollection(string playerId)
        {
            if (!this.User.IsAuthenticated)
                return this.Redirect("/Users/Login");
            service.RemovePlayerFromCollection(this.User.Id, int.Parse(playerId));

            return Redirect("/Players/Collection");



        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Player.Models;
using Player.Services;

namespace Player.API.Controllers
{
    [Authorize]
    public class PlayerController : ApiController
    {
        private readonly Lazy<IPlayerService> _playerService;

        public PlayerController()
        {
            _playerService = new Lazy<IPlayerService>(() =>
                new PlayerService(Guid.Parse(User.Identity.GetUserId())));
        }

        public PlayerController(Lazy<IPlayerService> playerService)
        {
            _playerService = playerService;
        }

        public IHttpActionResult GetAll()
        {
            IEnumerable<PlayerListItem> players = _playerService.Value.GetPlayers();
            return Ok(players);
        }

        public IHttpActionResult Get(int id)
        {
            var player = _playerService.Value.GetPlayerById(id);
            return Ok(player);
        }

        public IHttpActionResult Post(PlayerCreate player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_playerService.Value.CreatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(PlayerEdit player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_playerService.Value.UpdatePlayer(player))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_playerService.Value.DeletePlayer(id))
                return InternalServerError();

            return Ok();
        }
    }
}

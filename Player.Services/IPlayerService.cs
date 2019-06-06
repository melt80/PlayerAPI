using Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Services
{
    public interface IPlayerService
    {
        bool CreatePlayer(PlayerCreate model);
        IEnumerable<PlayerListItem> GetPlayers();
        PlayerDetail GetPlayerById(int playerId);
        bool UpdatePlayer(PlayerEdit model);
        bool DeletePlayer(int playerId);
    }
}

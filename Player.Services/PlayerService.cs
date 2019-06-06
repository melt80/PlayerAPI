using Player.Data;
using Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly Guid _userId;

        public PlayerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlayer(PlayerCreate model)
        {
            var entity =
                new Data.Player()
                {
                    OwnerId = _userId,
                    Rank = model.Rank,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Position = model.Position,
                    Injured = model.Injured,
                    Drafted = model.Drafted,
                    Note = model.Note,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdatePlayer(PlayerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == model.PlayerId);

                entity.Rank= model.Rank;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Position = model.Position;
                entity.Injured = model.Injured;
                entity.Drafted = model.Drafted;
                entity.Note = model.Note;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Select(
                            e =>
                                new PlayerListItem
                                {
                                    PlayerId = e.PlayerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public PlayerDetail GetPlayerById(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == playerId);
                return
                    new PlayerDetail
                    {
                        PlayerId = entity.PlayerId,
                        Rank = entity.Rank,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Position = entity.Position,
                        Injured = entity.Injured,
                        Drafted = entity.Drafted,
                        Note = entity.Note,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool DeletePlayer(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == playerId);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

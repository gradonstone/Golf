using Golf.Domain.Entities;
using Golf.Domain.Repositories;

namespace Golf.Persistence
{
    public class PlayerRepository : IPlayerRepository
    {
        public Player? GetPlayer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

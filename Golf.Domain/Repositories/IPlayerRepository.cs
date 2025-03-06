using Golf.Domain.Entities;

namespace Golf.Domain.Repositories
{
    public interface IPlayerRepository
    {
        public Player? GetPlayer(Guid id);
    }
}

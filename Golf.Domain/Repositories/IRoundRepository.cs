using Golf.Domain.Entities;

namespace Golf.Domain.Repositories
{
    public interface IRoundRepository
    {
        public Round? GetRound(Guid id);
    }
}

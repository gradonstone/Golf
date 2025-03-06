using Golf.Domain.Entities;

namespace Golf.Domain.Repositories
{
    public interface IRoundRepository
    {
        public Round? GetRoundById(Guid id);
    }
}

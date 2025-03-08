using Golf.Domain.Entities;
using Golf.Domain.Repositories;

namespace Golf.Application
{
    public class ScoreService
    {
        private IRoundRepository _roundRepository;

        public ScoreService(IRoundRepository roundRepository)
        {
        }

        public void AddScore()
        {
        }
    }
}

using Golf.Domain.Entities;
using Golf.Domain.Repositories;

namespace Golf.Application
{
    public class ScoreService
    {
        private IRoundRepository _roundRepository;
        private IScoreRepository _scoreRepository;

        public ScoreService(IRoundRepository roundRepository, IScoreRepository scoreRepository)
        {
            _roundRepository = roundRepository;
            _scoreRepository = scoreRepository;
        }

        public void AddScore(Guid PlayerId, Guid roundId, Score score)
        {
            Round round = _roundRepository.GetRoundById(roundId);
            Player player = round.IsPlayerPlaying(PlayerId);


            _scoreRepository.AddScore(score);

            round.AddScore(PlayerId, score);
        }
    }
}

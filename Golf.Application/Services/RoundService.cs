using Golf.Domain.Entities;
using Golf.Domain.Repositories;

namespace Golf.Application.Services
{
    public class RoundService
    {
        private ICourseRepository _courseRepository { get; init; }
        private IEmailService _emailService { get; init; }
        private IRoundRepository _roundRepository { get; init; }
        private IPlayerRepository _playerRepository { get; init; }

        public RoundService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void SetupRound(Guid CourseId)
        {
            var course = _courseRepository.GetCourse(CourseId);

            // TODO: Fix to return Result object
            if (course is null)
            {
                throw new Exception("Course not found");
            }

            var round = new Round(course);
            _roundRepository.Add(round);
        }

        public void AddPlayerToRound(Guid roundId, Guid playerId)
        {
            // Order of things to happen
            // 1. Check if player is already in round
            // 2. Send invite to player

            var round = _roundRepository.GetRound(roundId);
            var player = _playerRepository.GetPlayer(playerId);

            if (round.IsPlayerPlaying(player.Id))
            {
                throw new Exception("Player is already playing in round");
            }

            round.AddPlayer(player);
        }


        public void StartRound()
        {
            throw new NotImplementedException();
        }

        public void EndRound()
        {
            throw new NotImplementedException();
        }

        public void AddPlayerToRound()
        {
            throw new NotImplementedException();
        }

        public void RemovePlayerFromRound()
        {
            throw new NotImplementedException();
        }

        public void AddStrokeToPlayer()
        {
            throw new NotImplementedException();
        }
    }
}

public interface IEmailService
{
    void SendEmail(string email, string subject, string body);
}
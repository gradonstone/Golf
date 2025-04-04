using Golf.Domain.Abstractions;

namespace Golf.Domain.Entities
{
    public class Round : BaseEntity
    {
        public RoundStatus Status { get; set; }

        private HashSet<Player> Players { get; set; }
        private List<PlayerScore> _playerScores = new();
        public IReadOnlyCollection<PlayerScore> PlayerScores => _playerScores.AsReadOnly();

        public Course Course { get; init; }


        public Round(Course course) : base(Guid.NewGuid())
        {
            Course = course;
            _playerScores = new List<PlayerScore>();
        }

        public static Round CreateRound(Course course)
        {
            return new Round(course);
        }


        public void Start()
        {
            Console.WriteLine("Golf Game Started");
        }

        public void Stop()
        {
            Console.WriteLine("Golf Game Stopped");
        }

        public void AddStroke(Player player, Hole hole, StrokeType strokeType)
        {
            if (!Course.GetHoles().Contains(hole))
            {
                throw new Exception("Hole not found in course");
            }

            if (!IsPlayerPlaying(player.Id))
            {
                throw new Exception("Player is not playing");
            }

            if (!_playerScores.Any(ps => ps.PlayerId == player.Id))
            {
                _playerScores.Add(new PlayerScore(player.Id));
            }

            _playerScores.First(ps => ps.PlayerId == player.Id).AddStroke(hole, strokeType);

        }


        public bool IsPlayerPlaying(Guid playerId)
        {
            return Players.Any(p => p.Id == playerId);
        }

        public int StrokesForHole(Player playerId, Hole hole)
        {
            if (!IsPlayerPlaying(playerId.Id))
            {
                throw new Exception("Player is not playing");
            }

            if (!_playerScores.Any(ps => ps.PlayerId == playerId.Id))
            {
                throw new Exception("Player has not played hole");
            }

            return _playerScores.FirstOrDefault(ps => ps.PlayerId == playerId.Id)?.TotalStrokesForHole(hole) ?? 0;
        }

        public void AddPlayer(Player player)
        {
            if (IsPlayerPlaying(player.Id))
            {
                throw new Exception("Player is already playing");
            }
            Players.Add(player);
        }


        public enum RoundStatus
        {
            Started,
            Delayed,
            Paused,
            Finished,
            InProgress
        }
    }
}

using Golf.Domain.Abstractions;

namespace Golf.Domain.Entities
{
    public class Round : BaseEntity
    {
        public RoundStatus Status { get; set; }

        private HashSet<Player> Players { get; set; }
        private List<PlayerScore> PlayerScores { get; init; }

        public Course Course { get; init; }


        public Round(HashSet<Player> players, Course course) : base(Guid.NewGuid())
        {
            Players = players;
            Course = course;
            PlayerScores = new List<PlayerScore>();
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

            if (!PlayerScores.Any(ps => ps.PlayerId == player.Id))
            {
                PlayerScores.Add(new PlayerScore(player.Id));
            }

            PlayerScores.First(ps => ps.PlayerId == player.Id).AddStroke(hole, strokeType);

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

            if (!PlayerScores.Any(ps => ps.PlayerId == playerId.Id))
            {
                throw new Exception("Player has not played hole");
            }

            return PlayerScores.FirstOrDefault(ps => ps.PlayerId == playerId.Id)?.TotalStrokesForHole(hole) ?? 0;
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

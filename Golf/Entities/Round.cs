using Golf.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Domain.Entities
{
    public class Round : BaseEntity
    {

        // Status of the round
        // Started, Delayed, Paused, Finished, etc... 

        public RoundStatus Status { get; set; }

        private HashSet<Player> Players { get; set; }

        private IList<Score> Scores { get; set; }

        public Course Course { get; init; }


        public Round(HashSet<Player> players, Course course) : base(Guid.NewGuid())
        {
            Players = players;
            Scores = new List<Score>();
            Course = course;
        }

        public void Start()
        {
            Console.WriteLine("Golf Game Started");
        }

        public void Stop()
        {
            Console.WriteLine("Golf Game Stopped");
        }

        public void AddScore(Player player, List<Stroke> strokes, int holeNumber)
        {
            var hole = Course.GetHoles().FirstOrDefault(h => h.Number == holeNumber);
            var score = new Score(hole.Id, this.Id, player.Id, strokes);
            Scores.Add(score);
        }


        public bool IsPlayerPlaying(Guid playerId)
        {
            return Players.Any(p => p.Id == playerId);
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

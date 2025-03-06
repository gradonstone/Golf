using Golf.Abstractions;

namespace Golf.Domain.Entities
{
    public class Score
    {
        public Guid HoleId { get; private set; }
        public Guid RoundId { get; private set; }
        public Guid PlayerId { get; set; }

        public IList<Stroke> Strokes { get; set; } = new List<Stroke>();
        public int TotalStrokes => Strokes.Count;
        public int Putts => Strokes.Count(s => s.Type == StrokeType.Putt);
        public int PenaltyStrokes => Strokes.Count(s => s.Type == StrokeType.Penalty);

        public Score(Guid holeId, Guid roundId, Guid playerId, IList<Stroke> strokes)
        {
            HoleId = holeId;
            RoundId = roundId;
            PlayerId = playerId;
            Strokes = strokes;
        }

        public void AddStroke(Stroke stroke)
        {
            Strokes.Add(stroke);
        }

        public void RemoveStroke(int number)
        {
            Strokes.RemoveAt(number);
        }
    }
}

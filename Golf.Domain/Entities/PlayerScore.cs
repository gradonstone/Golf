namespace Golf.Domain.Entities
{
    public class PlayerScore
    {
        public Guid PlayerId { get; set; }

        private readonly Dictionary<Hole, List<StrokeType>> Strokes = new();

        public PlayerScore(Guid playerId)
        {
            PlayerId = playerId;
        }

        public void AddStroke(Hole hole, StrokeType strokeType)
        {
            if (!Strokes.ContainsKey(hole))
            {
                Strokes[hole] = new List<StrokeType>();
            }
            Strokes[hole].Add(strokeType);
        }

        public int TotalStrokesForHole(Hole hole)
        {
            return Strokes.ContainsKey(hole) ? Strokes[hole].Count : 0;
        }
    }
}

namespace Golf.Domain.Entities
{
    public class Stroke
    {
        public Guid PlayerId { get; init; }
        public StrokeType Type { get; init; }

        public Stroke(Guid playerId, StrokeType type)
        {
            PlayerId = playerId;
            Type = type;
        }
    }

    public enum StrokeType
    {
        TeeShot,
        Approach,
        Putt,
        Penalty,
        Drop,
        Unknown
    }
}

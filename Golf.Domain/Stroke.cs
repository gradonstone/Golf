namespace Golf.Domain
{
    public class Stroke
    {
        public StrokeType Type { get; set; }
    }

    public enum StrokeType
    {
        Drive,
        Approach,
        Putt,
        Penalty,
        Drop,
        Unknown
    }

}

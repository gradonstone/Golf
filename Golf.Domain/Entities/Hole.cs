using Golf.Domain.Abstractions;

namespace Golf.Domain.Entities
{
    public class Hole : BaseEntity
    {
        public Guid CourseId { get; private set; }
        public int Number { get; private set; }
        public int Par { get; private set; }
        public string? Decsription { get; private set; }

        private Hole(Guid id, int number, int par, string? description) : base(id)
        {
            Number = number;
            Par = par;
            Decsription = description;
        }
        public static Hole Create(Guid courseId, int number, int par, string? description)
        {
            return new Hole(Guid.NewGuid(), number, par, description);
        }

        public void UpdateDescription(string description)
        {
            Decsription = description;
        }

    }
}

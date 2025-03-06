using Golf.Domain.Abstractions;

namespace Golf.Domain.Entities
{
    public class Hole : BaseEntity
    {
        public Guid CourseId { get; private set; }
        public int Number { get; private set; }
        public int Par { get; private set; }

        private Hole(Guid id) : base(id)
        {
        }
        public static Hole Create()
        {
            return new Hole(Guid.NewGuid());
        }

    }
}

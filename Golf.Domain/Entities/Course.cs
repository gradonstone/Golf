using Golf.Domain.Abstractions;

namespace Golf.Domain.Entities
{
    public class Course : BaseEntity, IAggregateRoot 
    {
        // Consider refactoring to use a HashSet, readonly?
        private List<Hole> Holes { get; set; } = new();

        private Course(Guid id) : base(id) { }

        public static Course Create()
        {
            return new Course(Guid.NewGuid());
        }

        public void AddHole(Hole hole)
        {
            if (Holes.Any(h => h.Number == hole.Number))
            {
                // TODO: Consider throwing a custom exception
                return;
            }
            Holes.Add(hole);
        }

        public bool RemoveHole(Hole hole)
        {
            return Holes.Remove(hole);
        }

        public IList<Hole> GetHoles()
        {
            return Holes.AsReadOnly();
        }
    }
}

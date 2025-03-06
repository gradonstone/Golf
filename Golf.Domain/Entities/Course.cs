using Golf.Domain.Abstractions;

namespace Golf.Domain.Entities
{
    public class Course : BaseEntity
    {
        // Consider refactoring to use a HashSet, readonly?
        private HashSet<Hole> Holes { get; set; } = new();

        private Course(Guid id) : base(id)
        {
        }

        public static Course Create()
        {
            return new Course(Guid.NewGuid());
        }

        public bool AddHole(Hole hole)
        {
            if (Holes.Any(h => h.Number == hole.Number))
            {
                return false;
            }
            return Holes.Add(hole);
        }

        public bool RemoveHole(Hole hole)
        {
            return Holes.Remove(hole);
        }

        public IList<Hole> GetHoles()
        {
            return Holes.ToList();
        }
    }
}

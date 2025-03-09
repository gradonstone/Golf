using Golf.Domain.Entities;

namespace Golf.Domain.Repositories
{
    public interface ICourseRepository
    {
        public Course? GetCourse(Guid courseId);
        public Hole? GetHole(Guid holdId);
    }
}

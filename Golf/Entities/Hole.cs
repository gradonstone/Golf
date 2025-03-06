using Golf.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

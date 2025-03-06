using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Abstractions
{
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}

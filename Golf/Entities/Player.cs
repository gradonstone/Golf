using Golf.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Domain.Entities
{
    public class Player : BaseEntity
    {
        public Name Name { get; private set; }

        private Player(Guid id, Name name) : base(id)
        {
            Name = name;
        }

        public static Player Create(Name name)
        {
            return new Player(Guid.NewGuid(), name);
        }
    }
}

public sealed record Name
{
    public Name(string? value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }

    public string Value { get; }
}
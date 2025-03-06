using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

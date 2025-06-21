using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.Domain.Entities
{
    public class ObservationData
    {
        public DateTime SamplingTime { get; set; }
        public List<PropertyItem> Properties { get; set; } = new();
    }
}

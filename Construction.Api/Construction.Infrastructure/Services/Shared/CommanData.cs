using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Construction.Domain.Entities;

namespace Construction.Infrastructure.Services.Shared
{
    internal class CommanData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ObservationData> Datas { get; set; }
    }
}

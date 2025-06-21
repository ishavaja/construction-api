using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Construction.Domain.Entities;

namespace Construction.Application.Interfaces
{
    public interface IObservationService
    {
        Task<List<ObservationData>> GetAllAsync();
        Task<ObservationData?> GetByTimeAsync(DateTime samplingTime);
        Task UpdateAsync(ObservationData data);
    }
}

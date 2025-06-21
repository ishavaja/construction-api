using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Construction.Application.Interfaces;
using Construction.Domain.Entities;
using Construction.Infrastructure.Services.Shared;

namespace Construction.Infrastructure.Services
{
    public class ObservationService : IObservationService
    {

        private static readonly string FilePath = Path.Combine(
           Directory.GetCurrentDirectory(), 
           "..",
           "Construction.Infrastructure",
           "Data",
           "ConstructionData.json"
        );
        public async Task<List<ObservationData>> GetAllAsync()
        {

            if (!File.Exists(FilePath))
            {
                Console.WriteLine(FilePath);
                return new();
            }
            else
            {
                var json = await File.ReadAllTextAsync(FilePath);
                var root = JsonSerializer.Deserialize<CommanData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return root?.Datas ?? new();
            }
          
            
        }

        public async Task<ObservationData?> GetByTimeAsync(DateTime samplingTime)
        {
            var all = await GetAllAsync();
            return all.FirstOrDefault(d => d.SamplingTime.ToString("s") == samplingTime.ToString("s"));
        }

        public async Task UpdateAsync(ObservationData updatedData)
        {
            var all = await GetAllAsync();
            var index = all.FindIndex(d => d.SamplingTime == updatedData.SamplingTime);

            if (index >= 0)
            {
                all[index] = updatedData;
            }

            var json = JsonSerializer.Serialize(new CommanData
            {
                Id = 1,
                Name = "New Observation",
                Datas = all
            }, new JsonSerializerOptions { WriteIndented = true });

            await File.WriteAllTextAsync(FilePath, json);
        }

    }
}

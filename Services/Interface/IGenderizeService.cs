using Genderize.Models;

namespace Genderize.Services.Interface
{
    public interface IGenderizeService
    {
        Task<GenderizeResponse?> GetGenderPredictionAsync(string name);
    }
}

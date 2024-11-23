using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class CityService(ICityRepository repository) : ICityService
{
    public async Task<List<CityOutput>> GetAllAsync()
    {
        var cities = await repository.GetAllAsync();
        return cities.Select(city => city.ToOutputModel()).ToList();
    }

    public async Task<CityOutput?> GetByIdAsync(int id)
    {
        var city = await repository.GetByIdAsync(id);
        return city?.ToOutputModel();
    }

    public async Task<CityOutput> AddAsync(CityInput cityInput)
    {
        ArgumentNullException.ThrowIfNull(cityInput, nameof(cityInput));

        var cityEntity = cityInput.ToEntity();
        var createdCity = await repository.AddAsync(cityEntity);
        return createdCity.ToOutputModel();
    }

    public async Task<CityOutput?> UpdateAsync(int id, CityInput cityInput)
    {
        ArgumentNullException.ThrowIfNull(cityInput, nameof(cityInput));

        var existingCity = await repository.GetByIdAsync(id);
        if (existingCity == null) return null;

        var updatedEntity = cityInput.ToEntity();
        updatedEntity.CityId = id;

        var updatedCity = await repository.UpdateAsync(id, updatedEntity);
        return updatedCity?.ToOutputModel();
    }

    public async Task<CityOutput?> DeleteAsync(int id)
    {
        var city = await repository.DeleteAsync(id);
        return city?.ToOutputModel();
    }

    public async Task<CityOutput?> GetCityWithDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}


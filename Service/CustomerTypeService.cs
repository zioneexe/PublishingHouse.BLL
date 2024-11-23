using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class CustomerTypeService(ICustomerTypeRepository repository) : ICustomerTypeService
{
    public async Task<List<CustomerTypeOutput>> GetAllAsync()
    {
        var customerTypes = await repository.GetAllAsync();
        return customerTypes.Select(customerType => customerType.ToOutputModel()).ToList();
    }

    public async Task<CustomerTypeOutput?> GetByIdAsync(int id)
    {
        var customerType = await repository.GetByIdAsync(id);
        return customerType?.ToOutputModel();
    }

    public async Task<CustomerTypeOutput> AddAsync(CustomerTypeInput customerTypeInput)
    {
        ArgumentNullException.ThrowIfNull(customerTypeInput, nameof(customerTypeInput));

        var customerTypeEntity = customerTypeInput.ToEntity();
        var createdCustomerType = await repository.AddAsync(customerTypeEntity);
        return createdCustomerType.ToOutputModel();
    }

    public async Task<CustomerTypeOutput?> UpdateAsync(int id, CustomerTypeInput customerTypeInput)
    {
        ArgumentNullException.ThrowIfNull(customerTypeInput, nameof(customerTypeInput));

        var existingCustomerType = await repository.GetByIdAsync(id);
        if (existingCustomerType == null) return null;

        var updatedEntity = customerTypeInput.ToEntity();
        updatedEntity.CustomerTypeId = id;

        var updatedCustomerType = await repository.UpdateAsync(id,updatedEntity);
        return updatedCustomerType?.ToOutputModel();
    }

    public async Task<CustomerTypeOutput?> DeleteAsync(int id)
    {
        var customerType = await repository.DeleteAsync(id);
        return customerType?.ToOutputModel();
    }

    public async Task<CustomerTypeOutput?> GetCustomerTypeWithCustomersAsync(int id)
    {
        throw new NotImplementedException();
    }
}


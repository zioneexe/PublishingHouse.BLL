using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    public async Task<List<CustomerOutput>> GetAllAsync()
    {
        var customers = await repository.GetAllAsync();
        return customers.Select(customer => customer.ToOutputModel()).ToList();
    }

    public async Task<CustomerOutput?> GetByIdAsync(int id)
    {
        var customer = await repository.GetByIdAsync(id);
        return customer?.ToOutputModel();
    }

    public async Task<CustomerOutput> AddAsync(CustomerInput customerInput)
    {
        ArgumentNullException.ThrowIfNull(customerInput, nameof(customerInput));

        var customerEntity = customerInput.ToEntity();
        var createdCustomer = await repository.AddAsync(customerEntity);
        return createdCustomer.ToOutputModel();
    }

    public async Task<CustomerOutput?> UpdateAsync(int id, CustomerInput customerInput)
    {
        ArgumentNullException.ThrowIfNull(customerInput, nameof(customerInput));

        var existingCustomer = await repository.GetByIdAsync(id);
        if (existingCustomer == null) return null;

        var updatedEntity = customerInput.ToEntity();
        updatedEntity.CustomerId = id;

        var updatedCustomer = await repository.UpdateAsync(id, updatedEntity);
        return updatedCustomer?.ToOutputModel();
    }

    public async Task<CustomerOutput?> DeleteAsync(int id)
    {
        var customer = await repository.DeleteAsync(id);
        return customer?.ToOutputModel();
    }

    public async Task<CustomerOutput?> GetCustomerWithOrdersAsync(int id)
    {
        throw new NotImplementedException();
    }
}


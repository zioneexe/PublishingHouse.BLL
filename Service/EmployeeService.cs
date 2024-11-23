using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Mapper;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.Shared.Model.Output;

namespace PublishingHouse.BLL.Service;

public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
{
    public async Task<List<EmployeeOutput>> GetAllAsync()
    {
        var employees = await repository.GetAllAsync();
        return employees.Select(employee => employee.ToOutputModel()).ToList();
    }

    public async Task<EmployeeOutput?> GetByIdAsync(int id)
    {
        var employee = await repository.GetByIdAsync(id);
        return employee?.ToOutputModel();
    }

    public async Task<EmployeeOutput> AddAsync(EmployeeInput employeeInput)
    {
        ArgumentNullException.ThrowIfNull(employeeInput, nameof(employeeInput));

        var employeeEntity = employeeInput.ToEntity();
        var createdEmployee = await repository.AddAsync(employeeEntity);
        return createdEmployee.ToOutputModel();
    }

    public async Task<EmployeeOutput?> UpdateAsync(int id, EmployeeInput employeeInput)
    {
        ArgumentNullException.ThrowIfNull(employeeInput, nameof(employeeInput));

        var existingEmployee = await repository.GetByIdAsync(id);
        if (existingEmployee == null) return null;

        var updatedEntity = employeeInput.ToEntity();
        updatedEntity.EmployeeId = id;

        var updatedEmployee = await repository.UpdateAsync(id, updatedEntity);
        return updatedEmployee?.ToOutputModel();
    }

    public async Task<EmployeeOutput?> DeleteAsync(int id)
    {
        var employee = await repository.DeleteAsync(id);
        return employee?.ToOutputModel();
    }

    public async Task<EmployeeOutput?> GetEmployeeWithDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }
}


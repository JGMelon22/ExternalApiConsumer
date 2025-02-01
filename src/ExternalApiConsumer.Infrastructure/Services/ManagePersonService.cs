using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;

namespace ExternalApiConsumer.Infrastructure.Services;

public class ManagePersonService : IManagePersonService
{
    private readonly IManagePersonService _managePersonService;

    public ManagePersonService(IManagePersonService managePersonService)
    {
        _managePersonService = managePersonService;
    }

    public async Task<bool> CreatePersonAsync(Person person)
    {
        ServiceResponse<Person> serviceResponse = new();

        try
        {
            bool isSuccess = await _managePersonService.CreatePersonAsync(person);
            return isSuccess;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;

            return false;
        }
    }

    public async Task<bool> DeletePeopleAsync()
    {
        ServiceResponse<Person> serviceResponse = new();

        try
        {
            bool isSuccess = await _managePersonService.DeletePeopleAsync();
            return isSuccess;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;

            return false;
        }
    }

    public async Task<ServiceResponse<IEnumerable<Person>>> GetPeopleAsync()
    {
        ServiceResponse<IEnumerable<Person>> serviceResponse = new();

        try
        {
            ServiceResponse<IEnumerable<Person>> response = await _managePersonService.GetPeopleAsync();
            serviceResponse.Data = response.Data;
            serviceResponse.Success = response.Success;
            serviceResponse.Message = response.Message;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<Person>> GetPersonAsync(int id)
    {
        ServiceResponse<Person> serviceResponse = new();

        try
        {
            ServiceResponse<Person> response = await _managePersonService.GetPersonAsync(id);
            serviceResponse.Data = response.Data;
            serviceResponse.Success = response.Success;
            serviceResponse.Message = response.Message;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<bool> UpdatePersonAsync(int id, Person person)
    {
        ServiceResponse<Person> serviceResponse = new();

        try
        {
            bool isSuccess = await _managePersonService.UpdatePersonAsync(id, person);
            return isSuccess;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;

            return false;
        }
    }
}

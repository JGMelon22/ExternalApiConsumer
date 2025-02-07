using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;

namespace ExternalApiConsumer.Infrastructure.Services;

public class ManagePersonService : IManagePersonService
{
    private readonly IExternalPersonApi _externalPersonApi;

    public ManagePersonService(IExternalPersonApi externalPersonApi)
    {
        _externalPersonApi = externalPersonApi;
    }

    public async Task<ServiceResponse<bool>> CreatePersonAsync(Person person)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            await _externalPersonApi.CreatePersonAsync(person);
            serviceResponse.Data = true;
            serviceResponse.Success = true;
            serviceResponse.Message = "Person created successfully.";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> DeletePeopleAsync()
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            await _externalPersonApi.DeletePeopleAsync();
            serviceResponse.Data = true;
            serviceResponse.Success = true;
            serviceResponse.Message = "People deleted successfully.";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<IEnumerable<Person>>> GetPeopleAsync()
    {
        var serviceResponse = new ServiceResponse<IEnumerable<Person>>();

        try
        {
            var externalServiceResponse = await _externalPersonApi.GetPeopleAsync();

            if (externalServiceResponse.Success)
            {
                serviceResponse.Data = externalServiceResponse.Data;
                serviceResponse.Success = true;
            }

            else
            {
                serviceResponse.Data = externalServiceResponse.Data;
                serviceResponse.Message = externalServiceResponse.Message;
            }

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
            var externalServiceResponse = await _externalPersonApi.GetPersonAsync(id);

            if (externalServiceResponse.Success)
            {
                serviceResponse.Data = externalServiceResponse.Data;
                serviceResponse.Success = true;
            }

            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = externalServiceResponse.Message;
            }

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> UpdatePersonAsync(int id, Person person)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            await _externalPersonApi.UpdatePersonAsync(id, person);
            serviceResponse.Data = true;
            serviceResponse.Success = true;
            serviceResponse.Message = "Person updated successfully.";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}

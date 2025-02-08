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
        ServiceResponse<bool> serviceResponse = new();

        try
        {
            if (person == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Person cannot be null.";
                return serviceResponse;
            }

            await _externalPersonApi.CreatePersonAsync(person);
            serviceResponse.Success = true;
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
        ServiceResponse<bool> serviceResponse = new();

        try
        {
            await _externalPersonApi.DeletePeopleAsync();
            serviceResponse.Success = true;
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
        ServiceResponse<IEnumerable<Person>> serviceResponse = new();

        try
        {
            var externalServiceResponse = await _externalPersonApi.GetPeopleAsync();

            if (externalServiceResponse == null || !externalServiceResponse.Any())
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No people found.";
                serviceResponse.Data = [];
            }

            serviceResponse.Data = externalServiceResponse;
            serviceResponse.Success = true;
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

            if (externalServiceResponse == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Person with Id {id} not found.";
                return serviceResponse;
            }

            serviceResponse.Data = externalServiceResponse;
            serviceResponse.Success = true;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}
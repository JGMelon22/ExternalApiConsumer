using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;

namespace ExternalApiConsumer.Infrastructure.Interfaces;

public interface IManagePersonService
{
    Task<ServiceResponse<bool>> CreatePersonAsync(Person person);
    Task<ServiceResponse<bool>> DeletePeopleAsync();
    Task<ServiceResponse<IEnumerable<Person>>> GetPeopleAsync();
    Task<ServiceResponse<Person>> GetPersonAsync(int id);
}

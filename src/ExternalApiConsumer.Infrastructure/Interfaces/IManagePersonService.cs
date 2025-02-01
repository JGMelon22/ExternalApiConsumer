using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using Refit;

namespace ExternalApiConsumer.Infrastructure.Interfaces;

public interface IManagePersonService
{
    [Get("/api/person")]
    Task<ServiceResponse<IEnumerable<Person>>> GetPeopleAsync();

    [Get("/api/person/{id}")]
    Task<ServiceResponse<Person>> GetPersonAsync(int id);

    [Post("/api/person")]
    Task<bool> CreatePersonAsync(Person person);

    [Patch("/api/person/{id}")]
    Task<bool> UpdatePersonAsync(int id, Person person);

    [Delete("/api/person")]
    Task<bool> DeletePeopleAsync();
}

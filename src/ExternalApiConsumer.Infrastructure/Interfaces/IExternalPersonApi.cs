using ExternalApiConsumer.Core.Domains.People.Entities;
using Refit;

namespace ExternalApiConsumer.Infrastructure.Interfaces;

public interface IExternalPersonApi
{
    [Get("/api/person")]
    Task<IEnumerable<Person>> GetPeopleAsync();

    [Get("/api/person/{id}")]
    Task<Person> GetPersonAsync(int id);

    [Post("/api/person")]
    Task CreatePersonAsync(Person person);

    [Delete("/api/person")]
    Task DeletePeopleAsync();
}
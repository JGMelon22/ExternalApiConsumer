using ExternalApiConsumer.Core.Domains.People.Entities;
using Refit;

namespace ExternalApiConsumer.Infrastructure.Interfaces;

public interface IExternalPersonApi
{
    [Get("/api/person")]
    Task<ApiResponse<IEnumerable<Person>>> GetPeopleAsync();

    [Get("/api/person/{id}")]
    Task<ApiResponse<Person>> GetPersonAsync(int id);

    [Post("/api/person")]
    Task CreatePersonAsync(Person person);

    [Post("/api/person/seed-data")]
    Task SeedDataAsync();

    [Delete("/api/person")]
    Task DeletePeopleAsync();
}

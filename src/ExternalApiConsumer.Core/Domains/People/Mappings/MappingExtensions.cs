using ExternalApiConsumer.Core.Domains.Peole.Dtos.Requests;
using ExternalApiConsumer.Core.Domains.Peole.Dtos.Responses;
using ExternalApiConsumer.Core.Domains.People.Entities;

namespace ExternalApiConsumer.Core.Domains.Peole.Mappings;

public static class MappingExtensions
{
    public static Person ToDomain(this PersonRequest request)
        => new Person(request.FirstName, request.LastName, request.Address);

    public static PersonResponse ToResponse(this Person person)
        => new PersonResponse
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Address = person.Address
        };

    public static IEnumerable<PersonResponse> ToResponse(this IEnumerable<Person> people)
    {
        return people.Select(person =>
            new PersonResponse
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address
            });
    }
}

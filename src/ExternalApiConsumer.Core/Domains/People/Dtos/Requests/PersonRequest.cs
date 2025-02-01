namespace ExternalApiConsumer.Core.Domains.Peole.Dtos.Requests;

public record PersonRequest(
    string FirstName,
    string LastName,
    string Address
);

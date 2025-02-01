namespace ExternalApiConsumer.Core.Domains.Peole.Dtos.Responses;

public record PersonResponse
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
}

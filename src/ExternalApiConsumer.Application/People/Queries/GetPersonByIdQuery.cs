using ExternalApiConsumer.Core.Domains.Peole.Dtos.Responses;
using ExternalApiConsumer.Core.Shared;
using MediatR;

namespace ExternalApiConsumer.Application.People.Queries;

public sealed record GetPersonByIdQuery(int Id) : IRequest<ServiceResponse<PersonResponse>>;

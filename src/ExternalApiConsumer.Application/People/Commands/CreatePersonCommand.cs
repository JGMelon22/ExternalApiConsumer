using ExternalApiConsumer.Core.Domains.Peole.Dtos.Requests;
using ExternalApiConsumer.Core.Shared;
using MediatR;

namespace ExternalApiConsumer.Application.People.Commands;
public sealed record CreatePersonCommand(PersonRequest PersonRequest) : IRequest<ServiceResponse<bool>>;

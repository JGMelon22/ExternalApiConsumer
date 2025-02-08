using ExternalApiConsumer.Core.Shared;
using MediatR;

namespace ExternalApiConsumer.Application.People.Commands;

public sealed record DeletePersonCommand(int Id) : IRequest<ServiceResponse<bool>>;

using ExternalApiConsumer.Core.Shared;
using MediatR;

namespace ExternalApiConsumer.Application.People.Commands;

public sealed record DeletePersonCommand : IRequest<ServiceResponse<bool>>;
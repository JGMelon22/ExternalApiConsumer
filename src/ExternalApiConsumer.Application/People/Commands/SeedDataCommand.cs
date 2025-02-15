using ExternalApiConsumer.Core.Shared;
using MediatR;

namespace ExternalApiConsumer.Application.People.Commands;

public record SeedDataCommand() : IRequest<ServiceResponse<bool>>;

using ExternalApiConsumer.Application.People.Commands;
using ExternalApiConsumer.Application.People.Commands.Handlers;
using ExternalApiConsumer.Core.Domains.Peole.Dtos.Requests;
using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using Moq;
using Shouldly;

namespace ExternalApiConsumer.Tests.Application.Commands;

public class CreatePersonCommandHandlerTests
{
    [Fact]
    public async Task Should_Return_SuccessTrue_When_PersonRequestIsValid()
    {
        // Arrange
        Mock<IManagePersonService> managePersonService = new();
        PersonRequest newPerson = new("Joao Gabriel", "Melao", "Somewhere Abc 123");
        CreatePersonCommand command = new(newPerson);
        ServiceResponse<bool> serviceResponse = new()
        {
            Data = true,
            Success = true,
            Message = string.Empty
        };

        managePersonService
            .Setup(x => x.CreatePersonAsync(It.IsAny<Person>()))
            .ReturnsAsync(serviceResponse);

        CreatePersonCommandHandler handler = new(managePersonService.Object);

        // Act
        ServiceResponse<bool> result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Data.ShouldBeTrue();
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        managePersonService.Verify(x => x.CreatePersonAsync(It.IsAny<Person>()), Times.Once);
    }
}

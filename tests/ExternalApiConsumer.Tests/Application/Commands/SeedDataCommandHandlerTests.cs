using ExternalApiConsumer.Application.People.Commands;
using ExternalApiConsumer.Application.People.Commands.Handlers;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using Moq;
using Shouldly;

namespace ExternalApiConsumer.Tests.Application.Commands;

public class SeedDataCommandHandlerTests
{
    [Fact]
    public async Task Should_Return_SuccessTrue_When_SeedIsCorrectlyExecuted()
    {
        // Arrange
        Mock<IManagePersonService> managePersonService = new();
        SeedDataCommand command = new();
        ServiceResponse<bool> serviceResponse = new() { Data = true, Success = true, Message = string.Empty };

        managePersonService
            .Setup(x => x.SeedDataAsync())
            .ReturnsAsync(serviceResponse);

        SeedDataCommandHandler handler = new(managePersonService.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Data.ShouldBeTrue();
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        managePersonService.Verify(x => x.SeedDataAsync(), Times.Once);
    }
}

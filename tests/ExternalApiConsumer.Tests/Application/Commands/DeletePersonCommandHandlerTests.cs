using ExternalApiConsumer.Application.People.Commands;
using ExternalApiConsumer.Application.People.Commands.Handlers;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using Moq;
using Shouldly;

namespace ExternalApiConsumer.Tests.Application.Commands;

public class DeletePersonCommandHandlerTests
{
    [Fact]
    public async Task Should_Return_SuccessTrue_When_PersonIsDeletedSuccessfully()
    {
        // Arrange
        Mock<IManagePersonService> managePersonService = new();
        DeletePersonCommand command = new();
        ServiceResponse<bool> serviceResponse = new() { Data = true, Success = true, Message = string.Empty };

        managePersonService
            .Setup(x => x.DeletePeopleAsync())
                .ReturnsAsync(serviceResponse);

        DeletePersonCommandHandler handler = new(managePersonService.Object);

        // Act
        ServiceResponse<bool> result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Data.ShouldBeTrue();
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        managePersonService.Verify(x => x.DeletePeopleAsync(), Times.Once);
    }
}

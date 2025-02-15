using ExternalApiConsumer.Application.People.Commands;
using ExternalApiConsumer.Application.People.Queries;
using ExternalApiConsumer.Core.Domains.Peole.Dtos.Requests;
using ExternalApiConsumer.Core.Domains.Peole.Dtos.Responses;
using ExternalApiConsumer.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace ExternalApiConsumer.API.Controllers;

public class PeopleControllerTests
{
    [Fact]
    public async Task Should_Return_StatusCode200Ok_When_ThereArePeopleAtCollection()
    {
        // Arrange
        Mock<IMediator> mediator = new();
        PeopleController controller = new(mediator.Object);
        IEnumerable<PersonResponse> people =
        [
            new() { Id = 1, FirstName = "Sophia", LastName = "Lopez", Address = "Lake Street 505" },
            new() { Id = 2, FirstName = "Daniel", LastName = "Gonzalez", Address = "Forest Lane 606" },
            new() { Id = 3, FirstName = "Olivia", LastName = "Rodriguez", Address = "River Road 707" }
        ];

        ServiceResponse<IEnumerable<PersonResponse>> serviceResponse = new()
        {
            Data = people,
            Success = true,
            Message = string.Empty
        };

        mediator
            .Setup(x => x.Send(It.IsAny<GetPeopleQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(serviceResponse);

        // Act
        var result = await controller.GetPeopleAsync();

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_Return_StatusCode200Ok_When_PersonIdIsValid()
    {
        // Arrange
        Mock<IMediator> mediator = new();
        PeopleController controller = new(mediator.Object);
        PersonResponse person = new()
        {
            Id = 1,
            FirstName = "Sophia",
            LastName = "Lopez",
            Address = "Lake Street 505"
        };

        ServiceResponse<PersonResponse> serviceResponse = new()
        {
            Data = person,
            Success = true,
            Message = string.Empty
        };

        mediator
            .Setup(x => x.Send(It.IsAny<GetPersonByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(serviceResponse);

        // Act
        var result = await controller.GetPersonAsync(1);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_Return_StatusCode204_When_PersonRequestIsValid()
    {
        // Arrange
        Mock<IMediator> mediator = new();
        PeopleController controller = new(mediator.Object);
        PersonRequest person = new("Sophia", "Lopez", "Lake Street 505");

        ServiceResponse<bool> serviceResponse = new()
        {
            Data = true,
            Success = true,
            Message = string.Empty
        };

        mediator
            .Setup(x => x.Send(It.IsAny<CreatePersonCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(serviceResponse);

        // Act
        var result = await controller.CreatePersonAsync(person);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Should_Return_StatusCode204_When_SeedDataExecutesFlawlessly()
    {
        // Arrange
        Mock<IMediator> mediator = new();
        PeopleController controller = new(mediator.Object);

        ServiceResponse<bool> serviceResponse = new()
        {
            Data = true,
            Success = true,
            Message = string.Empty
        };

        mediator
            .Setup(x => x.Send(It.IsAny<SeedDataCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(serviceResponse);

        // Act
        var result = await controller.SeedDataAsync();

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Should_Return_StatusCode204_When_PeopleAreSuccessfullyDeleted()
    {
        // Arrange
        Mock<IMediator> mediator = new();
        PeopleController controller = new(mediator.Object);

        ServiceResponse<bool> serviceResponse = new()
        {
            Data = true,
            Success = true,
            Message = string.Empty
        };

        mediator
            .Setup(x => x.Send(It.IsAny<DeletePersonCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(serviceResponse);

        // Act
        var result = await controller.DeletePeopleAsync();

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<NoContentResult>();
    }
}

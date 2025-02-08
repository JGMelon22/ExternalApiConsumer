using ExternalApiConsumer.Application.People.Queries;
using ExternalApiConsumer.Application.People.Queries.Handlers;
using ExternalApiConsumer.Core.Domains.Peole.Dtos.Responses;
using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using Moq;
using Shouldly;

namespace ExternalApiConsumer.Tests.Application.Queries;

public class GetPeopleQueryHandlerTests
{
    // Arrange
    [Fact]
    public async Task Should_Return_CollectionOfPerson_When_ThereArePeopleToBeReturned()
    {
        // Arrange
        Mock<IManagePersonService> managePersonService = new();
        IEnumerable<Person> people =
        [
            new(1, "Joao Gabriel", "Melao", "Somewhere Abc 123"),
            new(2, "Jane", "Doe", "Another Place 456"),
            new(3, "John", "Smith", "Some Street 789")
        ];

        GetPeopleQuery query = new();
        ServiceResponse<IEnumerable<Person>> serviceResponse = new() { Data = people, Success = true, Message = string.Empty };

        managePersonService
            .Setup(x => x.GetPeopleAsync())
            .ReturnsAsync(serviceResponse);

        GetPeopleQueryHandler handler = new(managePersonService.Object);

        // Act
        ServiceResponse<IEnumerable<PersonResponse>> result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Data!.ShouldNotBeNull();
        result.Data!.ShouldNotBeEmpty();
        result.Data.Count().ShouldBe(3);
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        managePersonService.Verify(x => x.GetPeopleAsync(), Times.Once);
    }
}

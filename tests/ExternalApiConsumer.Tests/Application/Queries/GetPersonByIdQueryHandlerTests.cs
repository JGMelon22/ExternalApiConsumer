using ExternalApiConsumer.Application.People.Queries;
using ExternalApiConsumer.Application.People.Queries.Handlers;
using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using Moq;
using Shouldly;

namespace ExternalApiConsumer.Tests.Application.Queries;

public class GetPersonByIdQueryHandlerTests
{
    // Arrange
    [Fact]
    public async Task Should_Return_Person_When_PersonIdIsValid()
    {
        // Arrange
        Mock<IManagePersonService> managePersonService = new();
        Person person = new()
        {
            Id = 1,
            FirstName = "Joao Gabriel",
            LastName = "Melao",
            Address = "Somewhere Abc 123"
        };
        GetPersonByIdQuery query = new(1);
        ServiceResponse<Person> serviceResponse = new() { Data = person, Success = true, Message = string.Empty };

        managePersonService
            .Setup(x => x.GetPersonAsync(1))
            .ReturnsAsync(serviceResponse);

        GetPersonByIdQueryHandler handler = new(managePersonService.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Data.ShouldNotBeNull();
        result.Data.Id.ShouldBe(person.Id);
        result.Data.FirstName.ShouldBe(person.FirstName);
        result.Data.LastName.ShouldBe(person.LastName);
        result.Data.Address.ShouldBe(person.Address);
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        managePersonService.Verify(x => x.GetPersonAsync(1), Times.Once);
    }
}
using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using ExternalApiConsumer.Infrastructure.Services;
using Moq;
using Shouldly;

namespace ExternalApiConsumer.Tests.Infrastructure;

public class ManagePersonServiceTests
{
    [Fact]
    public async Task Should_Return_SuccessTrue_When_PersonIsValid()
    {
        // Arrange
        Mock<IExternalPersonApi> externalPersonApi = new();
        Person person = new()
        {
            Id = 1,
            FirstName = "Leon",
            LastName = "Kennedy",
            Address = "Raccoon City"
        };
        ServiceResponse<bool> serviceResponse = new()
        {
            Data = true,
            Success = true,
            Message = string.Empty
        };
        externalPersonApi
            .Setup(x => x.CreatePersonAsync(person));

        ManagePersonService managePersonService = new(externalPersonApi.Object);

        // Act
        ServiceResponse<bool> result = await managePersonService.CreatePersonAsync(person);

        // Assert
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        externalPersonApi.Verify(api => api.CreatePersonAsync(person), Times.Once);
    }

    [Fact]
    public async Task DeletePeopleAsync_ShouldReturnSuccess_WhenDeletionSucceeds()
    {
        // Arrange
        Mock<IExternalPersonApi> externalPersonApi = new();
        ServiceResponse<bool> serviceResponse = new()
        {
            Data = true,
            Success = true,
            Message = string.Empty
        };
        externalPersonApi
            .Setup(x => x.DeletePeopleAsync());

        ManagePersonService managePersonService = new(externalPersonApi.Object);

        // Act
        ServiceResponse<bool> result = await managePersonService.DeletePeopleAsync();

        // Assert
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        externalPersonApi.Verify(api => api.DeletePeopleAsync(), Times.Once);
    }

    [Fact]
    public async Task Should_Return_CollectionOfPerson_When_ThereArePeopleToBeReturned()
    {
        // Arrange
        Mock<IExternalPersonApi> externalPersonApi = new();
        IEnumerable<Person> people =
        [
            new(1, "Joao Gabriel", "Melao", "Somewhere Abc 123"),
            new(2, "Jane", "Doe", "Another Place 456"),
            new(3, "John", "Smith", "Some Street 789")
        ];


        externalPersonApi
            .Setup(x => x.GetPeopleAsync())
            .ReturnsAsync(people);

        ManagePersonService managePersonService = new(externalPersonApi.Object);

        // Act
        ServiceResponse<IEnumerable<Person>> result = await managePersonService.GetPeopleAsync();

        // Assert
        result.Data!.ShouldNotBeNull();
        result.Data!.ShouldNotBeEmpty();
        result.Data.Count().ShouldBe(3);
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        externalPersonApi.Verify(api => api.GetPeopleAsync(), Times.Once);
    }

    [Fact]
    public async Task Should_Return_Person_When_PersonIdIsValid()
    {
        // Arrange
        Mock<IExternalPersonApi> externalPersonApi = new();
        Person person = new(1, "Jill", "Valentine", "Raccoon City");

        externalPersonApi
            .Setup(x => x.GetPersonAsync(1))
            .ReturnsAsync(person);

        ManagePersonService managePersonService = new(externalPersonApi.Object);

        // Act
        ServiceResponse<Person> result = await managePersonService.GetPersonAsync(1);

        // Assert
        result.Data.ShouldNotBeNull();
        result.Data.Id.ShouldBe(person.Id);
        result.Data.FirstName.ShouldBe(person.FirstName);
        result.Data.LastName.ShouldBe(person.LastName);
        result.Data.Address.ShouldBe(person.Address);
        result.Success.ShouldBeTrue();
        result.Message.ShouldBeEmpty();
        externalPersonApi.Verify(x => x.GetPersonAsync(1), Times.Once);
    }
}

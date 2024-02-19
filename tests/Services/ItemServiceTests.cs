using Application.Services;
using AutoFixture;
using AutoFixture.Xunit2;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace UnitTests.Services;

public class ItemServiceTests
{
    private readonly Mock<IItemRepository> _itemRepositoryMock;
    private readonly ItemService _itemService;
    private readonly Fixture _fixture;
    public ItemServiceTests()
    {
        _itemRepositoryMock = new Mock<IItemRepository>();
        _itemService = new ItemService(_itemRepositoryMock.Object);
        _fixture = new Fixture();
    }

    [Theory]
    [AutoData]
    public async Task Insert_GivenValidRequestReturnsValidResponse(InsertItemRequest request)
    {
        // Arrange
        var expectedResponse = _fixture.Create<ItemEntity>();

        _itemRepositoryMock.Setup(x => x.Insert(It.IsAny<ItemEntity>()))
                           .ReturnsAsync(expectedResponse);

        // Act
        var result = await _itemService.Insert(request);

        //Assert 
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedResponse.Id);
        result.Name.Should().Be(expectedResponse.Name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task Insert_GivenNullOrEmptyNameThrowsInvalidNameException(string name)
    {
        // Arrange
        var request = new InsertItemRequest { Name = name };

        // Act & Assert
        await _itemService.Invoking(x => x.Insert(request))
                          .Should()
                          .ThrowAsync<InvalidNameException>();
    }

    [Theory]
    [AutoData]
    public async Task GetById_GivenValidIdReturnsValidResponse(ItemEntity expectedItem)
    {
        // Arrange
        _itemRepositoryMock.Setup(x => x.Get(expectedItem.Id))
                           .ReturnsAsync(expectedItem);

        // Act
        var result = await _itemService.Get(expectedItem.Id);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedItem.Id);
        result.Name.Should().Be(expectedItem.Name);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task GetById_GivenInvalidIdThrowsItemNotFoundException(int itemId)
    {
        // Arrange
        _itemRepositoryMock.Setup(x => x.Get(itemId))
                           .ReturnsAsync((ItemEntity?)null);

        // Act & Assert
        await _itemService.Invoking(x => x.Get(itemId))
                          .Should()
                          .ThrowAsync<ItemNotFoundException>();
    }

    [Fact]
    public async Task GetAll_GivenItemsInRepositoryReturnsValidResponse()
    {
        // Arrange
        var expectedItems = _fixture.CreateMany<ItemEntity>().ToList();

        _itemRepositoryMock.Setup(x => x.Get())
                           .ReturnsAsync(expectedItems);

        // Act
        var result = await _itemService.Get();

        // Assert
        result.Should().NotBeNull();
        result.Items.Should().HaveCount(expectedItems.Count);
        result.Items.Should().BeEquivalentTo(expectedItems.Select(item => new InsertItemResponse { Id = item.Id, Name = item.Name }));
    }

    [Fact]
    public async Task GetAll_GivenNoItemsInRepositoryReturnsEmptyList()
    {
        // Arrange
        _itemRepositoryMock.Setup(x => x.Get())
                           .ReturnsAsync(new List<ItemEntity>());

        // Act
        var result = await _itemService.Get();

        // Assert
        result.Should().NotBeNull();
        result.Items.Should().BeEmpty();
    }
}
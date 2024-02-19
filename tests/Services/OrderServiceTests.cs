using Application.Interfaces;
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

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly Mock<IItemService> _itemServiceMock;
    private readonly Mock<IUserService> _userServiceMock;
    private readonly OrderService _orderService;
    private readonly Fixture _fixture;
    public OrderServiceTests()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _itemServiceMock = new Mock<IItemService>();
        _userServiceMock = new Mock<IUserService>();
        _orderService = new OrderService(_orderRepositoryMock.Object,
           _itemServiceMock.Object, _userServiceMock.Object);
        _fixture = new Fixture();
    }

    [Theory]
    [AutoData]
    public async Task Insert_GivenValidRequestReturnsValidResponse(InsertOrderRequest request)
    {
        // Arrange
        InsertItemResponse expectedItemResponse = _fixture.Create<InsertItemResponse>();
        expectedItemResponse.Id = request.ItemId;

        UserEntity expectedUserEntity = _fixture.Create<UserEntity>();
        expectedUserEntity.Id = request.UserId;

        OrderEntity expectedOrderEntity = _fixture.Build<OrderEntity>()
            .With(orderEntity => orderEntity.ItemId, expectedItemResponse.Id)
            .With(orderEntity => orderEntity.UserId, expectedUserEntity.Id)
            .Create();

        _itemServiceMock.Setup(x => x.Get(request.ItemId))
            .ReturnsAsync(expectedItemResponse);

        _userServiceMock.Setup(x => x.Get(request.UserId))
            .ReturnsAsync(expectedUserEntity);

        _orderRepositoryMock.Setup(x => x.Insert(It.IsAny<OrderEntity>()))
            .ReturnsAsync(expectedOrderEntity);

        // Act
        InsertOrderResponse result = await _orderService.Insert(request);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().NotBe(default(int));
        result.ItemId.Should().Be(expectedItemResponse.Id);
        result.UserId.Should().Be(expectedUserEntity.Id);
    }

    [Fact]
    public async Task Insert_WhenItemServiceThrowsItemNotFoundException_ReturnsErrorResponse()
    {
        // Arrange
        _itemServiceMock.Setup(x => x.Get(It.IsAny<int>()))
            .ThrowsAsync(new ItemNotFoundException());

        var request = new InsertOrderRequest
        {
            ItemId = _fixture.Create<int>(),
            UserId = _fixture.Create<int>()
        };

        // Act & Assert
        await Assert.ThrowsAsync<ItemNotFoundException>(() => _orderService.Insert(request));
    }
}
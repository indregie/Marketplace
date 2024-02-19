using Application.Services;
using AutoFixture;
using AutoFixture.Xunit2;
using Domain.Dtos.Response;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace UnitTests.Services;

public class RateServiceTests
{
    //private readonly Mock<IRateRepository> _rateRepositoryMock;
    //private readonly Mock<IExchangeRatesClient> _rateClientMock;
    //private readonly RateService _rateService;
    //private readonly Fixture _fixture;
    //public RateServiceTests()
    //{
    //    _rateRepositoryMock = new Mock<IRateRepository>();
    //    _rateClientMock = new Mock<IExchangeRatesClient>();
    //    _rateService = new RateService(_rateClientMock.Object, _rateRepositoryMock.Object);
    //    _fixture = new Fixture();
    //}

    //[Theory]
    //[AutoData]
    //public async Task GivenValidDateReturnsList(DateTime date)
    //{
    //    var validDate = new DateTime(2012, 1, 1, 12, 0, 0);
    //    //Arrange 
    //    _rateRepositoryMock.Setup(x => x.CheckExistence(validDate)).ReturnsAsync(Enumerable.Empty<RateResponse>());

    //    _rateClientMock.Setup(x => x.Get(validDate)).ReturnsAsync(new List<RateEntity>
    //            {
    //                           new RateEntity { Currency = "USD", Rate = 1.2m },
    //                           new RateEntity { Currency = "EUR", Rate = 0.9m }
    //            });
    //    //Act

    //    var result = await _rateService.Get(validDate);

    //    //Assert
    ////    Assert.NotEmpty(result);
    //}
}
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services;

public class RateService
{
    private readonly IRateRepository _rateRepository;
    public RateService(IRateRepository rateRepository)
    {
        _rateRepository = rateRepository;
    }

    public async Task<InsertRateResponse> Insert(InsertRateRequest request)
    {
        if (request.Rate < 1 || request.Rate > 5 )
        {
            throw new InvalidRateException();
        }
        //validation for movieId (GetbyId)

        RateEntity rate = new RateEntity()
        {
            MovieId = request.MovieId,
            Rate = request.Rate
        };

        RateEntity result = await _rateRepository.Insert(rate);

        InsertRateResponse response = new InsertRateResponse()
        {
            Id = result.Id,
            MovieId = result.MovieId,
            Rate = result.Rate
        };

        return response;
    }

    public async Task<decimal> CountAverage(int movieId)
    {
        decimal rate = await _rateRepository.CountAverage(movieId);
        return rate;
    }
}

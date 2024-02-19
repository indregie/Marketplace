using Domain.Dtos.Response;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IRateRepository
{
    Task<RateEntity> Insert(RateEntity rate);
    Task<decimal> CountAverage(int movieId);
}
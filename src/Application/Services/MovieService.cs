using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services;

public class MovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly RateService _rateService;
    private readonly CommentService _commentService;
    public MovieService(IMovieRepository movieRepository, RateService rateService, CommentService commentService)
    {
        _movieRepository = movieRepository;
        _rateService = rateService;
        _commentService = commentService;
    }

    public async Task<GetAllMoviesResponse> GetMovies()
    {
        IEnumerable<MovieEntity> result = await _movieRepository.GetMovies();

        GetAllMoviesResponse response = new GetAllMoviesResponse()
        {
            Movies = result.Select(m => new InsertMovieResponse { Id = m.Id, Name = m.Name })
            .ToList()
        };
        return response;
    }

    //possible to optimize oneliners as in refreshes service
    public async Task<InsertMovieResponse> Insert(InsertMovieRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new InvalidNameException();
        }

        MovieEntity movie = new MovieEntity()
        {
            Name = request.Name
        };

        MovieEntity result = await _movieRepository.Insert(movie);

        InsertMovieResponse response = new InsertMovieResponse()
        {
            Id = result.Id,
            Name = result.Name
        };

        return response;
    }

    public async Task<GetMovieByIdResponse> Get(int id)
    {
        MovieEntity? movieResult = await _movieRepository.Get(id)
           ?? throw new MovieNotFoundException();

        decimal rateResult = await _rateService.CountAverage(id);
        IEnumerable<CommentEntity> commentsResult = await _commentService.GetComments(id);

        GetMovieByIdResponse response = new GetMovieByIdResponse()
        {
            Id = movieResult.Id,
            Name = movieResult.Name,
            AverageRating = rateResult,
            Comments = commentsResult.ToList()
        };
        
        return response;
    }
}

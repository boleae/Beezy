using DataAccessRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Services
{

   

    public class BeezyCinemaService:ICinemaService
    {

        private readonly IGenericRepository<Cinema> _cinemaRepository;
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IGenericRepository<Movie> _movieRepository;
        private readonly IGenericRepository<MovieGenre> _movieGenreRepository;
        private readonly IGenericRepository<Room> _roomRepository;
        private readonly IGenericRepository<Session> _sessionRepository;

        public BeezyCinemaService(IGenericRepository<Cinema> cinemaRepository,
                                  IGenericRepository<City> cityRepository,
                                  IGenericRepository<Genre> genreRepository,
                                  IGenericRepository<Movie> movieRepository,
                                  IGenericRepository<MovieGenre> movieGenreRepository,
                                  IGenericRepository<Room> roomRepository,
                                  IGenericRepository<Session> sessionRepository)
        {

            _cinemaRepository = cinemaRepository;
            _cityRepository = cityRepository;
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
            _movieGenreRepository = movieGenreRepository;
            _roomRepository = roomRepository;
            _sessionRepository = sessionRepository;

        }

        public List<string> GetMostPopularGenres(string cityName, RoomType roomType)
        {
            var query =
                (from session in _sessionRepository.Table
                join movieGenre in _movieGenreRepository.Table on session.MovieId equals movieGenre.MovieId
                join genre in _genreRepository.Table on movieGenre.GenreId equals genre.Id
                where session.Room.Cinema.City.Name == cityName && session.Room.Size == roomType.ToString()
                select genre.Name).Distinct();


            return query.ToList();
        }

        
    }
}
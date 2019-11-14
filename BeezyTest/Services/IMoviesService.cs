using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeezyTest.Services
{
    public interface IMoviesService
    {

        List<string> GetMostPopularMovies(int numOfMovies, List<long> filteredGenres = null);

        List<string> GetLessPopularMovies(int numOfMovies, List<long> filteredGenres = null);
        

    }
}

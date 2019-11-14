using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeezyTest.Services
{

    public enum RoomType
    {
        Big,
        Small
    }

    public interface ICinemaService
    {
        List<string> GetMostPopularGenres(string cityName, RoomType type);
    }
}

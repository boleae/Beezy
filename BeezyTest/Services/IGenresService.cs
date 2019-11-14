using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeezyTest.Services
{
    public interface IGenresService
    {
        Dictionary<string, long> GetAllGenres();

    }
}

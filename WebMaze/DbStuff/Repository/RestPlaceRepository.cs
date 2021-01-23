using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Rest;

namespace WebMaze.DbStuff.Repository
{
    public class RestPlaceRepository : BaseRepository<RestPlace> {
        public RestPlaceRepository(WebMazeContext context) : base(context) {
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Rest;

namespace WebMaze.DbStuff.Repository
{
    public class RestEventRepository : BaseRepository<RestEvent> {
        public RestEventRepository(WebMazeContext context) : base(context) {
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Rest;

namespace WebMaze.DbStuff.Repository
{
    public class RestCommentRepository : BaseRepository<RestComment> {
        public RestCommentRepository(WebMazeContext context) : base(context) {
        }
    }
}

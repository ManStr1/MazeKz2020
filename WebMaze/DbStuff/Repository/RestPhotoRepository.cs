using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Rest;

namespace WebMaze.DbStuff.Repository
{
    public class RestPhotoRepository : BaseRepository<RestPhoto> {
        public RestPhotoRepository(WebMazeContext context) : base(context) {
        }

        public List<RestPhoto> GetPhotosByPlace(long id) {
            return dbSet.Where(x => x.Place.Id == id).ToList();
        }
    }
}

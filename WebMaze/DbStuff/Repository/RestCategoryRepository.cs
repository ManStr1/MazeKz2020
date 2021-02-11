using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Rest;

namespace WebMaze.DbStuff.Repository
{
    public class RestCategoryRepository : BaseRepository<RestCategory> {
        public RestCategoryRepository(WebMazeContext context) : base(context) {
        }

        public List<RestCategory> GetCategoryWithPlace() {
            return dbSet.Where(x => x.RestPlaces.Count() > 0).ToList();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Rest {
    public class RestPlace : BaseModel {
        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }
    }
}

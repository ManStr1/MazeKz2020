using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Rest {
    public class RestViewModel {
        public long Id { get; set; }
        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }
        public string RestPhotoUrl { get; set; }
    }
}

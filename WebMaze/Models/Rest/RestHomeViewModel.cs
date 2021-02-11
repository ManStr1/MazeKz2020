using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Rest {
    public class RestHomeViewModel {
        public List<string> Categories { get; set; }
        public List<RestViewModel> Places { get; set; }
    }
}

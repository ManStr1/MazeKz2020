﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Rest {
    public class RestPlaceViewModel {
        
        public long Id { get; set; }
        public string PlaceName { get; set; }
        public RestCategoryViewModel Category { get; set; }
        public string PlaceDescription { get; set; }
        public List<string> Photos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Rest {
    public class RestCategory : BaseModel {
        public string CategoryName { get; set; }
        public virtual List<RestPlace> RestPlaces { get; set; }
    }
}

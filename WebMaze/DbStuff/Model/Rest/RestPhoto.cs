using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Rest {
    public class RestPhoto : BaseModel {
        public string PhotoUrl { get; set; }
        public string PhotoName { get; set; }
        public virtual RestPlace Place { get; set; }

    }
}

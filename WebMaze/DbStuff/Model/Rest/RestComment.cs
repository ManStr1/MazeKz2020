using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Rest {
    public class RestComment : BaseModel {
        public string CommentText { get; set; }
        public virtual RestPlace Place { get; set; }

    }
}

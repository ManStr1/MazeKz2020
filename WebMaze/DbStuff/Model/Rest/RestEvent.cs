using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Rest {
    public class RestEvent : BaseModel {
        public string EventName { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public string EventDescription { get; set; }
        public virtual RestPlace Place { get; set; }
    }
}

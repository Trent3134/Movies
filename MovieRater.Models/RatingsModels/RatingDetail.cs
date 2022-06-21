using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class RatingDetail
    {
        public int Id { get; set; }       
        public int Stars { get; set; }        
        public string Review { get; set; }
        public int? MovieEntityId { get; set; }
        public MovieEntity MovieEntity { get; set; }

        public int? ShowEntityId { get; set; }

        public ShowEntity ShowEntity{get; set;}
    }

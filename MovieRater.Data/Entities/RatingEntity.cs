using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class RatingEntity
    {
        // forgign key points to a movie or show
        [ForeignKey(nameof(ShowEntity))]
        public int ShowEntityId { get; set; }
        public ShowEntity ShowEntity { get; set; }
    }

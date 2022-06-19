using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class RatingCreate
    {
        [Required]
        [Range(1,5)]
        public int Stars { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]
        public int? MovieEntityId { get; set; }
        
        [Required]
        public int? ShowEntityId { get; set; }
    }

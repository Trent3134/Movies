using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class RatingUpdate
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Review { get; set; }
        
        [Required]
        [Range(1,5)]
        public int Stars {get; set;}

    }

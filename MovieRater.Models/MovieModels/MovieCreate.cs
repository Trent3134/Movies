using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class MovieCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Review { get; set; }
        public string Cast { get; set; }
        [Required]
        public GenreType GenreType { get; set; }
        [Required]
        public ParentalAdvisory ParentalAdvisory { get; set; }

    }

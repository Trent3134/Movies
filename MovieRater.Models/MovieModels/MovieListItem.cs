using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class MovieListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public string  Cast { get; set; }
        public GenreType GenreType { get; set; }
        public ParentalAdvisory ParentalAdvisory { get; set; }
    }

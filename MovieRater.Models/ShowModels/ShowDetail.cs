using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class ShowDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
        public string Cast { get; set; }
        public GenreType GenreType { get; set; }
    }

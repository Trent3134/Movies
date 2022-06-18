using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class ShowEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public string Cast { get; set; }
        [Required]
        public GenreType GenreType { get; set; }

    }

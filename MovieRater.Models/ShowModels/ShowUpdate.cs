using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class ShowUpdate
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(250, ErrorMessage = "{0} must contain no more than (1} character.")]
        public string Title { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(250, ErrorMessage = "{0} must contain no more than (1} character.")]
        public string Review { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(250, ErrorMessage = "{0} must contain no more than (1} character.")]
        public string Cast { get; set; }
    }

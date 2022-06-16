using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class RatingEntity
    {
        public enum ParentalAdvisorRatings
        {
            G,
            PG,
            PG13,
            R

        }
        // forgign key points to a movie or show
        [Key]
        public int Id { get; set; }
        [Required]
        public int Stars { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public string ParentalAdvisor {get; set;}


    }

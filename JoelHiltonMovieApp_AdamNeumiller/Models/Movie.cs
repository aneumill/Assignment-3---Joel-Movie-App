using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JoelHiltonMovieApp_AdamNeumiller.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Category { get; set; }
        [Required, Range(1888, 2021)]
        public string Year  { get; set; }
        [Required]
        public string Director { get; set; }
        [Required ]
        public string Rating {get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string  Notes { get; set; }
    }
}

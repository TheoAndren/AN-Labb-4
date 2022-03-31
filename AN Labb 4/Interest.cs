using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AN_Labb_4
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        [Required]
        public string InterestTitle { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

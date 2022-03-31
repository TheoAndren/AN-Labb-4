using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AN_Labb_4
{
    public class Website
    {
        [Key]
        public int WebsiteId { get; set; }
        [Required]
        public string Link { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETBootcamp.DataModel
{
    public class Project
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Detail { get; set; }

        [Required]
        [Display(Name = "Project type")]
        public ProjectType ProjectType { get; set; }
    }
}

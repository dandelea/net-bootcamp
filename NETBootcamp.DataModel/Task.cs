using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETBootcamp.DataModel
{
    public class Task
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        
        [MaxLength(1000)]
        public string Detail { get; set; }

        [Required]
        [Display(Name = "Task type")]
        public TaskType TaskType { get; set; }

        [Required]
        [Range(1,10)]
        public int Priority { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Due time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DueTime { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
    }
}

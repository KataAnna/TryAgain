using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TryAgain.Models
{
    public class ProjectViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
        [Display(Name = "Programmer ID")]
        public int ProgrammerId { get; set; }

    }
}

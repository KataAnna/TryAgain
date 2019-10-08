using System.ComponentModel.DataAnnotations;
using TryAgain.DAL.Entities;

namespace TryAgain.BLL.DTO
{
    class ProjectDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Worker Id")]
        public Programmer ProgrammerId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class ProgramImages
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public Guid? ProgramId { get; set; }
        public Program? program { get; set; }
    }
}

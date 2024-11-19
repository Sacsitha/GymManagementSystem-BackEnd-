using GymManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.DTO.RequestDTO
{
    public class ProgramRequestDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool Status { get; set; } = true;
        public List<ProgramImageRequestDTO>? Images { get; set; }

    }
}

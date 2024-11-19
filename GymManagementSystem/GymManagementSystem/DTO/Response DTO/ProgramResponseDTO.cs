using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.DTO.Response_DTO
{
    public class ProgramResponseDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<ProgramImageResponseDTO>? Images { get; set; }
        public List<SubscriptionResponseDTO>? Subscriptions { get; set; }
    }
}

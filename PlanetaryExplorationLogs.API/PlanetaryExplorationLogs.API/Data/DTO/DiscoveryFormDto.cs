using System.ComponentModel.DataAnnotations;

namespace PlanetaryExplorationLogs.API.Data.DTO
{
    public class DiscoveryFormDto
    {
        [Required]
        public int MissionId { get; set; }

        [Required]
        public int DiscoveryTypeId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "";

        [StringLength(500)]
        public string Description { get; set; } = "";

        [StringLength(200)]
        public string Location { get; set; } = "";
    }
}

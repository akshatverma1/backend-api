using System.ComponentModel.DataAnnotations;

namespace StudioBackendAPI.Models
{
    public class ProjectApplication
    {
        public int Id { get; set; }

        [Required] public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string ProductionCompany { get; set; }

        public string ProjectTitle { get; set; }

        public string ProjectType { get; set; }

        public string PreferredLocation { get; set; }

        public string EstimatedBudget { get; set; }

        public string AdditionalNotes { get; set; }
    }
}

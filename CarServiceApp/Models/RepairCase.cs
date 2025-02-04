using System.ComponentModel.DataAnnotations;

namespace CarServiceApp.Models
{
    public class RepairCase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Невирішені проблеми є обов'язковими")]
        public string UnresolvedIssues { get; set; } = string.Empty;

        [Required(ErrorMessage = "Історія ремонтів є обов'язковою")]
        public string RepairHistory { get; set; } = string.Empty;
    }
}

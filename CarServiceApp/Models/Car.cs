using System.ComponentModel.DataAnnotations;

namespace CarServiceApp.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Марка є обов'язковою")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Модель є обов'язковою")]
        public string Model { get; set; } = string.Empty;

        [Range(1900, 2025, ErrorMessage = "Рік має бути між 1900 та 2025")]
        public int Year { get; set; }

        [Required(ErrorMessage = "VIN є обов'язковим")]
        public string Vin { get; set; } = string.Empty;

        [Required(ErrorMessage = "Тип двигуна є обов'язковим")]
        public string EngineType { get; set; } = string.Empty;

        public string? PhotoPath { get; set; }

        public int? RepairCaseId { get; set; }
        public RepairCase? RepairCase { get; set; }
    }
}

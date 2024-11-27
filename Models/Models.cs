using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarServiceApp.Models
{
    // Represents a car with details like brand, model, year, and repair case
    public class Car
    {
        public int Id { get; set; } // Auto-incremented ID

        [Required(ErrorMessage = "Марка є обов'язковою")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Модель є обов'язковою")]
        public string Model { get; set; } = string.Empty;

        [Range(1900, 2025, ErrorMessage = "Рік має бути між 1900 та 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "VIN є обов'язковим")]
        public string Vin { get; set; } = string.Empty;

        [Required(ErrorMessage = "Тип двигуна є обов'язковим")]
        public string EngineType { get; set; } = string.Empty;

        public string? PhotoPath { get; set; } // Path to car photo

        // Foreign key for repair case
        public int? RepairCaseId { get; set; }
        public RepairCase? RepairCase { get; set; }
    }

    // Represents a repair case for tracking issues and history
    public class RepairCase
    {
        public int Id { get; set; } // Auto-incremented ID for repair case

        [Required(ErrorMessage = "Невирішені проблеми є обов'язковими")]
        public string UnresolvedIssues { get; set; } = string.Empty;

        [Required(ErrorMessage = "Історія ремонтів є обов'язковою")]
        public string RepairHistory { get; set; } = string.Empty;

        // Collection of cars associated with the repair case
        public ICollection<Car>? Cars { get; set; }
    }

    // Represents a user with role-based access
    public class User
    {
        public int Id { get; set; } // Unique user ID

        [Required(ErrorMessage = "Ім'я користувача є обов'язковим")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ім'я користувача має бути від 3 до 50 символів")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пароль є обов'язковим")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль має бути від 6 до 50 символів")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Роль є обов'язковою")]
        public string Role { get; set; } = string.Empty;
    }
}

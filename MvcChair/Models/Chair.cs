using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCChair.Models
{
    public class Chair
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string? Brand { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Type must start with a capital letter and contain only letters and spaces.")]
        public string? Type { get; set; }

        [Required]
        [StringLength(20)]
        public string? Color { get; set; }

        [Required]
        [StringLength(30)]
        public string? Material { get; set; }

        [Range(50, 300, ErrorMessage = "Capacity must be between 50 and 300 kg")]
        public int Capacity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(10.00, 10000.00)]
        public decimal Price { get; set; }

        [Range(1, 5)]
        [Column(TypeName = "decimal(3, 1)")]
        public decimal Rating { get; set; }

    }
}

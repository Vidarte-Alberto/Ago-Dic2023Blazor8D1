using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LasPollasHermanas.Client.Models
{
    public class Dildo
    {
        // Annotations 
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public decimal Size { get; set; }
        [Required]
        [MyDate(ErrorMessage = "La fecha debe de ser actual o posterior")]
        public DateTime ExpireDate { get; set; }
        [Required]
        public string? Material { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

    }
    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d <= new DateTime(2998, 12, 12) && d >= DateTime.Today; //Dates Greater than or equal to today are valid (true)

        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Calculator.UI.Models
{
    public class ProbabilityCalculationRequest
    {
        [Required]
        [Range(0,1, ErrorMessage = "Probability is out of range. Number must be between 0 and 1")]
        public double ProbabilityA { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "Probability is out of range. Number must be between 0 and 1")]
        public double ProbabilityB { get; set; }
        [Required]
        [StringLength(maximumLength:12, ErrorMessage = "You must select a calculation", MinimumLength = 6)]
        public string? TypeOfCalculation { get; set; }
    }
}
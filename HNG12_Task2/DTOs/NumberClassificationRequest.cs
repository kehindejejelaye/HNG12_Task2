using System.ComponentModel.DataAnnotations;

namespace HNG12_Task2.DTOs
{
    public class NumberClassificationRequest
    {
        [Required(ErrorMessage = "The number is required.")]
        //[Range(1, int.MaxValue, ErrorMessage = "The number must be a positive integer greater than 0.")]
        public int Number { get; set; }
    }
}

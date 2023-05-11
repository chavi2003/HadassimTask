using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMO_Covid.Models
{
    public class Covid
    {
        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Id number must be 9 digits")]
        public string idMember { get; set; }
        public DateTime? firstVaccinationDate { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$", ErrorMessage = "Characters are not allowed")]
        public string? firstVaccinationManufacturer { get; set; }
        public DateTime? secondVaccinationDate { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$", ErrorMessage = "Characters are not allowed")]
        public string? secondVaccinationManufacturer { get; set; }
        public DateTime? thirdVaccinationDate { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$", ErrorMessage = "Characters are not allowed")]
        public string? thirdVaccinationManufacturer { get; set; }
        public DateTime? fourthVaccinationDate { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$", ErrorMessage = "Characters are not allowed")]
        public string? fourthVaccinationManufacturer { get; set; }
        public DateTime? dateOfGettingPositiveResult { get; set; }
        public DateTime? recoveryDate { get; set; }
    }
}

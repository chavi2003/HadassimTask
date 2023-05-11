using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMO_Covid.Models
{
    public class Member
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]$",ErrorMessage ="Characters are not allowed")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]$", ErrorMessage = "Characters are not allowed")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^\d{9}$",ErrorMessage ="Id number must be 9 digits")]
        public string Id { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^\d{9}$",ErrorMessage = "phone number must be 9 digits")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "cellPhone number must be 9 digits")]
        
        public string CellPhone { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }

        
    }
}

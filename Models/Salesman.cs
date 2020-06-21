using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKomplet.Models
{
    public class Salesman
    {
        [Key]
        public int SalesmanID { get; set; }
        public int PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        public string FirstName { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        public string LastName { get; set; }
        
    }
}

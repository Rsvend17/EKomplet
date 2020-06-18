using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EKomplet.Models
{
    public class Salesman
    {
        [Key]
        [Range(8,8)]
        public int PhoneNumber { get; set; }
        [StringLength(50)]
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

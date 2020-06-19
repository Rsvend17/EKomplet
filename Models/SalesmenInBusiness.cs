using System.ComponentModel.DataAnnotations;

namespace EKomplet.Models
{
    public class SalesmenInBusiness
    {
        [Key]
        public int BusinessID { get; set; }

        [Key]
        public int SalesmanID { get; set; }

        public Business Business { get; set; }

        public Salesman Salesman { get; set; }
    }
}
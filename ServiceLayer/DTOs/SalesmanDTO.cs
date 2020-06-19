using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Models;

namespace EKomplet.ServiceLayer.DTOs
{
    public class SalesmanDTO
    {

        public int SalesmanID { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public SalesmanDTO(Salesman salesman)
        {
            this.SalesmanID = salesman.SalesmanID;
            this.PhoneNumber = salesman.PhoneNumber;
            this.Email = salesman.Email;
            this.FirstName = salesman.FirstName;
            this.LastName = salesman.LastName;
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}

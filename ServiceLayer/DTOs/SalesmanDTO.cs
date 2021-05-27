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

        public Status? SalesmanStatus { get; set; }


        public SalesmanDTO(Salesman salesman, SalesmenStatusDTO salesmenStatus)
        {
            SalesmanID = salesman.SalesmanID;
            PhoneNumber = salesman.PhoneNumber;
            Email = salesman.Email;
            FirstName = salesman.FirstName;
            LastName = salesman.LastName;
            SalesmanStatus = salesmenStatus.Status;
        }

        public SalesmanDTO(Salesman salesman)
        {
            SalesmanID = salesman.SalesmanID;
            PhoneNumber = salesman.PhoneNumber;
            Email = salesman.Email;
            FirstName = salesman.FirstName;
            LastName = salesman.LastName;
        }

        public string FullName => string.Format("{0} {1}", FirstName, LastName);

        public string Status
        {
            get
            {
                if (SalesmanStatus == Models.Status.Primary)
                    return "Primær";
                else
                    return "Sekundær";
            }
        }
    }
}
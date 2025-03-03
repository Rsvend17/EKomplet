﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Models;

namespace EKomplet.ServiceLayer.DTOs
{
    public class SalesmenStatusDTO
    {
        public int SalesmanID { get; set; }
        public int DistrictID { get; set; }

        public Status Status { get; set; }

        public SalesmenStatusDTO()
        {
        }

        public SalesmenStatusDTO(SalesmenStatus status)
        {
            SalesmanID = status.SalesmanID;
            DistrictID = status.DistrictID;
            Status = (Status) status.Status;
        }
    }
}
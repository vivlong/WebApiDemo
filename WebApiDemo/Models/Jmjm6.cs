﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Jmjm6
    {
        [Key]
        public string JobNo { get; set; }
        public int LineItemNo { get; set; }
        public string ContainerNo { get; set; }
        public string Remark { get; set; }
        public string VehicleNo { get; set; }
        public string DriverNo { get; set; }
        public string CargoStatusCode { get; set; }
        public Nullable<System.DateTime> TruckDateTime { get; set; }
        public Nullable<System.DateTime> RecevieDateTime { get; set; }
        public Nullable<System.DateTime> ReadyDateTime { get; set; }
        public Nullable<System.DateTime> UnLoadDateTime { get; set; }
    }
}
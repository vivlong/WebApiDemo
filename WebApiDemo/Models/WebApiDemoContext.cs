using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class WebApiDemoContext : DbContext
    {
        public WebApiDemoContext()
                : base("name=CC802Freight")
        {
        }

        public System.Data.Entity.DbSet<WebApiDemo.Models.Rcbp1> DtRcbp1 { get; set; }
    }
}
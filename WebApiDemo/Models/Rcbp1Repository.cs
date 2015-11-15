using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiDemo.Interface;

namespace WebApiDemo.Models
{
    public class Rcbp1Repository : IRcbp1Repository
    {
        private WebApiDemoContext db = new WebApiDemoContext();
        public Rcbp1Repository()
        {
        }
        public IQueryable<Rcbp1> GetAll()
        {
            return db.DtRcbp1;
        }
    }
}
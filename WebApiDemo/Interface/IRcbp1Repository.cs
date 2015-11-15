using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Interface
{
    interface IRcbp1Repository
    {
        IQueryable<Rcbp1> GetAll();
    }
}

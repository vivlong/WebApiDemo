using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Models;

namespace WebApiDemo.Interface
{
    interface IJmjm6Repository
    {
        IEnumerable<Jmjm6> GetAll();
        Jmjm6 Get(int id);
        Jmjm6 Add(Jmjm6 item);
        void Remove(int id);
        bool Update(Jmjm6 item);
    }
}

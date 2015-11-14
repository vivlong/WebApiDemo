using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiDemo.Interface;

namespace WebApiDemo.Models
{
    public class Jmjm6Repository : IJmjm6Repository
    {
        private List<Jmjm6> Jmjm6s = new List<Jmjm6>();
        private int _nextId = 1;
        public Jmjm6Repository()
        {
            Add(new Jmjm6 { Name = "Tomato soup", Category = "Groceries", Price = 1.39M });
            Add(new Jmjm6 { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
            Add(new Jmjm6 { Name = "Hammer", Category = "Hardware", Price = 16.99M });
        }
        public IEnumerable<Jmjm6> GetAll()
        {
            return Jmjm6s;
        }
        public Jmjm6 Get(int id)
        {
            return Jmjm6s.Find(p => p.Id == id);
        }
        public Jmjm6 Add(Jmjm6 item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            Jmjm6s.Add(item); return item;
        }
        public void Remove(int id)
        {
            Jmjm6s.RemoveAll(p => p.Id == id);
        }
        public bool Update(Jmjm6 item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Jmjm6s.FindIndex(p => p.Id == item.Id); if (index == -1)
            {
                return false;
            }
            Jmjm6s.RemoveAt(index);
            Jmjm6s.Add(item); return true;
        }
    }
}
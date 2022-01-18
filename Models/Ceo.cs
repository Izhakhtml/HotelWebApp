using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApp.Models
{
    public class Ceo
    {
        public int id;
        public string fullName;
        public int age;
        public string email;
        public int salary;

        public Ceo(int id, string fullName, int age, string email, int salary)
        {
            this.id = id;
            this.fullName = fullName;
            this.age = age;
            this.email = email;
            this.salary = salary;
        }
        public Ceo() { }
    }
}
using carservice.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carservice.model
{
    public class Worker

    {
        private int id;
        private String name;
        private int category;
        private String speciality;

   
        public int Id { get => id; set => id = value; }
        public String Name { get => name; set => name = value; }
        public int Category { get => category; set => category = value; }
        public String Speciality { get => speciality; set => speciality = value; }


    }
}

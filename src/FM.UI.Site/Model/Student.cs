using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FM.UI.Site.Model
{
    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public string Gender { get; set; }
    }
}

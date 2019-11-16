using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Person
    {
        public string Name { set; get; }
        public DateTime BirthDate { set; get; }
        public Gender gender { set; get; }
        public int Age { set; get; }

        public Person(string name, DateTime birthdate, Gender gender)
        {
            Name = name;
            BirthDate = birthdate;
            this.gender = gender;
            Age = DateTime.Now.Year - BirthDate.Year;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Gender: " + gender + ", Age: " + Age + ", BirthDate: " + BirthDate.ToString("yyyy-MM-dd");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Fred", new DateTime(1990, 05, 24), Gender.MALE);
            Console.WriteLine(person);
            person.Serialize("");
            Console.ReadLine();
            person = Person.Deserialize();
            Console.WriteLine(person);
            Console.ReadLine();
        }
    }
}

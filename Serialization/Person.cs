using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Person: IDeserializationCallback, ISerializable
    {
        private static string FileName = "Az.bin";
        public string Name { set; get; }
        public DateTime BirthDate { set; get; }
        public Gender gender { set; get; }
        public int Age { get => age; set => age = value; }
        [NonSerialized]
        private int age;

        public Person()
        { 
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            BirthDate = (DateTime)info.GetValue("BirthDate", typeof(DateTime));
            gender = (Gender)info.GetValue("gender", typeof(Gender));
        }

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

        public void Serialize(string output)
        {
            FileStream filestream = new FileStream(FileName, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(filestream, this);
            filestream.Close();
        }

        public static Person Deserialize()
        {
            Person person = new Person();

            FileStream filestream = new FileStream(FileName,FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();
            person = (Person)formatter.Deserialize(filestream);
            filestream.Close();
            return person;
        }

        public void OnDeserialization(object sender)
        {
            Age = DateTime.Now.Year - BirthDate.Year;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name, typeof(string));
            info.AddValue("BirthDate", this.BirthDate, typeof(DateTime));
            info.AddValue("gender", this.gender, typeof(Gender));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace PartnerSelectLib
{
    public class Respository : IRespository
    {
        public List<Person> GetEmployees()
        {
            List<Person> employees = new List<Person>();

            var io = new System.IO.StreamReader(@"C:\Projects\PartnerSelect\PartnerSelect\Employees.xml");
            var data2 = io.ReadToEnd();
            
            XmlSerializer Serializer = new XmlSerializer(typeof(Feed));
            StringReader rdr = new StringReader(data2);
            var result = (Feed)Serializer.Deserialize(rdr);
            //var xmlReader = new XmlReader();



            //var reader = new XmlTextReader());
            //var ResponseStream = reader.ReadOuterXml();
            
                //XmlSerializer Serializer = new XmlSerializer(typeof(Feed));
                //var emps = (Feed)Serializer.Deserialize(io);

            //XmlSerializer serializer = new XmlSerializer(typeof(Person));
            //Person person = (Person)serializer.Deserialize(new XmlTextReader(@"C:\Projects\PartnerSelect\PartnerSelect\App_Data\employees.xml"));
            //MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(

            employees.Add(new Person() { EmployeeNumber = "1", FirstName = "Gary", TelNo = "0207-716-4518", LastName = "Ponder", Gender = Gender.Male, Voting = true, Email = "gary.ponder@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "2", FirstName = "Mo", LastName = "Gong", TelNo = "0207-716-4518", Gender = Gender.Female, Voting = true, Email = "mo.gong@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "3", FirstName = "Hon", LastName = "Wong", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = true, Email = "hon.wong@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "4", FirstName = "Melanie", LastName = "Devonshire", TelNo = "0207-716-4518", Gender = Gender.Female, Voting = false, Email = "melanie.devonshire@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "5", FirstName = "Mark", LastName = "Johnson", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = false, Email = "mark.johnson@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "6", FirstName = "Wayne", LastName = "Brocklehurst", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = false, Email = "wayne.brocklehurst@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "7", FirstName = "Stephen", LastName = "Gibbons", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = false, Email = "stephen.gibbons@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "8", FirstName = "Nazmin", LastName = "Begum", TelNo = "0207-716-4518", Gender = Gender.Female, Voting = false, Email = "nazmin.begum@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "9", FirstName = "Chris", LastName = "Summers", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = true, Email = "chris.summers@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 2, Name = "Corporate" } });
            employees.Add(new Person() { EmployeeNumber = "10", FirstName = "James", LastName = "Emanuel", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = false, Email = "james.emanuel@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "11", FirstName = "Tony", LastName = "Williams", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = true, Email = "tony.williams@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 4, Name = "Tax" } });
            employees.Add(new Person() { EmployeeNumber = "12", FirstName = "Lucy", LastName = "Yilmaz", TelNo = "0207-716-4518", Gender = Gender.Female, Voting = true, Email = "lucy.yilmaz@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "13", FirstName = "Steven", LastName = "Abunu", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = false, Email = "steven.abunu@mycompany.com", Office = new Office() { Id = 2, Name = "Paris" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "14", FirstName = "Dan", LastName = "Gibbons", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = false, Email = "dan.gibbons@mycompany.com", Office = new Office() { Id = 2, Name = "Paris" }, Department = new Department() { Id = 1, Name = "ACT" } });
            employees.Add(new Person() { EmployeeNumber = "15", FirstName = "Mark", LastName = "Taylor", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = true, Email = "mark.taylor@mycompany.com", Office = new Office() { Id = 2, Name = "Paris" }, Department = new Department() { Id = 1, Name = "ACT" } });

            return employees;
        }

        public List<Person> GetFavorites()
        {
            List<Person> employees = new List<Person>();

            //employees.Add(new Person() { EmployeeNumber = 1, FirstName = "Gary", TelNo = "0207-716-4518", LastName = "Ponder", Gender = Gender.Male, Voting = true, Email = "gary.ponder@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            //employees.Add(new Person() { EmployeeNumber = 2, FirstName = "Mo", LastName = "Gong", TelNo = "0207-716-4518", Gender = Gender.Female, Voting = true, Email = "mo.gong@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            //employees.Add(new Person() { EmployeeNumber = 3, FirstName = "Hon", LastName = "Wong", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = true, Email = "hon.wong@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            //employees.Add(new Person() { EmployeeNumber = 4, FirstName = "Melanie", LastName = "Devonshire", TelNo = "0207-716-4518", Gender = Gender.Female, Voting = false, Email = "melanie.devonshire@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            //employees.Add(new Person() { EmployeeNumber = 12, FirstName = "Lucy", LastName = "Yilmaz", TelNo = "0207-716-4518", Gender = Gender.Female, Voting = true, Email = "lucy.yilmaz@mycompany.com", Office = new Office() { Id = 1, Name = "London" }, Department = new Department() { Id = 1, Name = "ACT" } });
            //employees.Add(new Person() { EmployeeNumber = 14, FirstName = "Dan", LastName = "Gibbons", TelNo = "0207-716-4518", Gender = Gender.Male, Voting = false, Email = "dan.gibbons@mycompany.com", Office = new Office() { Id = 2, Name = "Paris" }, Department = new Department() { Id = 1, Name = "ACT" } });

            return employees;
        }

        public List<Office> GetOffices()
        {
            List<Office> results = new List<Office>();

            results.Add(new Office() { Id = 1, Name = "London" });
            results.Add(new Office() { Id = 2, Name = "Paris" });
            results.Add(new Office() { Id = 3, Name = "New York" });
            results.Add(new Office() { Id = 4, Name = "Washington" });

            return results;
        }

        public List<Department> GetDepartments()
        {
            List<Department> results = new List<Department>();

            results.Add(new Department() { Id = 1, Name = "ACT" });
            results.Add(new Department() { Id = 2, Name = "Corporate" });
            results.Add(new Department() { Id = 3, Name = "IP/IT" });
            results.Add(new Department() { Id = 4, Name = "Tax" });

            return results;
        }
    }
}

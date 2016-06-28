using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using PartnerSelectLib;

namespace PartnerSelect
{
    [DataObject]
    public class StaticCache
    {
        private static List<Person> _employees = new List<Person>();
        private static List<Person> _favourites = new List<Person>();
        private static List<Office> _offices = new List<Office>();
        private static List<Department> _departments = new List<Department>();

        public static void LoadStaticCache()
        {
            // Get suppliers - cache using a static member variable
            Respository repository  = new PartnerSelectLib.Respository();

            _employees = repository.GetEmployees();
            _favourites = repository.GetFavorites();
            _offices = repository.GetOffices();
            _departments = repository.GetDepartments();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<Person> GetEmployees()
        {
            return _employees;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<Person> GetFavourites()
        {
            return _favourites;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<Office> GetOffices()
        {
            return _offices;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<Department> GetDepartments()
        {
            return _departments;
        }

        public static void PersonToFavourites(Person person)
        {
            if (!IsPersonInFavourites(person))
                _favourites.Add(person);
            else
                _favourites.Remove(person);
        }

        public static void AddPersonToFavourites(Person person)
        {
            if (!IsPersonInFavourites(person))
                _favourites.Add(person);
        }

        public static void RemovePersonToFavourites(Person person)
        {
            if (IsPersonInFavourites(person))
                _favourites.Remove(person);
        }

        public static Person FindPersonById(string Id)
        {
            List<Person> employees = StaticCache.GetEmployees();
            //Person foundPerson = (Person)employees.FirstOrDefault(a => a.EmployeeNumber.Equals(Id));
            return employees.Find(a => a.EmployeeNumber.Equals(Id));
        }

        public static bool IsPersonInFavourites(Person person)
        {
            List<Person> favourites = StaticCache.GetFavourites();
            return favourites.Exists(a => a.EmployeeNumber.Equals(person.EmployeeNumber));
        }
    }
}
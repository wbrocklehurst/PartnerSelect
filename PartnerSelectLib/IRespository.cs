using System;
using System.Collections.Generic;
namespace PartnerSelectLib
{
    interface IRespository
    {
        List<Department> GetDepartments();
        List<Person> GetEmployees();
        List<Office> GetOffices();
        List<Person> GetFavorites();
    }
}

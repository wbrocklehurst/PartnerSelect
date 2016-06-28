using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PartnerSelectLib
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public class Person
    {
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
        public bool Voting { get; set; }
        public Office Office { get; set; }
        public Department Department { get; set; }
    }

    /// <summary>
    /// Enums for Gender
    /// </summary>
    public enum Gender
    {
        [DescriptionAttribute("Female")]
        Female = 'F',
        [DescriptionAttribute("Male")]
        Male = 'M'
    }
}

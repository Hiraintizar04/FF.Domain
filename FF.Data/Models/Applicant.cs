using System;
using System.Collections.Generic;
using System.Text;


namespace FF.Data.Models
{

    public class Applicant
    {
        public int ApplicantId { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public Boolean Hired { get; set; }
    }
}


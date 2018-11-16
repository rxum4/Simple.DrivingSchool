namespace Simple.DrivingSchool.BusinessLogic.Models
{
    using System;
    public class Student
    {
        public Guid Id { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string Gender { get; set; }
    }
}
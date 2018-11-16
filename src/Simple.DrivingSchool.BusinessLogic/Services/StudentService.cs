namespace Simple.DrivingSchool.BusinessLogic.Services
{
    using System;
    using System.Threading.Tasks;

    using Simple.DrivingSchool.BusinessLogic.Models;
    public class StudentService : Abstraction.IStudentService
    {
        public Task CreateAsync(Student student)
        {
            return Task.CompletedTask;
        }
    }
}
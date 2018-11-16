namespace Simple.DrivingSchool.BusinessLogic.Services.Abstraction
{
    using System.Threading.Tasks;
    using Simple.DrivingSchool.BusinessLogic.Models;
    public interface IStudentService
    {
        Task CreateAsync(Student student);
    }
}
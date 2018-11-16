namespace Simple.DrivingSchool.DataAccess.Repositories.Abstraction
{
    using System.Threading.Tasks;

    using Simple.DrivingSchool.DataAccess.Models;
    public interface IStudentRepository
    {
        Task CreateAsync(StudentCreationModel creationModel);
    }
}
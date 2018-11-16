namespace Simple.DrivingSchool.BusinessLogic.ModelBuilder.Abstraction
{
    using System.Threading.Tasks;

    using dto = Simple.DrivingSchool.BusinessLogic.Models;
    using dao = Simple.DrivingSchool.DataAccess.Models;
    public interface IStudentModelBuilder
    {
        Task<dao.StudentCreationModel> GenerateCreationModel(dto.Student student);
    }
}
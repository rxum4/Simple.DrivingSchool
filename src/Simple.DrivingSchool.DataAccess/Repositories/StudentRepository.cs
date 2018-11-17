namespace Simple.DrivingSchool.DataAccess.Repositories
{
    using System;
    using System.Threading.Tasks;

    using Simple.DrivingSchool.DataAccess.Models;
    using Simple.DrivingSchool.DataAccess.Persistence.Abstraction;
    public class StudentRepository : Abstraction.IStudentRepository
    {
        public IPersistence Persistence { get; }
        public StudentRepository(IPersistence persistence)
        {
            Persistence = persistence;
        }
        public Task CreateAsync(StudentCreationModel creationModel)
        {
            if (creationModel is null)
                throw new ArgumentNullException(nameof(creationModel));

            Persistence.Upsert(creationModel);

            return Task.CompletedTask;
        }
    }
}
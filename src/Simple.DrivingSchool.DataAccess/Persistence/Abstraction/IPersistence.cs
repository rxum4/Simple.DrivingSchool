namespace Simple.DrivingSchool.DataAccess.Persistence.Abstraction
{
    using System.Threading.Tasks;

    public interface IPersistence
    {
        Task Upsert(object model);
    }
}
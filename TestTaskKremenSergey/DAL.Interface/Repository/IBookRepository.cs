using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    //interface for book repository for CRUD operations
    //it can contain some operations specific for books but in our case there is no need in them
    //it can exist for programm extensibility
    public interface IBookRepository: IRepository<DALBook>
    {
    }
}

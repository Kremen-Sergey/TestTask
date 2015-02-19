
using BLL.Interface.Entities;

namespace Bll.Interface.Services
{
    public interface IBookService: IService<BookEntity>
    {
        BookCatalog BooksCatalog { get; set; }
    }
}

using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using Bll.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class BookService: IBookService
    {
        //service is catalog of books
        //in this model we create abstract book servise for simplification
        //if we had shop and user we should create UserBookService and ShopBookService
        private readonly IUnitOfWork uow;
        private readonly IBookRepository bookRepository;

        public BookService(IUnitOfWork uow, IBookRepository bookRepository)
        {
            this.uow = uow;
            this.bookRepository = bookRepository;
            //simplification not to create book catalog repository
            //in order to resolve dependencies instead of this we shoul create BookCatalog table, BookCatalog class in orm, BookCatalogRepository, BookCatalogService etc.
            BooksCatalog=new BookCatalog();
            //in this simplification we assume that all books are in one catalog so we dont need other tables in database and repositories
            foreach (var book in GetAll())
            {
                BooksCatalog.AddEntityToCatalog(book);
            }
        }

        public BookCatalog BooksCatalog {get;set;} 

        public IEnumerable<BookEntity> GetAll()
        {
            return bookRepository.GetAll().Select(book => book.ToBllBook();
        }

        public BookEntity GetById(int key)
        {
            if (bookRepository.GetById(key) == null) { return null; }
            return bookRepository.GetById(key).ToBllBook();
        }

        public void Create(BookEntity book)
        {
            bookRepository.Create(book.ToDalBook());
            uow.Commit();
        }

        public void Delete(BookEntity book)
        {
            bookRepository.Delete(book.ToDalBook());
            uow.Commit();
        }
    }
}

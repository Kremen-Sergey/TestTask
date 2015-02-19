using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class BookRepository: IBookRepository
    {
        private readonly DbContext context;
        public BookRepository(IUnitOfWork uow)
        {
            this.context = uow.Context;    
        }
        public IEnumerable<DALBook> GetAll()
        {
            return context.Set<Book>().Select(book => new DALBook()
            {
                Id=book.Id,
                Author=book.Author,
                Title=book.Title,
                Published=book.Published,
                TextSource=book.TextSource,
                Price=book.Price,
                JunkPrice=book.JunkPrice
            });
        }

        public DALBook GetById(int key)
        {
            var book = context.Set<Book>().FirstOrDefault(b => b.Id == key);
            if (book == null) { return null; }
            return new DALBook()
            {
                Id=book.Id,
                Author=book.Author,
                Title=book.Title,
                Published=book.Published,
                TextSource=book.TextSource,
                Price=book.Price,
                JunkPrice=book.JunkPrice
            };

        }

        public void Create(DALBook book)
        {
            var newbook = new Book()
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Published = book.Published,
                TextSource = book.TextSource,
                Price = book.Price,
                JunkPrice = book.JunkPrice
            };
            context.Set<Book>().Add(newbook);
        }

        public void Delete(DALBook book)
        {
            var ormbook = context.Set<Book>().FirstOrDefault(b => b.Id == book.Id);
            if (ormbook != null)
            {
                context.Set<Book>().Remove(ormbook);
            }
        }
        //there is no need in update method in our case
        //it is represented as part of CRUD operations here
        //this method changes path to book text in file system
        public void Update(DALBook book)
        {
            var ormbook = context.Set<Book>().FirstOrDefault(b => b.Id == book.Id);
            if (ormbook != null)
            {
                ormbook.TextSource = book.TextSource;
                context.Entry(ormbook).State = EntityState.Modified;
            }
        }
    }
}

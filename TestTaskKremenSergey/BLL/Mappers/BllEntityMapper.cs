using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMapper
    {
        public static DALBook ToDalBook(this BookEntity bookEntity)
        {
            return new DALBook()
            {
                Id = bookEntity.Id,
                Author = bookEntity.Author,
                Title = bookEntity.Title,
                Published = bookEntity.Published,
                TextSource = bookEntity.TextSource,
                Price = bookEntity.Price,
                JunkPrice = bookEntity.JunkPrice
            };
        }

        public static BookEntity ToBllBook(this DALBook dalBook)
        {
            return new BookEntity()
            {
                Id = dalBook.Id,
                Author = dalBook.Author,
                Title = dalBook.Title,
                Published = dalBook.Published,
                TextSource = dalBook.TextSource,
                Price = dalBook.Price,
                JunkPrice = dalBook.JunkPrice
            };
        }

    }
}

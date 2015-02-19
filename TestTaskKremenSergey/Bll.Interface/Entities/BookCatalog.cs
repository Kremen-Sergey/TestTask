using System;
using System.Collections.Generic;
using System.IO;

namespace BLL.Interface.Entities
{
    //catalog of books
    public class BookCatalog: ICatalog<BookEntity>
    {
        public decimal Score { get; set; }//score for buying and selling books
        public LinkedList<BookEntity> ListEntities { get; set; }

        public LinkedList<LinkedList<BookEntity>> Pedestals { get; set; }

        //here must be methods for work with catalog. 
        //Base methods as add to catalog and remove from catalog are represented here.
        public void AddEntityToCatalog(BookEntity entity)
        {
            ListEntities.AddLast(entity);
        }

        public void DeleteEntityFromCatalog(BookEntity entity)
        {
            ListEntities.Remove(entity);
        }
        //method moves books from library(ListEntites) to new pedestal in pedestal list(Pedestals)
        //books in pedestals are unavailable for use-they can't be bought, sold out, search in this books is also unavailable
        public void CreatePedestal(LinkedList<BookEntity> bookListForPedestal)
        {
            var pedestal = new LinkedList<BookEntity>(bookListForPedestal);
            Pedestals.AddLast(pedestal);
            foreach (var bookEntity in bookListForPedestal)
            {
                if (!ListEntities.Contains(bookEntity)) { throw new InvalidOperationException();}//if user create pedestal from books which don't exist in catalog. This error can occur only during aplication creation and is required for debugging
                ListEntities.Remove(bookEntity);
            }
        }

        public void RemovePedestal(LinkedList<BookEntity> bookListForPedestal)
        {
            foreach (var bookEntity in bookListForPedestal)
            {
                ListEntities.AddLast(bookEntity);
            }
            Pedestals.Remove(bookListForPedestal);
        }
        public void BuyBook(BookEntity book)
        {
            ListEntities.AddLast(book);
            Score -= book.Price;
        }
        public void SellBookToJunk(BookEntity book)
        {
            ListEntities.Remove(book);
            Score += book.JunkPrice;
        }

        public LinkedList<string> Search(string strSearchRequest, BookEntity book)
        {
            //open file for reading
            var streamReader = new StreamReader(book.TextSource);
            //reading text from file to str
            string str = "";
            while (!streamReader.EndOfStream)
            {
                str += streamReader.ReadLine();
            }
            var result = new LinkedList<string>();
            var i = -1;
            while ((i=str.IndexOf(strSearchRequest))!=-1)
            {
                var tempStr = "..." + str.Substring(i, 100) + "...\n";
                result.AddLast(tempStr);
                str = str.Substring(i + tempStr.Length, str.Length - i - tempStr.Length);
            }
            return result;
        }


    }
}

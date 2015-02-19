
namespace BLL.Interface.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int Published { get; set; }
        public string TextSource { get; set; }
        public decimal Price { get; set; }
        public decimal JunkPrice { get; set; }

    }
}

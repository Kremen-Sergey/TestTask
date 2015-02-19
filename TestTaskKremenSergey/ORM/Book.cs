namespace ORM
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //class for book in orm layer
    //it is automaticaly generated using codefirst with existing database approach
    [Table("Book")]
    public partial class Book
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int Published { get; set; }

        public string TextSource { get; set; }

        public decimal Price { get; set; }

        public decimal JunkPrice { get; set; }
    }
}

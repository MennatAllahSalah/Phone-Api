using System.ComponentModel.DataAnnotations.Schema;

namespace phoneBook.Model
{
    public class Phones
    {
        public int id { get; set; }
        [ForeignKey("BookPhone")]
        public int bookid { get; set; }
        public string phone { get; set; }
        public virtual BookPhone BookPhone { get; set; }
    }
}

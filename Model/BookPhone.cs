using System.Collections.Generic;

namespace phoneBook.Model
{
    public class BookPhone
    {
       // public string phone { get; set; }
        public string name { get; set; }
        public int Id { get; set; }
        public List<Phones> Phones { get; set; }
    }
}

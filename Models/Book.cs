namespace BookStore.Models
{
    public class Book
    {
        public int BookID { set; get; }
        public string Title { set; get; }
        public int NumberofPages { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime UpdatedDate { set; get; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class MyArray
    {
        public int bookID { get; set; }
        public string title { get; set; }
        public int numberofPages { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
    }

    public class Root
    {
        public List<MyArray> MyArray { get; set; }
    }


}




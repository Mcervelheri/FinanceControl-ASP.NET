namespace ASP.NET_Core__MVC_.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}

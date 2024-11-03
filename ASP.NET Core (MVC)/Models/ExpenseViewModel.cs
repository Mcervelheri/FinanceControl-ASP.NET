namespace ASP.NET_Core__MVC_.Models
{
    public class ExpenseViewModel
    {
        public Expense Expense { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        
        
    }
}
